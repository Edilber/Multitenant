using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Core.Entities
{
    public class Organizacion
    {
        public int OrganizacionId { get; set; }
        public string Nombre { get; set; }
        public string SlugTenant { get; set; }
        public string ConnectionString { get; set; }
    }
}
