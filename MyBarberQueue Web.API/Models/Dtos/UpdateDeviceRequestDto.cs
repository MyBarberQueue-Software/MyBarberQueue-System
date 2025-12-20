namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class UpdateDeviceRequestDto
    {
        public string? DeviceName { get; set; }

        public string DeviceType { get; set; } = null!;

        public string Identifier { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
