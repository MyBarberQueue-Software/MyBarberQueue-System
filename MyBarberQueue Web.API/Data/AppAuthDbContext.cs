using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyBarberQueue_Web.API.Data
{
    public class AppAuthDbContext(DbContextOptions<AppAuthDbContext> options) : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "ede6320a-5456-4650-8434-cab37b70aeb8";
            var adminId = "96278a7e-4d16-4103-af38-2942130ebba7";

            var roles = new List<IdentityRole> {

                new() {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "READER"
                },
                new() {
                    Id = adminId,
                    ConcurrencyStamp = adminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
                };

            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
