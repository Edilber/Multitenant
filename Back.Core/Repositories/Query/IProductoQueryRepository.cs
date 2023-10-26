using Back.Core.Entities;
using Back.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Core.Repositories.Query
{
    public interface IProductoQueryRepository : IQueryRepository<Producto>
    {
        Task<List<Producto>> GetAllAsync();
        Task<Producto> GetProductoById(int id);
    }
}
