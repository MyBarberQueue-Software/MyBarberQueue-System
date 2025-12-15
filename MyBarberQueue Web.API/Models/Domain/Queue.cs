namespace MyBarberQueue_Web.API.Model.Domain
{
    public class Queue
    {
        public Guid Id { get; set; }

        public Guid ShopId { get; set; }
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Shop Shop { get; set; } = null!;
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
