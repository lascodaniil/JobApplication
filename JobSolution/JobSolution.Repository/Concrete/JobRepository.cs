using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Database;
using JobSolution.Infrastructure.Extensions;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobSolution.Repository.Concrete
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(AppDbContext context) : base(context) { }
        public async Task Delete(int JobId)
        {
            var Job =  _dbContext.Jobs.FirstOrDefault(x => x.Id == JobId);

            _dbContext.Jobs.Remove(Job);
            await  _dbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<Job>> GetJobs()
        {
            return _dbContext.Jobs;
        }

        public async Task<IQueryable<Job>> GetAllJobs()
        {
            return _dbContext.Jobs.Include(x => x.Category).Include(x=>x.Cities).Include(x=>x.User).Include(x=>x.User.Profile).Include(x=>x.TypeJob).Include(x=>x.Image).AsQueryable();
        }

        public async Task<Job> GetJobByID(int JobId)
        {
            return await _dbContext.Jobs.Include(x => x.Category).Include(x => x.Cities).Include(x => x.User).Include(x => x.User.Profile).Include(x => x.TypeJob).FirstOrDefaultAsync(x => x.Id == JobId);
        }
        
        public async Task Update(Job job)
        {

           _dbContext.Jobs.Update(job);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Add(Job job)
        {
            _dbContext.Jobs.AddAsync(job);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }


        public async Task<Job> GetByIdWithInclude(int id, params Expression<Func<Job, object>>[] includeProperties) 
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        private IQueryable<Job> IncludeProperties(params Expression<Func<Job, object>>[] includeProperties) 
        {
            IQueryable<Job> entities = _dbContext.Set<Job>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }
        public async Task<PaginatedResult<JobForTableDTO>> GetPagedData(PagedRequest pagedRequest, IMapper mapper)
        {
            return await _dbContext.Set<Job>().CreatePaginatedResultAsync<Job, JobForTableDTO>(pagedRequest, mapper);
        }

        public async Task<PaginatedResult<JobForTableDTO>> GetPagedData(PagedRequest pagedRequest, IMapper mapper, int UserId)
        {
            var result = _dbContext.Set<Job>().Where(x => x.UserId == UserId).CreatePaginatedResultAsync<Job, JobForTableDTO>(pagedRequest, mapper, UserId);
            
            return await result;
        }

        public async Task<PaginatedResult<JobForTableDTO>> GetPagedDataStudent(PagedRequest pagedRequest, IMapper mapper, int UserId)

        {
            var studentJobs = _dbContext.Set<StudentJobs>().Where(x => x.UserId == UserId).Select(x => x.JobId).ToList();
            var result = _dbContext.Set<Job>().Where(x => studentJobs.Contains(x.Id)).CreatePaginatedResultAsync<Job, JobForTableDTO>(pagedRequest, mapper, UserId);
            return await result;

            
        }

        public async Task<PaginatedResult<JobForViewDTO>> GetPagedDataByType(PagedRequest pagedRequest, IMapper mapper, int typeId)
        {
            var result = _dbContext.Set<Job>().Where(x => x.TypeJobId == typeId).CreatePaginatedResultAsync<Job, JobForViewDTO>(pagedRequest, mapper, typeId);

            return await result;
        }

        
    }
}
