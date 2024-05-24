using Microsoft.EntityFrameworkCore;
using API_Inmuebles.Models;
using Microsoft.Data.SqlClient;

namespace API_Inmuebles.Data
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options) { }

        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().OwnsOne(p => p.Location);
        }

        public async Task<int> DeletePropertyByIdAsync(int id)
        {
            var param = new SqlParameter("@Id", id);
            return await Database.ExecuteSqlRawAsync("EXEC DeletePropertyById @Id", param);
        }
    }
}
