using MyBarberQueue_Web.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Repository
{
    public class SqlQueueRepository(AppDbContext dbContext) : IQueueRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public Task<List<Queue>> GetAllAsync()
        {
            var existingQueues = dbContext.Queues.ToListAsync();
            return existingQueues;
        }
        public async Task<Queue?> GetByIdAsync(Guid id)
        {
            var existingQueue = await dbContext.Queues.FirstOrDefaultAsync(x => x.Id == id);
            return existingQueue;
        }
        public async Task<Queue> CreateAsync(Queue queue)
        {
            await dbContext.Queues.AddAsync(queue);
            await dbContext.SaveChangesAsync();
            return queue;
        }
        
        public async Task<Queue?> UpdateAsync(Guid id, Queue queue)
        {
            var existingQueue = await dbContext.Queues.FirstOrDefaultAsync(x => x.Id == id);
            if (existingQueue == null)
            {
                return null;
            }
            existingQueue.Name = queue.Name;
            existingQueue.IsActive = queue.IsActive;

            await dbContext.SaveChangesAsync();
            return existingQueue;
        }

        public async Task <Queue?> DeleteAsync(Guid id) {
            var existingQueue = await dbContext.Queues.FirstOrDefaultAsync(x => x.Id == id);
            if (existingQueue == null) {
                return null;
            }

            dbContext.Queues.Remove(existingQueue);
            await dbContext.SaveChangesAsync();
            return existingQueue;
        }
}}
