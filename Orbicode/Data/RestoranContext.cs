using Microsoft.EntityFrameworkCore;
using Orbicode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orbicode.Data
{
    public class RestoranContext : DbContext
    {
        public RestoranContext(DbContextOptions<RestoranContext> options) : base(options)
        {

        }
        public DbSet<Food> foods { get; set; }
        public DbSet<Restoran> restorans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restoran>().ToTable("Restoran");
            modelBuilder.Entity<Food>().ToTable("Food");
            
        }
    }
}
