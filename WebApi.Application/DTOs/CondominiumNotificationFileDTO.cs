namespace WebApi.Application.DTOs
{
    public class CondominiumNotificationFileDTO
    {
        public int Id { get; set; }
        public int IdCondominiumNotification { get; set; }
        public string PathFile { get; set; }
        public CondominiumNotificationDTO CondominiumNotification { get; set; } = new CondominiumNotificationDTO();
    }
}
