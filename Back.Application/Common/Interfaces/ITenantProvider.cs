using Back.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Common.Interfaces
{
    public interface ITenantProvider
    {
        Organizacion GetTenant();
        void SetTenant(Organizacion organizacion);
    }
}
