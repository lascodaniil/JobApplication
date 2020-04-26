﻿using JobSolution.Domain;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Database;
using JobSolution.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Repository.Concrete
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {   
        public ProfileRepository(AppDbContext context) : base(context){ }

        public Task<IList<EmployerPofileDTO>> GetEmployerProfile([FromBody]UserForLoginDto credentialsDTO)
        {

              return null;
        }
    

        public Task<IList<StudentProfileDTO>> GetStudentProfile(UserForLoginDto credentialsDTO)
        {
            throw new NotImplementedException();
        }
    }
}
