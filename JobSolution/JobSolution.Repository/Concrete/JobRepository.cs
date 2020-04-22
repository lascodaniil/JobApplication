using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Database;
using JobSolution.Infrastructure.Extensions;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Repository.Concrete
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(JobDbContext context) : base(context) { }
        public async Task Delete(int JobId)
        {
            var Job = await _jobDbContext.Jobs.FirstOrDefaultAsync(x => x.Id == JobId);

             _jobDbContext.Jobs.Remove(Job);
             await _jobDbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<Job>> GetJobs()
        {
            return _jobDbContext.Jobs;
        }


        public async Task<IQueryable<Job>> GetAllJobs()
        {
            return _jobDbContext.Jobs.Include(x => x.Employer).Include(x => x.Category).AsQueryable();
        }

        public async Task<Job> GetJobByID(int JobId)
        {
            return await _jobDbContext.Jobs.FirstOrDefaultAsync(x => x.Id == JobId);
        }
        
        public async Task Update(Job job)
        {
             _jobDbContext.Jobs.Update(job);
            await _jobDbContext.SaveChangesAsync();
        }

        public async Task Add(Job job)
        {
            _jobDbContext.Jobs.Add(job);
            await _jobDbContext.SaveChangesAsync();
        }
        public async Task<bool> SaveAll()
        {
            return await _jobDbContext.SaveChangesAsync() > 0;
        }


        public async Task<Job> GetByIdWithInclude(int id, params Expression<Func<Job, object>>[] includeProperties) 
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        private IQueryable<Job> IncludeProperties(params Expression<Func<Job, object>>[] includeProperties) 
        {
            IQueryable<Job> entities = _jobDbContext.Set<Job>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }

        public async Task<PaginatedResult<JobGridRowDTO>> GetPagedData(PagedRequest pagedRequest, IMapper mapper)
        {
            return await _jobDbContext.Set<Job>().CreatePaginatedResultAsync<Job, JobGridRowDTO>(pagedRequest, mapper);
        }

        
    }
}
