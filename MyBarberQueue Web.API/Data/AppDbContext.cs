using Microsoft.EntityFrameworkCore;
using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<Shop> Shops { get; set; }     
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
