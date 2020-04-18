using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Database;
using JobSolution.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Repository.Concrete
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {   
        public StudentRepository(JobDbContext context) : base(context){ }

        //public async Task<IList<StudentJobDTO>> GetJobsForStudent(int StudentId)
        //{
        //    var result = _jobDbContext.StudentJobs
        //        .Where(x => x.Student.Id == StudentId)
        //        .Select(x => new StudentJobDTO()
        //        {
        //            AuthorName = x.Job.Author.FirstName,
        //            CategoryName = x.Job.Category.Category,
        //            City = x.Job.City,
        //            Contact = x.Job.Contact,
        //            Title = x.Job.Title,
        //            PostDate = x.Job.PostDate
        //        })
        //        .ToList();
        //    return result;
        //}

        public async Task<IIncludableQueryable<StudentJob,Job>> GetJobsForStudent(int studentId)
        {
            return _jobDbContext.StudentJobs.Include(x => x.Student).Include(x => x.Job);
        }

        public async Task<Student> GetStudent(int Id)
        {
            return _jobDbContext.Students.FirstOrDefault(x => x.Id == Id);
        }

        public async Task Update(Student student)
        {
            _jobDbContext.Update(student);
           await _jobDbContext.SaveChangesAsync();
        }

        public async Task<IList<Student>> GetAllStudents()
        {
            return _jobDbContext.Students.ToList();
        }

        public async Task Delete(Student stundent)
        {
             _jobDbContext.Students.Remove(stundent);
           await  _jobDbContext.SaveChangesAsync();
        }


    }
}
