using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Domain.Entities.Enum;

namespace WebApi.Domain.Entities
{
    public class CondominiumNotification
    {
        [Key]
        public int Id { get; set; }

        [Column("id_condominium")]
        public int IdCondominium { get; set; }

        [Column("id_type_receiving")]
        public TypeReceiving IdTypeReceiving { get; set; }

        [Column("title")]
        [StringLength(40)]
        public string Title { get; set; }

        [Column("message")]
        public string Message { get; set; }

        [Column("id_user_create")]
        public int IdUserCreate { get; set; }

        [Column("date_register")]
        public DateTime DateRegister { get; set; }

        [ForeignKey("IdCondominium")]
        public Condominium Condominium { get; set; }

        [ForeignKey("IdUserCreate")]
        public User UserCreate { get; set; }

        public List<CondominiumNotificationFile> CondominiumNotificationFiles { get; set; } = new List<CondominiumNotificationFile>();
        public List<NotificationUser> NotificationUsers { get; set; }
    }
}
