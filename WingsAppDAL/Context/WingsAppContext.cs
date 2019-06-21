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

        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<UserProfile> UserProfiles {get; set; }
    }
}