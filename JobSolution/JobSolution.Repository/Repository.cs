using JobSolution.Domain.Entities;
using JobSolution.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSolution.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly JobDbContext _jobDbContext;

        public Repository(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        public void Add(T entity)
        {
            _jobDbContext.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _jobDbContext.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return _jobDbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int Id)
        {
            var temporaryEntity = _jobDbContext.Set<T>().FirstOrDefault(x => x.Id == Id);
            if (temporaryEntity != null)
            {
                _jobDbContext.Set<T>().Remove(temporaryEntity);
                _jobDbContext.SaveChanges();
            }
        }

        public bool SaveAll()
        {
            _jobDbContext.SaveChanges();
            return true;
        }

        public void Update(T entity)
        {
            _jobDbContext.Entry(entity).State = EntityState.Modified;
            _jobDbContext.SaveChanges();
        }
    }
}
