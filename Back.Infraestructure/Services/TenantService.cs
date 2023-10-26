using Back.Application.Common.Interfaces;
using Back.Core.Entities;
using Back.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Services
{
    public class TenantService : ITenantService
    {
        private Organizacion? _tenant = null;

        public Organizacion GetCompanyByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Organizacion GetCompanyByPathUrl(string pathUrl)
        {
            throw new NotImplementedException();
        }
    }
}
