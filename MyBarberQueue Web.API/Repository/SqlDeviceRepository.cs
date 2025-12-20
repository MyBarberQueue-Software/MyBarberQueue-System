using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyBarberQueue_Web.API.Data;
using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Repository
{
    public class SqlDeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext dbContext;

        public SqlDeviceRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Device>> GetAllAsync()
        {
            var existingDevices = dbContext.Devices.ToListAsync();
            return await existingDevices;
        }

        public async Task<Device?> GetByIdAsync(Guid id)
        {
            var existingDevice = await dbContext.Devices.FirstOrDefaultAsync(x => x.Id == id);
            return existingDevice;
        }

        public async Task<Device> CreateAsync(Device device)
        {
            await dbContext.Devices.AddAsync(device);
            await dbContext.SaveChangesAsync();
            return device;
        }
        public async Task<Device?> UpdateAsync(Guid id, Device device)
        {
            var existingDevice = await dbContext.Devices.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDevice == null)
            {
                return null;
            }
            existingDevice.DeviceName = device.DeviceName;
            existingDevice.DeviceType = device.DeviceType;
            existingDevice.Identifier = device.Identifier;
            existingDevice.IsActive = device.IsActive;

            await dbContext.SaveChangesAsync();
            return existingDevice;
        }
        public async Task <Device?> DeleteAsync(Guid id)
        {
            var existingDevice = await dbContext.Devices.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDevice == null)
            {
                return null;
            }
            dbContext.Devices.Remove(existingDevice);
            await dbContext.SaveChangesAsync();
            return existingDevice;
        }
    }
}
