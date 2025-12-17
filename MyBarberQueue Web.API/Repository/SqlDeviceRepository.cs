using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyBarberQueue_Web.API.Data;
using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Repository
{
    public class SqlDeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext dbContext;

        public SqlDeviceRepository(AppDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<List<Device>> GetAllAsync()
        {
            var existingDevices = dbContext.Devices.ToListAsync();
            return await existingDevices;
        }
        
    }
}
