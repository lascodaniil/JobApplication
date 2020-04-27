using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;
        public JobController(IJobService repositoryJob, IMapper mapper, IHttpContextAccessor context)
        {
            _jobService = repositoryJob;
            _mapper = mapper;
            _context = context ?? throw new ArgumentNullException(nameof(context));

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

        [HttpGet("GetEmployerList")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllUsersByEmployer()
        {
            int userId=0;
            if (_context.HttpContext.User.Claims.Count() > 0)
            {
                if (!String.IsNullOrEmpty(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value))
                {
                    userId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
                }
            }
            var ressult =  _jobService.GetAll().Result.Where(x => x.UserId == userId); 
            return Ok(ressult);
        }


        [HttpPost]
        [Authorize(Roles ="Employer")]
        public async Task<IActionResult> Post([FromBody] JobForPostdDTO jobDTO)
        {
            if (ModelState.IsValid)
            {
                await _jobService.Add(jobDTO);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        [Authorize(Roles ="Employer")]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobService.Remove(id);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles ="Employer")]
        public async Task<IActionResult> Update([FromBody]JobForPostdDTO job, int id)
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

    }
}