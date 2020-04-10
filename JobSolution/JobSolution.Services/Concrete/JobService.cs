using JobSolution.Domain.Entities;
using JobSolution.Repository;
using JobSolution.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    // de mapat aici 
    public class JobService : IJobService
    {
        private readonly IRepository<Job> _jobRepository;
        public JobService(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task Add(Job entity)
        {
            await _jobRepository.Add(entity);
            await _jobRepository.SaveAll();
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _jobRepository.GetAll(); // dto de returnat, 
        }

        public async Task<Job> GetByID(int id)
        {
            return await _jobRepository.GetByID(id);
        }

        public async Task Remove(int Id)
        {
            var job = _jobRepository.GetByID(Id);
            if (job != null)
            {
                await _jobRepository.Remove(Id);
                await _jobRepository.SaveAll();
            }
        }

        public async Task SaveAll()
        {
            await _jobRepository.SaveAll();
        }

        public async Task Update(Job entity)
        {
            await _jobRepository.Update(entity);
        }
    }
}
