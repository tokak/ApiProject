namespace ApiProject.WepApi.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
