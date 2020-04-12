using JobSolution.Domain;
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
        private RoleManager<IdentityRole> RoleManager;
        private UserManager<AppUser> UserManager;

        public DbSeeder(JobDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
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
            if (!await RoleManager.RoleExistsAsync(role_Student)) await RoleManager.CreateAsync(new IdentityRole(role_Student));
            if (!await RoleManager.RoleExistsAsync(role_Employer)) await RoleManager.CreateAsync(new IdentityRole(role_Employer));

            //var Daniil =  new AppUser()
            //{
            //    UserName = "lascodaniil",
            //    Email = "lascodaniil@gmail.com",
            //    EmailConfirmed = true,
            //    LockoutEnabled = false
            //};
            //await UserManager.CreateAsync(Daniil);
            //await UserManager.AddToRoleAsync(Daniil, role_Employer);

            await DbContext.SaveChangesAsync();

        }
    }
}
