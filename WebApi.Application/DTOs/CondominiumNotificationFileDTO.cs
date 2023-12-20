using System.Buffers.Text;

namespace WebApi.Application.DTOs
{
    public class CondominiumNotificationFileDTO
    {
        public int Id { get; set; }
        public int IdCondominiumNotification { get; set; }
        public string NameFile { get; set; }
        public dynamic PathFile { get; set; }
        public CondominiumNotificationDTO? CondominiumNotification { get; set; }
    }
}
