using WingsAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WingsAppDAL.Entities;

namespace WingsAppDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options = 
            new DbContextOptionsBuilder<InMemoryContext>()
                .UseInMemoryDatabase("SomeDB")
                .Options;

        // Options that we want in memory
        public InMemoryContext() : base(options)
        {

        }

        public DbSet<UserEvent> UserEvents { get; set; }
    }
}