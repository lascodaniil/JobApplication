﻿using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Services.Interfaces;
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
            var JobsFromRepo = _jobService.GetAll();
            return Ok(JobsFromRepo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var obj =  _jobService.GetByID(id);
            var result = _mapper.Map<JobDTO>(obj); // mapat in service
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobDTO jobDTO)
        {
            var obj = _mapper.Map<Job>(jobDTO);// service mapeaza 

            if (ModelState.IsValid)
            {
                _jobService.Add(obj);
                //   _jobService.SaveAll();
                return Ok();

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jobToDelete =  _jobService.GetByID(id);
            var antother = jobToDelete;

            if (jobToDelete == null)
            {
                return NotFound();
            }
            _jobService.Remove(id);
            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]JobDTO job)
        {
            var UpdatedJob = _mapper.Map<Job>(job);// service 
            _jobService.Update(UpdatedJob);
            return Ok();
        }
    }
}