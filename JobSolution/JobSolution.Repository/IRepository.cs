using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int Id);
        bool SaveAll();
    }
}
