namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class AddTicketRequestDto
    {
        public Guid QueueId { get; set; }

        public string TicketNumber { get; set; } = null!;
        public string Status { get; set; } = "Waiting";
    }
}
