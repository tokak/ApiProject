namespace ApiProject.WepApi.Dtos.NotificationDtos
{
    public class UpdateNotificationDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
