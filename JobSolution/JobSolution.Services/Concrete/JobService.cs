using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Repository;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task Add(JobForPostdDTO entity)
        {
            var jobDTO = _mapper.Map<Job>(entity);
            await _jobRepository.Add(jobDTO);
            _jobRepository.SaveAll();
        }

        public async Task<IList<JobDTO>> GetAll()
        {
            var Jobs = await _jobRepository.GetAllJobs();
            var JobsListDTO = _mapper.Map<IQueryable<Job>, IList<JobDTO>>(Jobs);   

            return JobsListDTO;
        }

        public async Task<JobDTO> GetByID(int id)
        {
            var toReturn = await _jobRepository.GetJobByID(id);
            return _mapper.Map<JobDTO>(toReturn);
        }

        public async Task Update(JobForPostdDTO job, int id) {

            var dbentity = await _jobRepository.GetJobByID(id);
            dbentity.Base64Photo = job.Base64Photo;
            dbentity.CategoryId = job.CategoryId;
            dbentity.Contact = job.Contact;
            dbentity.EndDate = job.StopDate;
            dbentity.Id = id;
            dbentity.UserId = job.UserId;
            dbentity.Title = job.Title;
            dbentity.Salary = job.Salary;
            await _jobRepository.Update(dbentity);
        
        }
        public async Task Remove(int JobId) {
            
            await _jobRepository.Delete(JobId);
        }

        public async Task<IList<JobDTO>> GetJobsByCategory(string category)
        {
            var result = await GetAll();
            return result.Where(x => x.CategroyName == category).ToList();
          
        }

        public async Task<PaginatedResult<JobGridRowDTO>> GetPagedData(PagedRequest pagedRequest, IMapper mapper) 
        {
            return await _jobRepository.GetPagedData(pagedRequest, mapper);
        }

    }
}
