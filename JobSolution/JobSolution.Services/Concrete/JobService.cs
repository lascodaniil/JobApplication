using JobSolution.Domain.Entities;
using JobSolution.Repository;
using JobSolution.Services.Interfaces;
using System;
using System.Collections.Generic;

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

        public void Add(Job entity)
        {
             _jobRepository.Add(entity);
             _jobRepository.SaveAll();
        }

        public IEnumerable<Job> GetAll()
        {
            return  _jobRepository.GetAll(); // dto de returnat, 
        }

        public  Job GetByID(int id)
        {
            return _jobRepository.GetByID(id);
        }

        public void Remove(int Id)
        {
            var job = _jobRepository.GetByID(Id);
            if (job != null)
            {
                 _jobRepository.Remove(Id);
                 _jobRepository.SaveAll();
            }
        }

        public bool SaveAll()
        {
            _jobRepository.SaveAll();
            return true;
        }

        public void Update(Job entity)
        {
            _jobRepository.Update(entity);
        }
    }
}
