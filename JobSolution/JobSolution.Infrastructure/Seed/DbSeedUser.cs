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
    public class DbSeedUser
    {
        public static async Task PopulateUser(JobDbContext dbContext, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            string StudentRole = "Student";

            var User_1 = new User()
            {
                UserName = "lascodaniil",
                Email = "lascodaniil@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };


            if (await userManager.FindByEmailAsync(User_1.Email) == null)
            {
                await userManager.CreateAsync(User_1, "password");
                await userManager.AddToRoleAsync(User_1, StudentRole);
                var User_1Str = new Student()
                {
                    FirstName = "Daniil",
                    LastName = "Lasco",
                    Email = "lascodaniil@gmail.com",
                    DateOfBirth = new DateTime(1998, 10, 25),
                    University = "UTM",
                    UserId = 2,
                    PhoneNumber = "079854789"
                };
                dbContext.Students.Add(User_1Str);
            }

            var User_2 = new User()
            {
                UserName = "lascovalentin",
                Email = "lascovalentin@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };


            if (await userManager.FindByEmailAsync(User_2.Email) == null)
            {
                await userManager.CreateAsync(User_2, "password");
                await userManager.AddToRoleAsync(User_2, StudentRole);
                var User_1Str = new Student()
                {
                    FirstName = "Valentin",
                    LastName = "Lasco",
                    Email = "lascovalentin@gmail.com",
                    DateOfBirth = new DateTime(2000, 5, 2),
                    University = "UTM",
                    UserId = 3,
                    PhoneNumber = "022341256"
                };

                dbContext.Students.Add(User_1Str);
            }

            var User_3 = new User()
            {
                UserName = "marianlupu",
                Email = "marianlupu@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };


            if (await userManager.FindByEmailAsync(User_3.Email) == null)
            {
                await userManager.CreateAsync(User_3, "password");
                await userManager.AddToRoleAsync(User_3, StudentRole);
                var User_1Str = new Student()
                {
                    FirstName = "Marian",
                    LastName = "Lupu",
                    Email = "marianlupu@gmail.com",
                    DateOfBirth = new DateTime(1978, 5, 2),
                    University = "ASEM",
                    UserId = 4,
                    PhoneNumber = "022456798"
                };

                dbContext.Students.Add(User_1Str);
            }

            var User_4 = new User()
            {
                UserName = "cebandaniil",
                Email = "cebandaniil@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };


            if (await userManager.FindByEmailAsync(User_4.Email) == null)
            {
                await userManager.CreateAsync(User_4, "password");
                await userManager.AddToRoleAsync(User_4, StudentRole);
                var User_1Str = new Student()
                {
                    FirstName = "Daniil",
                    LastName = "Ceban",
                    Email = "cebandaniil@gmail.com",
                    DateOfBirth = new DateTime(2001, 5, 2),
                    University = "UTM",
                    UserId = 5,
                    PhoneNumber = "1230453453"
                };

                dbContext.Students.Add(User_1Str);
            }


            var User_5 = new User()
            {
                UserName = "maximmolosnic",
                Email = "maximmolosnic@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };


            if (await userManager.FindByEmailAsync(User_5.Email) == null)
            {
                await userManager.CreateAsync(User_5, "password");
                await userManager.AddToRoleAsync(User_5, StudentRole);
                var User_1Str = new Student()
                {
                    FirstName = "Maxim",
                    LastName = "Molosnic",
                    Email = "maximmolosnic@gmail.com",
                    DateOfBirth = new DateTime(1997, 9, 25),
                    University = "UST",
                    UserId = 6,

                    PhoneNumber = "0223456768"
                };

                dbContext.Students.Add(User_1Str);
            }

           
        }

        public static async Task PopulateEmployer(JobDbContext dbContext, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            string EmployerRole = "Employer";

            //var User_1 = new User()
            //{
            //    UserName = "AMDARISLLC",
            //    Email = "amdaris@amdaris.com",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};


            //if (await userManager.FindByEmailAsync(User_1.Email) == null)
            //{
            //    await userManager.CreateAsync(User_1, "password");
            //    await userManager.AddToRoleAsync(User_1, EmployerRole);
            //var User_1Str = new Employer()
            //{

            //    Email = "amdaris@amdaris.com",
            //    Username = "AMDARIS LLC",
            //    City = "Chisinau",
            //    PhoneNumber = "060277311",
            //    UserId = 7
            //};
            //dbContext.Employers.Add(User_1Str);
            //}


            //var User_2 = new User()
            //{
            //    UserName = "ProImobilGroup",
            //    Email = "proimobil@pro.com",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //if (await userManager.FindByEmailAsync(User_2.Email) == null)
            //{
            //    await userManager.CreateAsync(User_2, "password");
            //    await userManager.AddToRoleAsync(User_2, EmployerRole);
            //var User_1Str = new Employer()
            //{
            //    Email = "proimobil@pro.com",
            //    Username = "ProImobilGroup",
            //    City = "Orhei",
            //    PhoneNumber = "063267657",
            //    UserId = 8
            //};
            //dbContext.Employers.Add(User_1Str);


            //}



            // +++++++++++++++++++++++++++++++


            //var User_3 = new User()
            //{
            //    UserName = "CentrulDeLimbiStraine",
            //    Email = "linguata@linguata.com",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //if (await userManager.FindByEmailAsync(User_3.Email) == null)
            //{
            //    await userManager.CreateAsync(User_3, "password");
            //    await userManager.AddToRoleAsync(User_3, EmployerRole);

            //var User_1Str = new Employer()
            //{

            //    Email = "linguata@linguata.com",
            //    Username = "linguata",
            //    City = "Balti",
            //    PhoneNumber = "069345871",
            //    UserId = 9
            //};

            //dbContext.Employers.Add(User_1Str);
            //}





            //var User_4 = new User()
            //{
            //    UserName = "KPMG",
            //    Email = "kpmg@kpmg.com",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //if (await userManager.FindByEmailAsync(User_4.Email) == null)
            //{
            //    await userManager.CreateAsync(User_4, "password");
            //    await userManager.AddToRoleAsync(User_4, EmployerRole);
            //    var User_1Str = new Employer()
            //    {

            //        Email = "kpmg@kpmg.com",
            //        Username = "Groupkpmg",
            //        City = "Orhei",
            //        PhoneNumber = "060567321",
            //        UserId = 10
            //    };
            //    dbContext.Employers.Add(User_1Str);
            //}





            //var User_5 = new User()
            //{
            //    UserName = "AcademyPlus",
            //    Email = "academyplus@academy.com",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};


            //if (await userManager.FindByEmailAsync(User_5.Email) == null)
            //{
            //    await userManager.CreateAsync(User_5, "password");
            //    await userManager.AddToRoleAsync(User_5, EmployerRole);
            //    var User_1Str = new Employer()
            //    {

            //        Email = "academyplus@academy.com",
            //        Username = "academyplus",
            //        City = "Chisinau",
            //        PhoneNumber = "060299210",
            //        UserId = 11
            //    };

            //    dbContext.Employers.Add(User_1Str);
            //}






            //var User_6 = new User()
            //{
            //    UserName = "Orange",
            //    Email = "orange@orange.com",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};


            //if (await userManager.FindByEmailAsync(User_6.Email) == null)
            //{
            //    await userManager.CreateAsync(User_6, "password");
            //    await userManager.AddToRoleAsync(User_6, EmployerRole);
            //    var User_1Str = new Employer()
            //    {

            //        Email = "orange@orange.com",
            //        Username = "orangemoldova",
            //        City = "Chisinau",
            //        PhoneNumber = "022210210",
            //        UserId = 12
            //    };

            //    dbContext.Employers.Add(User_1Str);
            //}



            //var User_7 = new User()
            //{
            //    UserName = "Mercedes",
            //    Email = "mercedes@mercedes.com",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};


            //if (await userManager.FindByEmailAsync(User_7.Email) == null)
            //{
            //    await userManager.CreateAsync(User_7, "password");
            //    await userManager.AddToRoleAsync(User_7, EmployerRole);
            //    var User_1Str = new Employer()
            //    {

            //        Email = "mercedes@mercedes.com",
            //        Username = "mercedes@mercedes.coma",
            //        City = "Chisinau",
            //        PhoneNumber = "022467992",
            //        UserId = 13
            //    };
            //    dbContext.Employers.Add(User_1Str);
            //}

        }

        public static void PopulateJobs(JobDbContext dbContext, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            var Job_1 = new Job()
            {
                CategoryId = 1,
                EmployerId = 1,
                Title = "Internship Programe",
                City = "Chisinau",
                PostDate = new DateTime(2020, 4, 1),
                EndDate = new DateTime(2020, 7, 1),
                Base64Photo = "",
                Contact = "060277321",
                Salary = 0
            };
            dbContext.Jobs.Add(Job_1);

            var Job_2 = new Job()
            {
                CategoryId = 1,
                EmployerId = 1,
                Title = ".NET Developer",
                City = "Orhei",
                PostDate = new DateTime(2020, 2, 1),
                EndDate = new DateTime(2020, 5, 31),
                Base64Photo = "",
                Contact = "060278972",
                Salary = 15
            };
            dbContext.Jobs.Add(Job_2);

            var Job_3 = new Job()
            {
                CategoryId = 4,
                EmployerId = 3,
                Title = "Sales Manager ",
                City = "Balti",
                PostDate = new DateTime(2020, 1, 1),
                EndDate = new DateTime(2020, 9, 11),
                Base64Photo = "",
                Contact = "060345765",
                Salary = 5
            };
            dbContext.Jobs.Add(Job_3);

            var Job_4 = new Job()
            {
                CategoryId = 3,
                EmployerId = 8,
                Title = "Service Auto",
                City = "Balti",
                PostDate = new DateTime(2020, 2, 14),
                EndDate = new DateTime(2020, 7, 11),
                Base64Photo = "",
                Contact = "060345765",
                Salary = 10
            };
            dbContext.Jobs.Add(Job_4);


            var Job_5 = new Job()
            {
                CategoryId = 2,
                EmployerId = 4,
                Title = "English Teacher",
                City = "Balti",
                PostDate = new DateTime(2020, 2, 14),
                EndDate = new DateTime(2020, 7, 11),
                Base64Photo = "",
                Contact = "060353453765",
                Salary = 5
            };
            dbContext.Jobs.Add(Job_5);
        }

        public static void StudentJobs(JobDbContext dbContext)
        {
            var StudentRole = new StudentJob()
            {
                StudentId = 2,
                JobId = 1,
            };


            var StudentRol1 = new StudentJob()
            {
                StudentId = 2,
                JobId = 2,
            };


            var StudentRole1 = new StudentJob()
            {
                StudentId = 3,
                JobId = 3,
            };


            var StudentRole2 = new StudentJob()
            {
                StudentId = 4,
                JobId = 2,
            };

            var StudentRole3 = new StudentJob()
            {
                StudentId = 3,
                JobId = 3,
            };

            var StudentRole4 = new StudentJob()
            {
                StudentId = 4,
                JobId = 3,
            };

            var StudentRole5 = new StudentJob()
            {
                StudentId = 1,
                JobId = 4,
            };

            dbContext.StudentJobs.Add(StudentRole);
            dbContext.StudentJobs.Add(StudentRole1);
            dbContext.StudentJobs.Add(StudentRole2);
            dbContext.StudentJobs.Add(StudentRole3);
            dbContext.StudentJobs.Add(StudentRole4);
            dbContext.StudentJobs.Add(StudentRole5);
        }
    }
}
