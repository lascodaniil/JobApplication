using JobSolution.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSolution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private UserManager<AppUser> userManager;
        public AuthController(UserManager<AppUser> usrMgr)
        {
            userManager = usrMgr;
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel obj)
        {
            AppUser user = new AppUser
            {
                UserName = obj.Name,
                Email = obj.Email
            };

            IdentityResult result = await userManager.CreateAsync(user, obj.Password);
            return Ok(result);
        }

    }
}
