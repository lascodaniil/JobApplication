using JobSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.Domain.ConfigFluentAPI
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> entity)
        {
            entity.HasIndex(p => p.Email).IsUnique();
            entity.Property(p => p.Email).HasMaxLength(255).IsRequired();
            entity.Property(p => p.FirstName).HasMaxLength(255).IsRequired();
            entity.Property(p => p.LastName).HasMaxLength(255).IsRequired();
            entity.HasMany(x => x.Job).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
