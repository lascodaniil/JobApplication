﻿using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
            var obj = await _jobService.GetByID(id);
            return Ok(obj);
        }

        [HttpPost]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobService.Remove(id);
            return Ok();
        }


        [HttpPut("Update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody]JobForPostdDTO job, int id)
        {
            if (ModelState.IsValid)
            {
                await _jobService.Update(job,id);
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

        [HttpPost("PagePerTable")]
        public async Task<IActionResult> GetPageForTable([FromBody] PagedRequest pagedRequest)
        {
            var result =await  _jobService.GetPagedData(pagedRequest, _mapper);
            return Ok(result);   
        }
    }
}