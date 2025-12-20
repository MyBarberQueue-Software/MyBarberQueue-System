namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class QueueDto
    {
        public Guid Id { get; set; }

        public Guid ShopId { get; set; }
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
