namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class UpdateTicketRequestDto
    {
        public string Status { get; set; } = null!;
        public DateTime? CalledAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
