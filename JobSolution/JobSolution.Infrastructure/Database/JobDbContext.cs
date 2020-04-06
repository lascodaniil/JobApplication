using JobSolution.Domain.ConfigFluentAPI;
using JobSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.Infrastructure.Database
{
    public class JobDbContext : DbContext
    {

        public JobDbContext() { }
        public JobDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentJob> StudentJobs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new JobConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = @"data source=DESKTOP-I2JBLKP; Initial Catalog=JobDatabase;  Trusted_Connection=True; ";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
