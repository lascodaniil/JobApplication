using AutoMapper;
using JobSolution.Domain;
using JobSolution.Domain.Auth;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Configuration;
using JobSolution.Infrastructure.Database;
using JobSolution.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobSolution.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
            
        


        //[Authorize(Roles = "Student")]
        //[HttpPost("GetUserProfile")]
        //public async Task<IActionResult> GetUserProfile([FromBody]UserForLoginDto userLoginDto)
        //{

        //    var checkPassword = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
        //    var user = await _userManager.FindByNameAsync(userLoginDto.Username);
        //    var role = await _userManager.GetRolesAsync(user);
        //    if (checkPassword.Succeeded)
        //    {
        //        var StudentProfile = _dbContext.Profiles.Where(x => x.UserId == user.Id);
        //        var StudentProfileDTO =  _mapper.Map<StudentProfileDTO>(StudentProfile.FirstOrDefault()); 
        //        return Ok(StudentProfile);
        //    }
        //    return NoContent();
        //}
        
        //[Authorize(Roles = "Employer")]
        //[HttpPost("GetEmployerProfile")]
        //public async Task<IActionResult> GetEmployerProfile([FromBody]UserForLoginDto userLoginDto)
        //{
        //    var checkPassword = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
        //    var user = await _userManager.FindByNameAsync(userLoginDto.Username);
        //    var role = await _userManager.GetRolesAsync(user);
        //    if (checkPassword.Succeeded)
        //    {
        //        var EmployerProfile = _dbContext.Profiles.Where(x => x.UserId == user.Id);
        //        var EmployerProfileDTO = _mapper.Map<EmployerPofileDTO>(EmployerProfile);
        //        return Ok(EmployerProfile);

        //    }
        //    return NoContent();
        //}
    }
}