namespace MyBarberQueue_Web.API.Models.Dtos
{
    public class AddQueueRequestDto
    {
        public Guid ShopId { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
