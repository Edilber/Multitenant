using Back.Infraestructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Back.Application.Common.Interfaces;
using Back.Core.Repositories.Command.Base;
using Back.Core.Repositories.Command;
using Back.Core.Repositories.Query.Base;
using Back.Core.Repositories.Query;
using Back.Infraestructure.Repositories.Command.Base;
using Back.Infraestructure.Repositories.Command;
using Back.Infraestructure.Repositories.Query.Base;
using Back.Infraestructure.Repositories.Query;
using Back.Infraestructure.Services;
using Back.Core.Entities;
using Back.Application.Common.Exceptions;
using Microsoft.Extensions.Options;

namespace Back.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {

            //Base de datos Mysql
            services.AddDbContext<AdminContext>(options =>
            options.UseMySql(configuration.GetConnectionString("Manager"), ServerVersion.AutoDetect(configuration.GetConnectionString("Manager")), b => b.MigrationsAssembly(typeof(AdminContext).Assembly.FullName)));  // Production - Develop

            services.AddDbContext<ApplicationDbContext>((serviceProvider,options) =>
            {
                var tenant = serviceProvider.GetService<ITenantProvider>()?.GetTenant();
                if (tenant is null)
                    throw new TenantNotSetException();

                options.UseMySql(tenant.ConnectionString, ServerVersion.AutoDetect(tenant.ConnectionString));
            });  


            
            services.AddIdentity<CompanyUser, IdentityRole>()
                .AddEntityFrameworkStores<AdminContext>()
                .AddDefaultTokenProviders();

           

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false; // For special character
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890:";
            });

            services.AddScoped<TenantMiddleware>();
            services.AddScoped<ITenantProvider, TenantProvider>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<IProductoQueryRepository, ProductoQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));

            return services;
        }
    }
}
