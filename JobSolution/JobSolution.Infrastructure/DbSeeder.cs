using JobSolution.Domain;
using JobSolution.Domain.Auth;
using JobSolution.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Infrastructure
{
   public class DbSeeder
   {
        private JobDbContext DbContext;
        private RoleManager<Role> RoleManager;
        private UserManager<User> UserManager;

        public DbSeeder(JobDbContext dbContext, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            DbContext = dbContext;
            RoleManager = roleManager;
            UserManager = userManager;
        }

        public void SendAsync()
        {
            CreateUsersAsync();

        }

        private async Task CreateUsersAsync()
        {
            string role_Student = "Student";
            string role_Employer = "Employer";
            
            if (!await RoleManager.RoleExistsAsync(role_Student)) await RoleManager.CreateAsync(new Role(role_Student));
            if (!await RoleManager.RoleExistsAsync(role_Employer)) await RoleManager.CreateAsync(new Role(role_Employer));

           
            
            var Daniil = new User()
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            
            await UserManager.CreateAsync(Daniil,"password123");
            await UserManager.AddToRoleAsync(Daniil, role_Student);
            await DbContext.SaveChangesAsync();

        }
    }
}
