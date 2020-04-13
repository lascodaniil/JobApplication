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
        public async Task<IActionResult> GetAll()
        {
            var JobsFromRepo = await _jobService.GetAll();
            return Ok(JobsFromRepo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var obj = await _jobService.GetByID(id);
            var result = _mapper.Map<JobDTO>(obj); // mapat in service
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobDTO jobDTO)
        {
            var obj = _mapper.Map<Job>(jobDTO);// service mapeaza 

            if (ModelState.IsValid)
            {
                await _jobService.Add(obj);
                await _jobService.SaveAll();
                return Ok();

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jobToDelete = await _jobService.GetByID(id);

            if (jobToDelete == null)
            {
                return NotFound();
            }

            await _jobService.Remove(id);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]JobDTO job)
        {
            var UpdatedJob = _mapper.Map<Job>(job);// service 
            if (ModelState.IsValid)
            {
                await _jobService.Update(UpdatedJob);
                await _jobService.SaveAll();
                return Ok();
            }
            return BadRequest();
        }
    }
}