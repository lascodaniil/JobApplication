using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobSolution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IProfileService _userProfileService;
        private readonly IJobService _jobService;
        private readonly IStudentJobService _studentJobService;
        public UserController(IProfileService userService, 
            IJobService jobService,
            IStudentJobService studentJobService)
        {
            _userProfileService = userService;
            _jobService = jobService;
            _studentJobService = studentJobService;
        }

        [HttpGet("Profile")]
        [Authorize]
        public async Task<IActionResult> UserProfile()
        {
            return Ok(await _userProfileService.GetAuthProfile());
        }


        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromForm] UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                await _userProfileService.UpdateProfile(userRegisterDto);
                return Ok();
            }
            return BadRequest();
        }
    }
}
