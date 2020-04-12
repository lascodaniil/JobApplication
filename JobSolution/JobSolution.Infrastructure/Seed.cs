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
    public class Seed
    {
        public static JobDbContext DbContext;
        public static UserManager<User> UserManager;

        public Seed(JobDbContext dbContext, UserManager<User> userManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        public static async Task SeedUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "lascodaniil",
                    Email = "lascodaniil@jobPlatform.com",
                };

                await userManager.CreateAsync(user, "parola123!");
            }
        }

        public static void  Send()
        {
            SeedUsers(UserManager);
            DbContext.SaveChangesAsync();
        }



    }
}
