using AutoMapper;
using JobSolution.Domain;
using JobSolution.Domain.Auth;
using JobSolution.Domain.Entities;
using JobSolution.Infrastructure.Configuration;
using JobSolution.Infrastructure.Database;
using JobSolution.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Interfaces
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository; 
        private readonly AuthOptions _authOptions;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _dbContext;
        private readonly HttpResponseMessage _responseMessage;
        private readonly IMapper _mapper;
        public AuthService(AppDbContext dbContext, IAuthRepository authRepository, IOptions<AuthOptions> authOption, SignInManager<User> signInManager, 
            UserManager<User> userManager, HttpResponseMessage responseMessage)
        {
            _authRepository = authRepository;
            _authOptions = authOption.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
            _responseMessage = responseMessage;
        } 
        public async Task<IActionResult> AddUser(UserRegisterDto userRegisterDto)
        {
            //if (userRegisterDto == null) 
            //    return new StatusCodeResult(500);
            //var user = await _userManager.FindByNameAsync(userRegisterDto.UserName);
            //if (user != null) { return _context.HttpContext.Request.Cre BadRequest("Username  exists"); }

            //user = await _userManager.FindByEmailAsync(userRegisterDto.Email);
            //if (user != null) { return BadRequest("Email exists"); }

            //var AddUser = new User()
            //{
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    UserName = userRegisterDto.UserName,
            //    Email = userRegisterDto.Email,
            //};

            //await _userManager.CreateAsync(AddUser, userRegisterDto.Password);
            //await _userManager.AddToRoleAsync(AddUser, userRegisterDto.RoleFromRegister);

            //var signinCredentials = new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            //var jwtSecurityToken = new JwtSecurityToken(
            //     issuer: _authOptions.Issuer,
            //     audience: _authOptions.Audience,
            //     claims: new List<Claim>() { new Claim(ClaimTypes.Role, userRegisterDto.RoleFromRegister), new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) },
            //     expires: DateTime.Now.AddDays(30),
            //     signingCredentials: signinCredentials);
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);
            //return Ok(new { AccessToken = encodedToken });
            return null;

        }

       
    }


}
