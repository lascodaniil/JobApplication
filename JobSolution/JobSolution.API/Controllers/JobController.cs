using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobSolution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;
        private IHostingEnvironment _hostingEnvironment;

        public JobController(IJobService repositoryJob, IHostingEnvironment hostingEnvironment, ICategoryService categoryService, ICityService cityService, IMapper mapper, IHttpContextAccessor context)
        {
            _cityService = cityService;
            _categoryService = categoryService;
            _jobService = repositoryJob;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;

            _context = context ?? throw new ArgumentNullException(nameof(context));
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

        [HttpPost]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Post([FromBody] JobDTO jobDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(jobDTO.Base64Photo))
                    {
                        string folderName = "Upload";
                        string webRootPath = _hostingEnvironment.WebRootPath;
                        if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
                        {
                            _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                        }
                        string newPath = Path.Combine(webRootPath, folderName);
                        var folderPath = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, folderName);
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        jobDTO.Base64Photo = jobDTO.Base64Photo.Substring(jobDTO.Base64Photo.LastIndexOf(',') + 1);
                        var fileName = Path.Combine(folderPath, Guid.NewGuid().ToString());
                        System.IO.File.WriteAllBytes(fileName, Convert.FromBase64String(jobDTO.Base64Photo));
                        jobDTO.Base64Photo = fileName;
                    }

                    await _jobService.Add(jobDTO);

                    return Ok();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobService.Remove(id);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromBody]JobDTO job, int id)
        {
            if (ModelState.IsValid)
            {
                await _jobService.Update(job, id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Category/{category}")]
        [AllowAnonymous]
        public async Task<IList<JobDTO>> GetJobsByCategory(string category)
        {
            return await _jobService.GetJobsByCategory(category);
        }

        [HttpPost("PagePerTableForEmployer")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> GetPageForTableEmployer([FromBody] PagedRequest pagedRequest)
        {
            var result = await _jobService.GetJobsForEmployer(pagedRequest, _mapper);
            return Ok(result);
        }

        [HttpPost("PagePerTable")]
        public async Task<IActionResult> GetPageForTable([FromBody] PagedRequest pagedRequest)
        {
            var result = await _jobService.GetPagedData(pagedRequest, _mapper);
            return Ok(result);
        }

        [HttpPost("UploadPhoto"), DisableRequestSizeLimit]
        public ActionResult UploadPhoto()

        {

            // Student offer






            return Ok();
        }
    }
}