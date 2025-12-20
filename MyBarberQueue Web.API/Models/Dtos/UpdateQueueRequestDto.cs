namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class UpdateQueueRequestDto
    {
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
