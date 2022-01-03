using GenericRepository.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.DataAccess.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(a => a.CompanyId);
            builder.Property(m => m.CompanyId).UseIdentityColumn();
            builder.Property(m => m.CompanyName).IsRequired().HasMaxLength(50);
            builder.ToTable("Companies");
        }
    }
}
