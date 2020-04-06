using JobSolution.Domain.Entities;
using JobSolution.Repository;
using JobSolution.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class JobService : IJobService
    {
        private IRepository<Job> _jobRepository;
        public JobService(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task Add(Job entity)
        {
            await _jobRepository.Add(entity);
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _jobRepository.GetAll();
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
                _jobRepository.Remove(Id);
                _jobRepository.SaveAll();
            }
        }

        public async Task SaveAll()
        {
            await _jobRepository.SaveAll();
        }

        public async Task Update(Job entity)
        {
            _jobRepository.Update(entity);
        }
    }
}
