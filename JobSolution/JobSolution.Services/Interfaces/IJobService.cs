using JobSolution.Domain.Entities;
using JobSolution.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAll();
        Task<Job> GetByID(int id);
        Task Add(Job entity);
        Task Update(Job entity);
        Task Remove(int Id);
        Task SaveAll();
    }
}
