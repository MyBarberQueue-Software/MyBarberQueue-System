namespace MyBarberQueue_Web.API.Model.Domain
{
    public class Device
    {
        public Guid Id { get; set; }

        public Guid ShopId { get; set; }
        public string? DeviceName { get; set; }
        public string DeviceType { get; set; } = null!; // Tablet, Phone, Printer
        public string Identifier { get; set; } = null!;

        public bool IsActive { get; set; }
        public DateTime RegisteredAt { get; set; }

        // Navigation properties
        public Shop Shop { get; set; } = null!;
    }
}
