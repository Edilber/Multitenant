using Back.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Services
{
    public class TenantMiddleware : IMiddleware
    {
        private readonly ITenantProvider _tenantProvider;
        private readonly ITenantRepository _tenantRepository;

        public TenantMiddleware(ITenantProvider tenantProvider, ITenantRepository tenantRepository)
        {
            _tenantProvider = tenantProvider;
            _tenantRepository = tenantRepository;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var slugName = GetTenantSlug(context);
            
            if(slugName == null)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsJsonAsync(new { message = "tenant inválido" });
                return;
            }

            var tenant = await _tenantRepository.GetTenantAsync(slugName);

            if(tenant == null)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsJsonAsync(new { message = "tenant inválido" });
                return;
            }

            _tenantProvider.SetTenant(tenant);

            await next(context);
        }

        public static string? GetTenantSlug(HttpContext context)
        {
            var basePath = context.Request.Path.Value;
            var slugTenant = basePath.Split("/")[1];
            return slugTenant;
        }
    }
}
