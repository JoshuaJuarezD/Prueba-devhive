using Microsoft.EntityFrameworkCore;
using MVC_devhive.Models;

namespace MVC_devhive.Data
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options) { }

        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().OwnsOne(p => p.Location);
        }
    }
}
