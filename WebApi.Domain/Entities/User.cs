using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Domain.Entities.Enum;

namespace WebApi.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("cpf_cnpj")]
        public string CpfCnpj { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("type_user")]
        public UserType UserType { get; set; }

        [Column("password")]
        public string PasswordHash { get; set; }

        [Column("status_id")]
        public StatusType StatusId { get; set; }

        [Column("date_register")]
        public DateTime DateRegister { get; set; }

        [Column("date_change")]
        public Nullable<DateTime> DateChange { get; set; }

        public List<UserCondominium> UserCondominiums { get; set; } = new List<UserCondominium>();

        public List<CondominiumNotification> CondominiumNotifications { get; set; } = new List<CondominiumNotification>();
        public List<NotificationUser> NotificationUsers { get; set; } = new List<NotificationUser>();

    }
}
