﻿using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Interfaces
{
    public interface IUserService
    {
        Task<IList<StudentJobDTO>> GetAllJobsStudent(int StudentId);
        Task<StudentDTO> GetStudent(int StudentId);

    }
}