using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Repository
{
    public interface IQueueRepository
    {
        Task<List<Queue>> GetAllAsync();
        Task<Queue?> GetByIdAsync(Guid id);
        Task<Queue> CreateAsync (Queue Queue);
        Task<Queue?> UpdateAsync (Guid id, Queue queue);
        Task <Queue?> DeleteAsync (Guid id);
    }
}
