using JobSolution.Domain.Auth;
using JobSolution.Domain.Entities;
using JobSolution.Infrastructure.Database;
using JobSolution.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Repository.Concrete
{
   public class StudentJobRepository : Repository<JobStudent>, IStudentJobRepository
   {
        public StudentJobRepository(AppDbContext context) : base(context) { }

        public  async Task Add(int UserId, int jobId)
        {
             _dbContext.JobStudents.Add(new JobStudent { JobId = jobId, UserId = UserId });
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int UserId, int jobId)
        {
            var record = await _dbContext.JobStudents.FirstOrDefaultAsync(x => x.UserId == UserId && x.JobId == jobId);
            _dbContext.JobStudents.Remove(record);
            await _dbContext.SaveChangesAsync();
        }
    }
}
