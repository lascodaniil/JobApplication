using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.API.Profile
{
    public class JobProfile : AutoMapper.Profile
    {   
        public JobProfile()
        {
            CreateMap<JobDTO, Job>();
            CreateMap<Job, JobDTO>();
        }
    }
}
