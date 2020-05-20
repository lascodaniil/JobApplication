﻿using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;


namespace JobSolution.API.Profile
{
    public class AutoMapperProfile : AutoMapper.Profile
    {   
        public AutoMapperProfile()
        {
            CreateMap<Job, JobDTO>().ForMember(x => x.PublishedOn, y => y.MapFrom(z => z.PostDate))
                                    .ForMember(x => x.FinishedOn, y => y.MapFrom(z => z.EndDate))
                                    .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Category))
                                    .ForMember(x => x.JobId, y => y.MapFrom(z => z.Id))
                                    .ForMember(x => x.Employer, y => y.MapFrom(x => x.User.Profile.FirstName + " " + x.User.Profile.LastName))
                                    .ForMember(x => x.City, y => y.MapFrom(x => x.Cities.City))
                                    .ForMember(x => x.TypeJob, y => y.MapFrom(x => x.TypeJob.Name))
                                    .ForMember(x => x.Image, y => y.Ignore())
                                    .ForMember(x => x.ImagePath, y => y.MapFrom(z => z.Image.Path));


            CreateMap<JobDTO, Job>().ForMember(x => x.PostDate, y => y.MapFrom(z => z.PublishedOn))
                                    .ForMember(x => x.EndDate, y => y.MapFrom(z => z.FinishedOn))
                                    .ForMember(x => x.Category, y => y.Ignore());




        //      public int CategoryId { get; set; }
        //public string Title { get; set; }
        //public string Contact { get; set; }
        //public string Description { get; set; }
        //public DateTime? PostDate { get; set; } = DateTime.Now;
        //public DateTime? EndDate { get; set; }
        //public DateTime? EnrolledDate { get; set; }
        //public float Salary { get; set; }
        //[ForeignKey("Cities")]
        //public int CityId { get; set; }
        //public Cities Cities { get; set; }

        //public Categories Category { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        //[ForeignKey("TypeJob")]
        //public int TypeJobId { get; set; }
        //public TypeJob TypeJob { get; set; }
        //[ForeignKey("Image")]
        //public int? ImageId { get; set; }
        //public Image Image { get; set; }


        CreateMap<Job, JobForTableDTO>().ForMember(x=>x.JobId, y=>y.MapFrom(z=>z.Id))
                .ForMember(x=>x.Title, y=>y.MapFrom(Z=>Z.Title))
                .ForMember(x=>x.Category, y=>y.MapFrom(y=>y.Category.Category))
                .ForMember(x=>x.City, y=>y.MapFrom(y=>y.Cities.City))
                .ForMember(x=>x.Employer, y=>y.MapFrom(y=>y.User.Profile.FirstName + " " + y.User.Profile.LastName))
                .ForMember(x=>x.TypeJob, y=>y.MapFrom(y=>y.TypeJob.Name))
                .ForMember(x=>x.Contact, y=>y.MapFrom(z=>z.Contact))
                .ForMember(x=>x.FinishedOn, y=>y.MapFrom(z=>z.EndDate))
                .ForMember(x => x.Image, y => y.Ignore())
                .ForMember(x => x.ImagePath, y => y.MapFrom(z => z.Image.Path));



            CreateMap<Job, JobForViewDTO>().ForMember(x => x.JobId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(Z => Z.Title))
                .ForMember(x => x.Category, y => y.MapFrom(y => y.Category.Category))
                .ForMember(x => x.City, y => y.MapFrom(y => y.Cities.City))
                .ForMember(x => x.Employer, y => y.MapFrom(y => y.User.Profile.FirstName + " " + y.User.Profile.LastName))
                .ForMember(x => x.TypeJob, y => y.MapFrom(y => y.TypeJob.Name))
                .ForMember(x => x.Contact, y => y.MapFrom(z => z.Contact))
                .ForMember(x => x.FinishedOn, y => y.MapFrom(z => z.EndDate))
                .ForMember(x => x.ImagePath, y => y.MapFrom(z => z.Image.Path));







            CreateMap<JobForTableDTO, Job>().ForMember(x => x.PostDate, y => y.MapFrom(z => z.PublishedOn))
                                  .ForMember(x => x.EndDate, y => y.MapFrom(z => z.FinishedOn))
                                  .ForMember(x => x.Category, y => y.Ignore());

















            CreateMap<Advert, AdvertDTO>().ForMember(x => x.AdvertId, y => y.MapFrom(y => y.Id))
                                          .ForMember(x => x.City, y => y.MapFrom(z => z.Cities.City))
                                          .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Category))
                                          .ForMember(x => x.City, y => y.MapFrom(z => z.Cities.City))
                                          .ForMember(x => x.PublishedOn, y => y.MapFrom(z => z.PostDate));
            
            CreateMap<AdvertDTO, Advert>().ForMember(x => x.Id, y => y.MapFrom(x => x.AdvertId))
                .ForMember(x => x.Category, y => y.Ignore());

            CreateMap<TypeJob, TypeJobDTO>();

            CreateMap<JobSolution.Domain.Entities.Profile, ProfileDTO>()
                .ForMember(x => x.ImagePath, y => y.MapFrom(z => z.Image.Path))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.RegistrationDate, y => y.MapFrom(x => x.RegisterDate))
                .ForMember(x => x.FullName, y => y.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(x=>x.DateOfBirth, y=>y.MapFrom(x=>x.DateOfBirth));


            CreateMap<UserRegisterDto, JobSolution.Domain.Entities.Profile>()
                .ForMember(x => x.DateOfBirth, x => x.MapFrom(y => y.DateOfBirth))
                .ForMember(x => x.Email, x => x.MapFrom(x => x.Email))
                .ForMember(x => x.FirstName, y => y.MapFrom(y => y.FirstName))
                .ForMember(x => x.ImagePath, y => y.MapFrom(y => y.ImagePath))
                .ForMember(x => x.LastName, y => y.MapFrom(y => y.LastName))
                .ForMember(x => x.DateOfBirth, y => y.Ignore())
                .ForMember(x=>x.PhoneNumber, y=>y.Ignore());

            CreateMap<JobSolution.Domain.Entities.Profile, UserRegisterDto>();
                
            CreateMap<Categories, CategoryDTO>()
                .ForMember(x => x.Category, y => y.MapFrom(x => x.Category));
            CreateMap<Cities, CityDTO>()
                .ForMember(x => x.City, y => y.MapFrom(x => x.City));
        }
    }
}
