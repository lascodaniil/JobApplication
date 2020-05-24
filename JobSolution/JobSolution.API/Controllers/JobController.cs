using AutoMapper;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Threading.Tasks;

namespace JobSolution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;
        private readonly ITypeJobService _typeJobService;
        private readonly IMapper _mapper;
        private readonly IRepositoryImage _repositoryImage;

        public JobController(IJobService repositoryJob, ICategoryService categoryService,
            ICityService cityService,
            ITypeJobService typeJobService,
            IMapper mapper,
            IRepositoryImage repositoryImage)
        {
            _cityService = cityService;
            _categoryService = categoryService;
            _jobService = repositoryJob;
            _mapper = mapper;
            _typeJobService = typeJobService;
            _repositoryImage = repositoryImage;
        }

        [HttpGet("Categories")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategries()
        {
            return Ok(await _categoryService.GetCategories());
        }

        [HttpGet("City")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await _cityService.GetCities());
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var JobsFromRepo = _jobService.GetAll().Result.ToList();
            return Ok(JobsFromRepo);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var obj = await _jobService.GetByID(id);
            return Ok(obj);
        }

        [HttpPost("Type/{TypeId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByType([FromBody] PagedRequest pagedRequest, int TypeId)
        {
            var jobsType = await _jobService.GetJobsByType(pagedRequest, _mapper, TypeId);
            return Ok(jobsType);
        }

        [HttpGet("Types")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTypes()
        {
            var jobs = await _typeJobService.GetTypeJobs();
            return Ok(jobs);
        }

        [HttpPost("Post")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Post([FromForm] JobForTableDTO JobDTO)
        {

            if (ModelState.IsValid)
            {
                await _jobService.Add(JobDTO);
                return Ok();
            }
            return BadRequest();
            
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobService.Remove(id);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Update([FromForm] JobForTableDTO jobDTO, [FromRoute]int id)
        {
            if (ModelState.IsValid)
            {
                await _jobService.Update(jobDTO, id);
                return Ok();
            }
            return BadRequest();
        }

      
        [HttpPost("Profile")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> GetPageForTableEmployer([FromBody] PagedRequest pagedRequest)
        {
            var result = await _jobService.GetJobsForEmployer(pagedRequest, _mapper);
            return Ok(result);
        }

        [HttpPost("Profile/Student")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetPageForTableStudent([FromBody] PagedRequest pagedRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _jobService.GetJobsForStudent(pagedRequest, _mapper);
                return Ok(result);
            }
                return BadRequest(); 
            
        }

        [HttpPost("PagePerTable")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPageForTable([FromBody] PagedRequest pagedRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _jobService.GetPagedData(pagedRequest, _mapper);
                return Ok(result);
            }
            return BadRequest();
            
        }

        [HttpGet("Added/{jobId}")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> AddedJobStudent([FromRoute]int jobId)
        {
            if (ModelState.IsValid)
            {
                await _jobService.AddedJobByStudent(jobId);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("Student/Delete/{jobId}")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> DeleteStudentJobs(int jobId)
        {
            await _jobService.DeleteJobStudent(jobId);
            return Ok();
        }

        [HttpGet("Image/{imageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetImageStreamById(int imageId)
        {
            var stream = await _repositoryImage.GetImageStreamById(imageId);
            return File(stream, "application/octet-stream");
        }


        [HttpPost("Types/{JobTypeId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFilteredJobsByJobType([FromBody] PagedRequest pagedRequest, int JobTypeId)
        {
            if (ModelState.IsValid)
            {
                var result = await _jobService.GetJobsByJobTypeId(pagedRequest, _mapper, JobTypeId);
                return Ok(result);
            }
            return BadRequest();
        }
    }   
}
