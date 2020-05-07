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
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
            
        private readonly AuthOptions _authOptions;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthController(IOptions<AuthOptions> authOption, SignInManager<User> signInManager, UserManager<User> userManager, AppDbContext dbContext)
        {
            _authOptions = authOption.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userLoginDto)
        {
            var checkPassword = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
            var user = await _userManager.FindByNameAsync(userLoginDto.Username);
            var role = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim("UserId", user.Id.ToString()));

            foreach (var item in role)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            
            if (checkPassword.Succeeded)
            {
                var signinCredentials = new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                     issuer: _authOptions.Issuer,
                     audience: _authOptions.Audience,
                     claims: claims,
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: signinCredentials);
                var tokenHandler = new JwtSecurityTokenHandler();

                var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);
                return Ok(new { AccessToken = encodedToken });
            }
            return Unauthorized();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Add([FromBody]UserRegisterDto userRegisterDto)
        {
            if (userRegisterDto == null) return new StatusCodeResult(500);
            var user = await _userManager.FindByNameAsync(userRegisterDto.UserName);
            if (user != null) { return BadRequest("Username  exists"); }

            user = await _userManager.FindByEmailAsync(userRegisterDto.Email);
            if (user != null) { return BadRequest("Email exists"); }

            var AddUser = new User()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
            };

            await _userManager.CreateAsync(AddUser, userRegisterDto.Password);
            await _userManager.AddToRoleAsync(AddUser, userRegisterDto.RoleFromRegister);

            var signinCredentials = new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: _authOptions.Issuer,
                 audience: _authOptions.Audience,
                 claims: new List<Claim>() { new Claim(ClaimTypes.Role, userRegisterDto.RoleFromRegister), new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) },
                 expires: DateTime.Now.AddDays(30),
                 signingCredentials: signinCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);
            return  Ok(new { AccessToken = encodedToken });
        }
    }
}