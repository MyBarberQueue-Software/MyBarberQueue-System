namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class AddUserRequestDto
    {
        public Guid ShopId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true; // default to active
    }
}
