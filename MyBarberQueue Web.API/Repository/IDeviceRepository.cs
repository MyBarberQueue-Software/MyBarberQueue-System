using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Repository
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAllAsync();
    }
}

