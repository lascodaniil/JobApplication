using JobSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.Domain.ConfigFluentAPI
{
    public class EmployerConfig : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> entity)
        {
            entity.HasIndex(p => p.Email).IsUnique();
            entity.Property(p => p.Email).HasMaxLength(255).IsRequired();
            entity.HasIndex(p => p.Username).IsUnique();
            entity.Property(p => p.PhoneNumber).IsRequired();
            entity.HasIndex(p => p.PhoneNumber).IsUnique();
            entity.HasMany(x => x.Job).WithOne(x => x.Employer).HasForeignKey(x => x.EmployerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
