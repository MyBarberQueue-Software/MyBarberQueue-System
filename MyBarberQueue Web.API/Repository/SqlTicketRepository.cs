using Microsoft.EntityFrameworkCore;
using MyBarberQueue_Web.API.Data;
using MyBarberQueue_Web.API.Model.Domain;

namespace MyBarberQueue_Web.API.Repository
{
    public class SqlTicketRepository(AppDbContext dbContext) : ITicketRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task<List<Ticket>> GetAllAsync()
        {
            var tickets = await dbContext.Tickets.ToListAsync();
            return tickets;
        }   
        public async Task<Ticket?> GetByIdAsync(Guid id)
        {
            var ticket = await dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            return ticket;
        }
        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            await dbContext.Tickets.AddAsync(ticket);
            await dbContext.SaveChangesAsync();
            return ticket;
        }
        public async Task<Ticket?> UpdateAsync(Guid id, Ticket ticket)
        {
            var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTicket == null)
            {
                return null;
            }
            existingTicket.Status = ticket.Status;
            existingTicket.CalledAt = ticket.CalledAt;
            existingTicket.CompletedAt = ticket.CompletedAt;
            await dbContext.SaveChangesAsync();
            return existingTicket;
        }
        public async Task<Ticket?> DeleteAsync(Guid id)
        {
            var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTicket == null)
            {
                return null;
            }
            dbContext.Tickets.Remove(existingTicket);
            await dbContext.SaveChangesAsync();
            return existingTicket;
        }
    }
}
