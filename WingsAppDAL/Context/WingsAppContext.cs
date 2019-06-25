using WingsAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WingsAppDAL.Entities;

namespace WingsAppDAL.Context
{
    class WingsAppContext : DbContext
    {
        static DbContextOptions<WingsAppContext> options = 
            new DbContextOptionsBuilder<WingsAppContext>()
                .UseInMemoryDatabase("SomeDB")
                .Options;

        // Options that we want in memory
        public WingsAppContext() : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEventUserProfile>().HasKey(ep => new { ep.UserEventId, ep.UserProfileId });
            modelBuilder.Entity<UserEventUserProfile>().HasOne(ep => ep.UserEvent).WithMany(e => e.Assigners).HasForeignKey(ep => ep.UserEventId);
            modelBuilder.Entity<UserEventUserProfile>().HasOne(ep => ep.UserProfile).WithMany(p => p.AssignedToEvents).HasForeignKey(ep => ep.UserProfileId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<UserProfile> UserProfiles {get; set; }
        public DbSet<EventType> EventTypes { get; set; }
    }
}