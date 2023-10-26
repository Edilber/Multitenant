using Back.Core.Entities;
using Back.Core.Repositories.Query;
using Back.Infraestructure.Data;
using Back.Infraestructure.Repositories.Query.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Repositories.Query
{
    public class ProductoQueryRepository : QueryRepository<Producto>, IProductoQueryRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductoQueryRepository(IConfiguration configuration, AdminContext context, ApplicationDbContext app) : base(configuration, context, app)
        {
            
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            var productos = await _context.Producto.ToListAsync();
            return productos;
        }

        public async Task<Producto> GetProductoById(int id)
        {
            var producto = await _context.Producto.Where(c => c.ProductoId == id).FirstOrDefaultAsync();
            return producto;
        }
    }
}
