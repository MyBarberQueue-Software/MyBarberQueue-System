using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Repository
{
    public interface IShopRepository
    {
        Task<List<Shop>> GetAllAsync();
        Task<Shop?> GetByIdAsync(Guid id);
        Task<Shop> CreateAsync(Shop shop);
        Task<Shop?> UpdateAsync (Guid id,Shop shop);
        Task<Shop?> DeleteAsync(Guid id);
    }
}
