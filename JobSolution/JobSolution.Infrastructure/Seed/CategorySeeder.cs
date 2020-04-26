using JobSolution.Domain.Auth;
using JobSolution.Domain.Entities;
using JobSolution.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Infrastructure.Seed
{
    public class CategorySeeder
    {
        public static void CreateCategories(AppDbContext dbContext)
        {
            var Category1 = new Categories()
            {
                Category = "IT"
            };

            var Category2 = new Categories()
            {
                Category = "Education"
            };

            var Category3 = new Categories()
            {
                Category = "Drive"
            };

            var Category4 = new Categories()
            {
                Category = "Real Estate"
            };

            dbContext.Categories.Add(Category1);
            dbContext.Categories.Add(Category2);
            dbContext.Categories.Add(Category3);
            dbContext.Categories.Add(Category4);
        }
    }
}
