using Microsoft.EntityFrameworkCore;
using MyBarberQueue_Web.API.Data;
using MyBarberQueue_Web.API.Model.Domain;
using System.Formats.Asn1;

namespace MyBarberQueue_Web.API.Repository
{
    public class SqlUserRepository(AppDbContext dbContext) : IUserRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public Task<List<User>> GetAllAsync()
        {
            var usersDomain = dbContext.Users.ToListAsync();
            return usersDomain;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var userDomain = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return userDomain;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(Guid id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Role = user.Role;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.IsActive = user.IsActive;
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null)
            {
                return null;
            }
            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
