namespace MyBarberQueue_Web.API.Model.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public Guid QueueId { get; set; }
        public string TicketNumber { get; set; } = null!;
        public string Status { get; set; } = null!; // Waiting, Serving, Completed, Skipped

        public DateTime IssuedAt { get; set; }
        public DateTime? CalledAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        // Navigation
        public Queue Queue { get; set; } = null!;
    }

}
