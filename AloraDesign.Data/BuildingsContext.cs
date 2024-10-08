﻿using AloraDesign.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AloraDesign.Data
{
    public class BuildingsContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public BuildingsContext() { }
        public BuildingsContext(DbContextOptions<BuildingsContext> options) : base(options) { }

        public DbSet<ResidentialBuilding> ResidentialBuildings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Guid)
                .IsUnique()
                .HasDatabaseName("AppUserGuid");

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.PasswordRecoveryToken)
                .IsUnique()
                .HasDatabaseName("PasswordRecoveryToken");

        }
    }
}
