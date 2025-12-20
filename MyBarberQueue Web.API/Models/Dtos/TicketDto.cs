namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class TicketDto
    {
        public Guid Id { get; set; }

        public Guid QueueId { get; set; }
        public string TicketNumber { get; set; } = null!;
        public string Status { get; set; } = null!;

        public DateTime IssuedAt { get; set; }
        public DateTime? CalledAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
