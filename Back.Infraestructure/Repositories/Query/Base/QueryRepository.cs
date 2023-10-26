using Back.Core.Repositories.Query.Base;
using Back.Infraestructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Repositories.Query.Base
{
    public class QueryRepository<T> : DbConector, IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration, AdminContext context, ApplicationDbContext autosa) : base(configuration, context, autosa)
        {
        }
    }
}
