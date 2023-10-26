using Back.Core.Repositories.Command.Base;
using Back.Infraestructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Repositories.Command.Base
{
    public class CommandRepository<T> : DbConector,ICommandRepository<T> where T : class
    {
        protected readonly AdminContext _managerContext;

        protected CommandRepository(IConfiguration configuration, AdminContext managerContext, ApplicationDbContext autosaContext) : base(configuration, managerContext, autosaContext)
        {
            _managerContext = managerContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _managerContext.Set<T>().AddAsync(entity);
                await _managerContext.SaveChangesAsync();
                return entity;
            }

            catch(Exception ex)
            {
                return null;
            }
           
        }

        public async Task DeleteAsync(T entity)
        {
            _managerContext.Set<T>().Remove(entity);
            await _managerContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            //_managerContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _managerContext.Update(entity);
            await _managerContext.SaveChangesAsync();
            return entity;
        }
    }
}
