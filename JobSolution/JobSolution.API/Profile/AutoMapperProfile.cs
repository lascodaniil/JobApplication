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
            CreateMap<Job, JobDTO>().ForMember(x => x.PublishedOn, y => y.MapFrom(z => z.PostDate))
                                    .ForMember(x => x.FinishedOn, y => y.MapFrom(z => z.EndDate))
                                    .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Category))
                                    .ForMember(x => x.JobId, y => y.MapFrom(z => z.Id));


            CreateMap<JobDTO, Job>().ForMember(x => x.PostDate, y => y.MapFrom(z => z.PublishedOn))
                                    .ForMember(x => x.EndDate, y => y.MapFrom(z => z.FinishedOn))
                                    .ForMember(x => x.Category, y => y.Ignore());
                                    



            CreateMap<Categories, CategoryDTO>()
                .ForMember(x => x.Category, y => y.MapFrom(x => x.Category));
            CreateMap<Cities, CityDTO>()
                .ForMember(x => x.City, y => y.MapFrom(x => x.City));
        }
    }
}
