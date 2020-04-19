using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public JobController(IJobService repositoryJob, IMapper mapper)
        {
            _jobService = repositoryJob;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var JobsFromRepo = _jobService.GetAll().Result.ToList();
            return Ok(JobsFromRepo.ToList());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            if(id > 0)
            {
                var obj = await _jobService.GetByID(id);
              
                return Ok(obj);
            }
            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] JobDTO jobDTO)
        {
            
            if (ModelState.IsValid)
            {
                await _jobService.Add(jobDTO);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobService.Remove(id);
            return Ok();
        }


        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody]JobDTO job)
        {
            if (ModelState.IsValid)
            {
                await _jobService.Update(job);
                return Ok();
            }
            return BadRequest();
        }
    }
}