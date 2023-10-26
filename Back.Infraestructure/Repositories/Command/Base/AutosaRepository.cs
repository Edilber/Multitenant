using Back.Core.Repositories.Command.Base;
using Back.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Repositories.Command.Base
{
    public class AutosaRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public AutosaRepository(ApplicationDbContext managerContext)
        {
            _context = managerContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
