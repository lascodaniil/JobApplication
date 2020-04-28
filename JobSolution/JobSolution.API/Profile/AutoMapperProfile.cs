﻿using JobSolution.Domain;
using JobSolution.Domain.Auth;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.API.Profile
{
    public class AutoMapperProfile : AutoMapper.Profile
    {   
        public AutoMapperProfile()
        {
            CreateMap<Job, JobGridRowDTO>().ForMember(x => x.Category, y => y.MapFrom(x => x.Category.Category))
                                           .ForMember(x => x.Employer, y => y.MapFrom(z => z.User.Email))
                                           .ForMember(x => x.City, y => y.MapFrom(z => z.Cities.City))
                                           .ForMember(x => x.JobId, y => y.MapFrom(x => x.Id));

            
            CreateMap<JobDTO, JobGridRowDTO>().ForMember(x => x.Category, y => y.MapFrom(x => x.CategoryName))
                                           .ForMember(x => x.Employer, y => y.MapFrom(z => z.UserName))
                                           .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                                           .ForMember(x => x.JobId, y => y.MapFrom(x => x.Id));




            CreateMap<JobGridRowDTO, Job>();

            CreateMap<Job, JobDTO>()
               .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.Category))
               .ForMember(x => x.UserName, y => y.MapFrom(y => y.User.Email))
               .ForMember(x => x.City, y => y.MapFrom(y => y.Cities.City));


            CreateMap<JobDTO, JobForPostdDTO>();
                





            CreateMap<JobDTO, Job>();
            CreateMap<JobForPostdDTO, Job>().ForMember(x => x.Base64Photo, y => y.MapFrom(y => y.Base64Photo))
                .ForMember(x => x.CategoryId, y => y.MapFrom(y => y.CategoryId))
                .ForMember(x => x.CityId, y => y.MapFrom(y => y.CityId));
            
            CreateMap<JobSolution.Domain.Entities.Profile, StudentProfileDTO>()
                .ForMember(x => x.Base64Photo, y => y.MapFrom(z => z.Base64Photo))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            CreateMap<JobSolution.Domain.Entities.Profile, EmployerProfileDTO>()
                .ForMember(x => x.Base64Photo, y => y.MapFrom(z => z.Base64Photo))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.RegistrationDate, y => y.MapFrom(x => x.RegisterDate));


            CreateMap<Categories, CategoryDTO>()
                .ForMember(x => x.Category, y => y.MapFrom(x => x.Category));

            CreateMap<Cities, CityDTO>()
                .ForMember(x => x.City, y => y.MapFrom(x => x.City));

        }
    }
}
