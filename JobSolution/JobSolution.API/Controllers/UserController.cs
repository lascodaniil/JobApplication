using AutoMapper;
using JobSolution.Domain.Auth;
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
        private readonly IMapper _mapper;
       
        
        public UserController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Employer")]
        [HttpGet("Student")]
        public async Task<IActionResult> GetStudentProfile()
        {
            return Ok();
        }


        [Authorize(Roles = "Administrator")]
        [HttpGet("Admin")]
        public async Task<IActionResult> GetAdminProfle()
        {
            return Ok();
        }



    }
}
