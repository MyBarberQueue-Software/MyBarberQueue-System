namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class DeviceDto
    {
        public Guid Id { get; set; }

        public Guid ShopId { get; set; }
        public string? DeviceName { get; set; }
        public string DeviceType { get; set; } = null!;
        public string Identifier { get; set; } = null!;

        public bool IsActive { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
