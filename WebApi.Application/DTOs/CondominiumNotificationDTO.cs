using WebApi.Domain.Entities.Enum;

namespace WebApi.Application.DTOs
{
    public class CondominiumNotificationDTO
    {
        public int Id { get; set; }
        public int IdCondominium { get; set; }
        public TypeReceiving IdTypeReceiving { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int IdUserCreate { get; set; }
        public DateTime DateRegister { get; set; }
        public List<CondominiumNotificationFileDTO>? CondominiumNotificationFiles { get; set; }
        public List<NotificationUserDTO?>? NotificationUsers { get; set; }
    }
}
