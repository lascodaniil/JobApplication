using AutoMapper;
using JobSolution.Domain.Auth;
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
    public class UserController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public UserController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //[HttpGet("GetProfile/{id}")]
        //public async Task<IActionResult> GetStudentProfile(int id)
        //{
        //    var student = await _studentService.GetUserProfile(id);
        //    if(student != null)
        //    {
        //        return Ok(student);
        //    }
        //    return NotFound();
        //}

        [HttpGet("JobStudent/{id}")]
        [Authorize(Roles ="Employer")]
        public async Task<IActionResult> GetAllStudentsJobs(int id)
        {
            var AllStudentJobs = await _studentService.GetAllJobsStudent(id);
            return Ok(AllStudentJobs);
        }

        [HttpGet("Student/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllStudent(int id)
        {
            var student = await _studentService.GetStudent(id);
            return Ok(student);
        }





    }
}
