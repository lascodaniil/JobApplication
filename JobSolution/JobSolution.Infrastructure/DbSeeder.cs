using JobSolution.Domain;
using JobSolution.Domain.Auth;
using JobSolution.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Infrastructure
{
   public class DbSeeder
   {
      
        

        public static void Seed(JobDbContext dbContext, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
          

            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager).GetAwaiter().GetResult();
            }
        }

        private static async Task CreateUsers(JobDbContext dbContext, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            string Administrator = "Administrator";
            string Employee = "Employee";
            string Employer = "Employer";

            if (!await roleManager.RoleExistsAsync(Administrator))
            {
                await roleManager.CreateAsync(new Role(Administrator));
            }

            if (!await roleManager.RoleExistsAsync(Employee))
            {
                await roleManager.CreateAsync(new Role(Employee));
            }
            if (!await roleManager.RoleExistsAsync(Employer))
            {
                await roleManager.CreateAsync(new Role(Employer));
            }



            var user_Admin = new User()
            {
                UserName = "Admin",
                Email = "admin@admin.com",
            };

            if(await userManager.FindByEmailAsync(user_Admin.Email) == null)
            {
                await userManager.CreateAsync(user_Admin, "password");
                await userManager.AddToRoleAsync(user_Admin,Administrator);
                await userManager.AddToRoleAsync(user_Admin,Employee);
                await userManager.AddToRoleAsync(user_Admin,Employer);
            }

            var user_Daniil = new User
            {
                UserName = "lascodaniil",
                Email = "lascodaniil@gmail.com"

            };



            if(await userManager.FindByEmailAsync(user_Daniil.Email) == null)
            {
                await userManager.CreateAsync(user_Daniil, "password");
                await userManager.AddToRoleAsync(user_Daniil, Employer);
                
            }
            await dbContext.SaveChangesAsync();

        }



       
    }
}
