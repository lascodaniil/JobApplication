﻿using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Repository.Interfaces
{
    public interface IStudentRepository 
    {
        Task<IIncludableQueryable<StudentJob, Job>> GetJobsForStudent(int studentId);
        Task<IList<Student>> GetAllStudents();
        Task<Student> GetStudent(int id);
        Task Update(Student student);
        Task Delete(Student stundetDTO);
        Task<bool> SaveAll();

        //Task<IList<Job>> GetByIdWithInclude(int id, params Expression<Func<Job, object>>[] includeProperties);

    }
}
