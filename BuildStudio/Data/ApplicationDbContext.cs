﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BuildStudio.Models;
using BuildStudio.Data.Model;

namespace BuildStudio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FunctionalSpecification> FunctionalSpecifications { get; set; }
        public DbSet<Functionality> Functionalities { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<AcceptanceCriteria> AcceptanceCriterias { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<ExpectedResult> ExpectedResults { get; set; }
        public DbSet<Result> Results { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
