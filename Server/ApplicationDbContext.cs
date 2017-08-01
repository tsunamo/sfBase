﻿using sfBase.Server.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace sfBase.Server
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<ContentText> ContentText { get; set; }
        public DbSet<WorkingRecord> WorkingRecord { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<WorkingRecord>(entity =>
            {
                entity.HasOne(w => w.User)
                .WithMany(u => u.WorkingRecords)
                .HasForeignKey(w => w.UserId);
            });

            modelBuilder.Entity<WorkingRecord>()
                .HasIndex(w => new { w.UserId, w.RecordeDate });
        }
    }
}
