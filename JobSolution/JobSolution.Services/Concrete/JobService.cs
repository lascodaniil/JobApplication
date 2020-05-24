using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IStudentJobService _studentJobService;
        private readonly IServiceImage _serviceImage;

        public JobService(IJobRepository jobRepository,
            IMapper mapper, IHttpContextAccessor context,
            IHostingEnvironment hostingEnvironment,
            IStudentJobService studentJobService,
            IServiceImage serviceImage)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _studentJobService = studentJobService;
            _serviceImage = serviceImage;
        }

        public async Task Add(JobForTableDTO jobDTO)
        {
            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
            Job job = new Job();
            IFormFile file = jobDTO.Image;
            string fullPath = null;
            var imageId = 0;

            if (file != null)
            {
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                if (string.IsNullOrWhiteSpace(webRootPath))
                {
                    webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                string newPath = Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                imageId = _serviceImage.GetIdInsertedImage(fullPath);
                job.ImageId = imageId;
            }


            job.UserId = UserId;
            job.PostDate = DateTime.Now;
            job.CategoryId = jobDTO.CategoryId;
            job.CityId = jobDTO.CityId;
            job.Title = jobDTO.Title;
            job.Salary = jobDTO.Salary;
            job.TypeJobId = jobDTO.TypeJobId;
            job.EndDate = jobDTO.FinishedOn;
            job.Contact = jobDTO.Contact;
        
            await _jobRepository.Add(job);

        }

        public async Task<IList<JobForTableDTO>> GetAll()
        {
            var Jobs = await _jobRepository.GetAllJobs();
            var JobsListDTO = _mapper.Map<IQueryable<Job>, IList<JobForTableDTO>>(Jobs);
            return JobsListDTO;
        }
        public async Task<JobForTableDTO> GetByID(int id)
        {
            var toReturn = await _jobRepository.GetJobByID(id);
            return _mapper.Map<JobForTableDTO>(toReturn);
        }

        public async Task Update(JobForTableDTO jobDTO, int id)
        {

            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);

            IFormFile file = jobDTO.Image;
            string fullPath = null;
            var imageId = 0;
            Job job = await _jobRepository.GetJobByID(id);


            if (file != null)
            {
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                if (string.IsNullOrWhiteSpace(webRootPath))
                {
                    webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                string newPath = Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                imageId = _serviceImage.GetIdInsertedImage(fullPath);
                job.ImageId = imageId;
            }


            job.UserId = UserId;
            job.PostDate = DateTime.Now;
            job.CategoryId = jobDTO.CategoryId;
            job.CityId = jobDTO.CityId;
            job.Title = jobDTO.Title;
            job.Salary = jobDTO.Salary;
            job.TypeJobId = jobDTO.TypeJobId;
            job.EndDate = jobDTO.FinishedOn;
            job.Contact = jobDTO.Contact;

            await _jobRepository.Update(job);

        }
        public async Task Remove(int JobId)
        {
            await _jobRepository.Delete(JobId);
        }


        public async Task<PaginatedResult<JobForTableDTO>> GetPagedData(PagedRequest pagedRequest, IMapper mapper)
        {
            var result = await _jobRepository.GetPagedData(pagedRequest, mapper);
            return result;
        }

        public async Task<PaginatedResult<JobForTableDTO>> GetJobsForEmployer(PagedRequest pagedRequest, IMapper mapper)
        {
            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
            var result = await _jobRepository.GetPagedData(pagedRequest, mapper, UserId);
            return result;
        }

        public async Task<PaginatedResult<JobForTableDTO>> GetJobsForStudent(PagedRequest pagedRequest, IMapper mapper)
        {
            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
           
            var result = await _jobRepository.GetPagedDataStudent(pagedRequest, mapper, UserId);
            return result;
        }

        public async Task<IList<JobForTableDTO>> GetByType(int TypeId)
        {
            var AllJobs = await _jobRepository.GetAllJobs();
            var JobsList = AllJobs.Where(x => x.TypeJobId == TypeId);
            var result = _mapper.Map<IQueryable<Job>, IList<JobForTableDTO>>(JobsList);
            return result;
        }

        public async Task<PaginatedResult<JobForViewDTO>> GetJobsByType(PagedRequest pagedRequest, IMapper mapper, int typeId)
        {
            var result = await _jobRepository.GetPagedDataByType(pagedRequest, mapper, typeId);
            return result;
        }

        public async Task AddedJobByStudent(int id)
        {
            await _studentJobService.Add(id);
        }
        public async Task DeleteJobStudent(int id)
        {
            await _studentJobService.Delete(id);
        }

        public async Task<PaginatedResult<JobForViewDTO>> GetJobsByJobTypeId(PagedRequest pagedRequest, IMapper mapper, int JobTypeId)
        {
            var result = await _jobRepository.GetPagedDataByType(pagedRequest, mapper, JobTypeId);
            return result;
        }

       
    }
}
