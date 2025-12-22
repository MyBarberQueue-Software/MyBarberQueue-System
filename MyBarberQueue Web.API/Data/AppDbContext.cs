using Microsoft.EntityFrameworkCore;
using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Shop> Shops { get; set; }     
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
