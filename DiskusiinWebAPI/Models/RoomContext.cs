using Microsoft.EntityFrameworkCore;

namespace DiskusiinWebAPI.Models
{
    public class RoomContext : DbContext
    {
        public RoomContext(DbContextOptions<RoomContext> options) : base(options) 
        {

        }

        public DbSet<Rooms> Rooms { get; set; } = null!; 
    }
}
