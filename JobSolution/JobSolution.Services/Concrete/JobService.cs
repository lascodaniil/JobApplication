using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Repository;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task Add(JobDTO entity)
        {
            var jobDTO = _mapper.Map<Job>(entity);
            await _jobRepository.Add(jobDTO);
            _jobRepository.SaveAll();
        }

        public async Task<IList<JobDTO>> GetAll()
        {
            var Jobs = await _jobRepository.GetAllJobs();
            var JobsListDTO = Jobs.Select(x => new JobDTO
            {
                EmployerEmail = x.Employer.Email,
                CategoryName = x.Category.Category,
                Base64Photo = x.Base64Photo,
                Title=x.Title,
                City=x.City,
                Contact=x.Contact,
                Id=x.Id,
                EmployerId=x.Id,
                CategoryId = x.CategoryId
            }).ToList();    

            return JobsListDTO;
        }

        public async Task<JobDTO> GetByID(int id)
        {
            var toReturn = await _jobRepository.GetJobByID(id);
            return _mapper.Map<JobDTO>(toReturn);
        }

        public async Task Update(JobDTO job) {

            await _jobRepository.Update(_mapper.Map<Job>(job));
           
        }
        public async Task Remove(int JobId) {
            
            await _jobRepository.Delete(JobId);
        }

      



        //public async Task<IQueryable<StudentJobDTO>> GetAllJobsStudent(int StudentId)
        //{
        //    var StudentsJobs = await _studentRepository.GetJobsForStudent(StudentId);
        //    var StudentJobsDTO = StudentsJobs.Where(x => x.StudentId == StudentId)
        //        .Select(x => new StudentJobDTO()
        //        {
        //            AuthorName = x.Job.Author.FirstName,
        //            CategoryName = x.Job.Category.Category,
        //            City = x.Job.City,
        //            Contact = x.Job.Contact,
        //            Title = x.Job.Title,
        //            PostDate = x.Job.PostDate
        //        }).AsQueryable();

        //    return StudentJobsDTO;
        //}



        //public async Task<IList<JobDTO>> GetAll()
        //{
        //    IQueryable<Job> JobsList = await  _jobRepository.GetAllJobs();
        //    //var JobListDTO = JobsList.Select(x => new JobDTO()
        //    //{
        //    //    City = x.City,
        //    //    EmployerEmail = x.Employer.Email,
        //    //    Title = x.Title,
        //    //    Contact = x.Contact,
        //    //    CategoryName = x.Category.Category,
        //    //    Base64Photo = x.Base64Photo,
        //    //    CategoryId = x.CategoryId,
        //    //    EmployerId = x.EmployerId,
        //    //}).ToList();






        //      return JobListDTO;
        //}





    }
}
