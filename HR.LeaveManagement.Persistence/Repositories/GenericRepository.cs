using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.common;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected HRDatabaseContext _hrContext;

        public GenericRepository(HRDatabaseContext hrContext)
        {
              _hrContext = hrContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _hrContext.AddAsync(entity);
            await _hrContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _hrContext.Remove(entity);
            await _hrContext.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await _hrContext.Set<T>().AsNoTracking().ToListAsync();
        }

   


        public async Task<T> GetAsync(int id)
        {
            return await _hrContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task UpdateAsync(T entity)
        {
            _hrContext.Update(entity);
            _hrContext.Entry(entity).State = EntityState.Modified;
            await _hrContext.SaveChangesAsync();
        }
    }
}
