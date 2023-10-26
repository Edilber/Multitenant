using Back.Core.Entities;
using Back.Core.Repositories.Command;
using Back.Core.Repositories.Command.Base;
using Back.Infraestructure.Data;
using Back.Infraestructure.Repositories.Command.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Repositories.Command
{
    public class ProductoCommandRepository : CommandRepository<Producto>, IProductoCommandRepository
    {
        protected ProductoCommandRepository(IConfiguration configuration, AdminContext managerContext, ApplicationDbContext autosaContext) : base(configuration, managerContext, autosaContext)
        {
        }
    }
}
