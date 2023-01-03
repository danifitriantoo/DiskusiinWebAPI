using Microsoft.EntityFrameworkCore;

namespace DiskusiinWebAPI.Models
{
    public class RentingContext : DbContext
    {
        public RentingContext(DbContextOptions<RentingContext> options) : base(options)
        {

        }

        public DbSet<Rentings> Rentings { get; set; } = null!;
    }
}
