using Microsoft.EntityFrameworkCore;
using MyBarberQueue_Web.API.Data;
using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Repository
{
    public class SqlShopRepository : IShopRepository
    {
        private readonly AppDbContext dbContext;

        public SqlShopRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Shop>> GetAllAsync()
        {
            var shopsDomain = dbContext.Shops.ToListAsync();

            return await shopsDomain;
        }

        public async Task<Shop?> GetByIdAsync(Guid id)
        {
            var shopDomain = dbContext.Shops.FirstOrDefault(x => x.Id == id);
            return shopDomain;
        }

        public async Task<Shop> CreateAsync(Shop shop)
        {
            await dbContext.Shops.AddAsync(shop);
            await dbContext.SaveChangesAsync();

            return shop;

        }

        public async Task<Shop?> UpdateAsync(Guid id, Shop shop)
        {
            var existingShop = await dbContext.Shops
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingShop == null)
            {
                return null;
            }

            existingShop.Name = shop.Name;
            existingShop.PhoneNumber = shop.PhoneNumber;
            existingShop.Address = shop.Address;
            existingShop.City = shop.City;
            existingShop.IsActive = shop.IsActive;

            await dbContext.SaveChangesAsync();

            return existingShop;
        }


        public async Task<Shop?> DeleteAsync(Guid id)
        {
            var existingShop = dbContext.Shops.FirstOrDefault(x => x.Id == x.Id);
            if (existingShop == null)
            {
                return null;
            }
            dbContext.Shops.Remove(existingShop);
            await dbContext.SaveChangesAsync();
            return existingShop;
        }
    }
}