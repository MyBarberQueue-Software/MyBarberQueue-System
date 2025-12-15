namespace MyBarberQueue_Web.API.Model.Domain
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Device> Devices { get; set; } = new List<Device>();
        public ICollection<Queue> Queues { get; set; } = new List<Queue>();
    }
}
