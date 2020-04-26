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
        private readonly IUserService _userService;
        public UserController(IUserService studentService)
        {
            _userService = studentService;
        }

        [HttpGet("JobStudent/{id}")]
        [Authorize(Roles ="Employer")]
        public async Task<IActionResult> GetAllStudentsJobs(int id)
        {
            var AllStudentJobs = await _userService.GetAllJobsStudent(id);
            return Ok(AllStudentJobs);
        }

        [HttpGet("Student/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllStudent(int id)
        {
            var student = await _userService.GetStudent(id);
            return Ok(student);
        }
    }
}
