using GenericRepository.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.DataAccess.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(w => w.BranchId);
            builder.Property(w => w.BranchId).UseIdentityColumn();
            builder.HasOne(w => w.Company).WithMany(a => a.Branches).HasForeignKey(w => w.CompanyId);
            builder.ToTable("Branches");
        }
    }
}
