using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lab4_2.Data.Entities;

namespace Lab4_2.Data
{
    public class SubDbContext  : DbContext
    {
        public SubDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public DbSet<User> Users { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<SubDbContext>
    {
        // intentionally empty
    }
}