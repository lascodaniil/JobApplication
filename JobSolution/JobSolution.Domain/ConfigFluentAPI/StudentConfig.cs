using JobSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.Domain.ConfigFluentAPI
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {
            entity.HasIndex(p => p.Email).IsUnique();
            entity.Property(p => p.Email).HasMaxLength(255).IsRequired();
            entity.Property(p => p.FirstName).HasMaxLength(255).IsRequired();
            entity.Property(p => p.LastName).HasMaxLength(255).IsRequired();
            entity.Property(p => p.RegisterDate).HasDefaultValueSql("(GETDATE())");
            entity.Property(p => p.DateOfBirth).IsRequired();
            entity.Property(p => p.PhoneNumber).IsRequired();
            entity.HasIndex(p => p.PhoneNumber).IsUnique();
            
            entity.HasMany(x => x.StudentJobs).WithOne(x => x.Student).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
