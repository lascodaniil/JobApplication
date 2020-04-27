using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JobSolution.Services.Concrete
{
    public class UserService:IUserService
    {
        private readonly IUserService _UserService;
        private readonly IHttpContextAccessor _context;
        public UserService(IUserService UserService, IHttpContextAccessor context)
        {
            _UserService = UserService;

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string GetUserId()
        {
                return _context.HttpContext.User.Claims
                           .First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
