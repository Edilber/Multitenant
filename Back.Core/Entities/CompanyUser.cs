using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Core.Entities
{
    public class CompanyUser : IdentityUser
    {
        public int OrganizacionId { get; set; }
        public Organizacion Organizacion { get; set; }
    }
}
