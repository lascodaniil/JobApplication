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
            var student =  _studentRepository.GetByID(id);
            return student;
        }

        public void SaveAll()
        {
            _studentRepository.SaveAll();
        }
    }
}
