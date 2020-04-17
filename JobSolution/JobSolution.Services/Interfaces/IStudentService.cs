using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetUserProfile(int id);
        void SaveAll();
        Task<IEnumerable<Job>> GetAllJobsStudent();
        

    }

}
