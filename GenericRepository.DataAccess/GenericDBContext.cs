using GenericRepository.DataAccess.Configurations;
using GenericRepository.Entities.Model;
using GenericRepository.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.DataAccess
{
    public class GenericDBContext : IdentityDbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //   optionsBuilder.UseSqlServer("Server=DESKTOP-CCT1C3T;Database=GenericDB;uid=feridekrpnr46;pwd=123");
        //}
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.ApplyConfiguration(new CompanyConfiguration());
        //    builder.ApplyConfiguration(new BranchConfiguration());
        //}
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<User> User { get; set; }
        public GenericDBContext(DbContextOptions<GenericDBContext> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public GenericDBContext()
        {

        }
    }
}
