using JobSolution.Domain.Entities;
using JobSolution.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly JobDbContext _jobDbContext;

        public Repository(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        public async Task Add(T entity)
        {
            _jobDbContext.Set<T>().Add(entity);
            await _jobDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _jobDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            return await _jobDbContext.Set<T>().FindAsync(id);
        }

        public async Task Remove(int Id)
        {
            var temporaryEntity = await _jobDbContext.Set<T>().FindAsync(Id);
            if (temporaryEntity != null)
            {
                _jobDbContext.Set<T>().Remove(temporaryEntity);
                await _jobDbContext.SaveChangesAsync();
            }
        }

        public async Task SaveAll()
        {
            await _jobDbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _jobDbContext.Entry(entity).State = EntityState.Modified;
            await _jobDbContext.SaveChangesAsync();
        }
    }
}
