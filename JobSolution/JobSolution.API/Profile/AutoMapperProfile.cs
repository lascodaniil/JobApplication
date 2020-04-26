using JobSolution.Domain;
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
           CreateMap<Job, JobDTO>().ForMember(x => x.CategroyName, y => y.MapFrom(z => z.Category.Category))
                .ForMember(x => x.UserName, y => y.MapFrom(y => y.User.Email)).ForMember(x=>x.ProfileId, y=>y.MapFrom(y=>y.UserId));
           
           
            CreateMap<Job, JobGridRowDTO>().ForMember(x => x.Category, y => y.MapFrom(x => x.Category.Category))
                                       .ForMember(x => x.Employer, y => y.MapFrom(z => z.User.Email));
            CreateMap<JobDTO, Job>();
            CreateMap<JobForPostdDTO, Job>().ForMember(x => x.Base64Photo, y => y.MapFrom(y => y.Base64Photo));

            CreateMap<JobSolution.Domain.Entities.Profile, StudentProfileDTO>()
                .ForMember(x => x.Base64Photo, y => y.MapFrom(z => z.Base64Photo))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            CreateMap<JobSolution.Domain.Entities.Profile, EmployerPofileDTO>()
                .ForMember(x => x.Base64Photo, y => y.MapFrom(z => z.Base64Photo))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));



        }
    }
}

