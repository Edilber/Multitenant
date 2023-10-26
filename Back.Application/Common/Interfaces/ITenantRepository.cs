using Back.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Common.Interfaces
{
    public interface ITenantRepository
    {
        Task<Organizacion?> GetTenantAsync(string tenantId);
        Task<Organizacion?> GetTenantAsync(string tenantId, string userId);

    }
}
