using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities
{
    public class NotificationUser
    {
        [Key]
        public int Id { get; set; }

        [Column("id_condominium_notification")]
        public int IdCondominiumNotification { get; set; }

        [Column("id_user")]
        public int IdUser { get; set; }

        [Column("read")]
        public bool Read { get; set; }

        [Column("date_read")]
        public Nullable<DateTime> DateRead { get; set; }

        [ForeignKey("IdCondominiumNotification")]
        public CondominiumNotification CondominiumNotification { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
