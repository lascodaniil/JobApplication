using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Repository.Interfaces
{
    public interface IStudentRepository 
    {
        // Task<IList<StudentJobDTO>> GetJobsForStudent(int studentId);
        Task<IIncludableQueryable<StudentJob, Job>> GetJobsForStudent(int studentId);
        Task<IList<Student>> GetAllStudents();
        Task<Student> GetStudent(int id);
        Task Update(Student student);
        Task Delete(Student stundetDTO);
    }
}
