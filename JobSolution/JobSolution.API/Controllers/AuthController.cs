using JobSolution.Domain;
using JobSolution.Domain.Entities;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobSolution.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {

            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userLoginDto)
        {
            return await _authService.GetToken(userLoginDto);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Add([FromForm] UserRegisterDto userRegisterDto)
        {
            return await _authService.AddUser(userRegisterDto);
        }
    }
}