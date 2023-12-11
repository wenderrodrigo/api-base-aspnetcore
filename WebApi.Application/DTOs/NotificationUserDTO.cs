namespace WebApi.Application.DTOs
{
    public class NotificationUserDTO
    {
        public int Id { get; set; }
        public int IdCondominiumNotification { get; set; }
        public int IdUser { get; set; }
        public bool Read { get; set; }
        public Nullable<DateTime> DateRead { get; set; }
        //public CondominiumNotificationDTO? CondominiumNotification { get; set; }
        //public UserDTO? User { get; set; }
    }
}
