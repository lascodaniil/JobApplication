using JobSolution.Domain;
using JobSolution.Domain.Auth;
using JobSolution.Infrastructure.Configuration;
using JobSolution.Infrastructure.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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

        private readonly AuthOptions _authOptions;
        private readonly SignInManager<User> _signInManager;

        public AuthController(IOptions<AuthOptions> authOption, SignInManager<User> signInManager)
        {
            _authOptions = authOption.Value;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]UserForLoginDto userLoginDto)
        {
            var checkPassword = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password,false,false);
            if (checkPassword.Succeeded)
            {
                var signinCredentials = new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                     issuer: _authOptions.Issuer,
                     audience: _authOptions.Audience,
                     claims: new List<Claim>(),
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: signinCredentials);
                var tokenHandler = new JwtSecurityTokenHandler();
                var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);
                return Ok(new { AccessToken = encodedToken });
            }

            return Unauthorized();
        }
    }
}
