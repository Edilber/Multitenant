using Back.Application.Common.Interfaces;
using Back.Core.Entities;
using Back.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Services
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AdminContext _context;

        public TenantRepository(AdminContext context)
        {
            _context = context;
        }

        public Task<Organizacion?> GetTenantAsync(string tenantId)
        {
            var tenant = _context.Organizacion.FirstOrDefaultAsync(t => t.SlugTenant == tenantId);
            return tenant;
        }

        public Task<Organizacion?> GetTenantAsync(string tenantId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
