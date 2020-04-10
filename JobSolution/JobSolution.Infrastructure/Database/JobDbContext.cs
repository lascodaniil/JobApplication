using JobSolution.Domain;
using JobSolution.Domain.ConfigFluentAPI;
using JobSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSolution.Infrastructure.Database
{
    public class JobDbContext: IdentityDbContext<AppUser>
    {
        public JobDbContext() { }
        public JobDbContext(DbContextOptions<JobDbContext> dbContextOptions)  :base(dbContextOptions){ }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentJob> StudentJobs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new JobConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
        }
    }
}
