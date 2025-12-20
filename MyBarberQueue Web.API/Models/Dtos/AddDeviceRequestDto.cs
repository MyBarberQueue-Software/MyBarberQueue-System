namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class AddDeviceRequestDto
    {
        public Guid ShopId { get; set; }

        public string? DeviceName { get; set; }

        public string DeviceType { get; set; } = null!; // Tablet, Phone, Printer

        public string Identifier { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
