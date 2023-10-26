using Back.Application.Common.Exceptions;
using Back.Application.Common.Interfaces;
using Back.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Services
{
    public class TenantProvider : ITenantProvider
    {
        private Organizacion? _tenant = null;
        public Organizacion GetTenant()
        {
            return _tenant ?? throw new TenantNotSetException();
        }

        public void SetTenant(Organizacion organizacion)
        {
            _tenant = organizacion;
        }
    }
}
