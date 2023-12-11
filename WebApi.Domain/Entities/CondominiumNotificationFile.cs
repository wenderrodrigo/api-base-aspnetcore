using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities
{
    public class CondominiumNotificationFile
    {
        [Key]
        public int Id { get; set; }

        [Column("id_condominium_otification")]
        public int IdCondominiumNotification { get; set; }

        [Column("path_file")]
        public string PathFile { get; set; }

        [ForeignKey("IdCondominiumNotification")]
        public CondominiumNotification CondominiumNotification { get; set; }

    }
}
