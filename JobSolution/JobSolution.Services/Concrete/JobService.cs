using AutoMapper;
using JobSolution.Domain.Auth;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Repository;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _context;

        public JobService(IJobRepository jobRepository, IMapper mapper, IHttpContextAccessor context)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task Add(JobDTO entity)
        {
            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value); 
            var job = _mapper.Map<Job>(entity);
            job.UserId = UserId;
            job.PostDate = DateTime.Now;
            await _jobRepository.Add(job);
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
        
        public async Task Update(JobDTO job, int id) {

            var userId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
            var dbentity = await _jobRepository.GetJobByID(id);
            
            dbentity.Base64Photo = job.Base64Photo;
            dbentity.CategoryId = job.CategoryId;
            dbentity.CityId = job.CityId;
            dbentity.Contact = job.Contact;
            dbentity.EndDate = job.FinishedOn;
            dbentity.Id = id;
            dbentity.UserId = userId;
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
            return result.Where(x => x.Category == category).ToList();
          
        }

        public async Task<PaginatedResult<JobDTO>> GetPagedData(PagedRequest pagedRequest, IMapper mapper) 
        {
            return await _jobRepository.GetPagedData(pagedRequest, mapper);
        }

        public async Task<PaginatedResult<JobDTO>> GetJobsForEmployer(PagedRequest pagedRequest, IMapper mapper)
        {
            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
            var result = await _jobRepository.GetPagedData(pagedRequest, mapper, UserId);
            return  result;
        }

    }
}
