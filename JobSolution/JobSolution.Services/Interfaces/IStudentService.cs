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
        Task SaveAll();
    }




    //Task<IEnumerable<Job>> GetAll();
    //Task<Job> GetByID(int id);
    //Task Add(Job entity);
    //Task Update(Job entity);
    //Task Remove(int Id);
    //Task SaveAll();


}
