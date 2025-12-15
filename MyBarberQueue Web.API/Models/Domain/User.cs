namespace MyBarberQueue_Web.API.Model.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public Guid ShopId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Role { get; set; } = null!; // Owner, Barber, Receptionist

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Shop Shop { get; set; } = null!;

    }
}
