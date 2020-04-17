using JobSolution.Domain.Entities;
using JobSolution.Repository;
using JobSolution.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student GetUserProfile(int id)
        {
            var studentProfile = _studentRepository.GetByID(id);
            if (studentProfile != null)
            {
                return studentProfile.Result;
            }
            return null;
        }

        public Task<IEnumerable<Job>> GetAllJobsStudent(int id)
        {
            var student = GetUserProfile(id);
            if (student!=null)
            {

            }
        }



        public void SaveAll()
        {
            _studentRepository.SaveAll();
        }

        Task<Student> IStudentService.GetUserProfile(int id)
        {
            throw new NotImplementedException();
        }
    }
}
