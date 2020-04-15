using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using JobSolution.Repository;

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
