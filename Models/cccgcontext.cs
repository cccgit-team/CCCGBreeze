using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCCGBreeze.Models
{
    public class cccgcontext: DbContext
    {
        public cccgcontext(DbContextOptions<cccgcontext> options) : base(options)
        {

        }

        public DbSet<addresses> addresses { get; set; }

        public DbSet<lifegroups> lifegroups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<addresses>().ToTable("addresses");
            modelBuilder.Entity<lifegroups>().ToTable("lifegroups");
        }
    }
}
