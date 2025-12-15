namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class AddShopRequestDto
    {
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public bool IsActive { get; set; }
    }
}
