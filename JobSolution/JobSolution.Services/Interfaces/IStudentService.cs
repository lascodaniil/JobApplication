using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentJobDTO>> GetAllJobsStudent(int StudentId);
        Task<StudentDTO> GetStudent(int StudentId);
    }
}
