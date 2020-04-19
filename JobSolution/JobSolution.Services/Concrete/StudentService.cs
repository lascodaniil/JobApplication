using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Repository;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentDal, IMapper mapper)
        {
            _studentRepository = studentDal;
            _mapper = mapper;
        }
        public async Task<IList<StudentJobDTO>> GetAllJobsStudent(int StudentId)
        {
            var StudentsJobs = await _studentRepository.GetJobsForStudent(StudentId);
            var StudentJobsDTO = StudentsJobs.Where(x => x.StudentId == StudentId)
                .Select(x => new StudentJobDTO()
                {
                    AuthorName = x.Job.Employer.Name,
                    CategoryName = x.Job.Category.Category,
                    City = x.Job.City,
                    Contact = x.Job.Contact,
                    Title = x.Job.Title,
                    PostDate = x.Job.PostDate
                }).ToList();

            return StudentJobsDTO;


            //var Jobs = await _studentRepository.GetByIdWithInclude(StudentId, x => x.Employer.Email, y => y.Category.Category);
            //List<StudentJobDTO> students = _mapper.Map<IList<Job> , List<StudentJobDTO>>(Jobs);
            //return students;
        }

        public async Task<StudentDTO> GetStudent(int StudentId)
        {
            var student = await _studentRepository.GetStudent(StudentId);
            var studentMap = _mapper.Map<StudentDTO>(student);
            return studentMap;
        }
    }
}


