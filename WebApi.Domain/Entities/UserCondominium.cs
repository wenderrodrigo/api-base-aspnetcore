using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities.Enum;

namespace WebApi.Domain.Entities
{
    public class UserCondominium
    {
        [Key]
        public int Id { get; set; }

        [Column("id_user")]
        public int IdUser { get; set; }

        [Column("id_condominium")]
        public int IdCondominium { get; set; }

        [Column("status_id")]
        public StatusType StatusId { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }

        [ForeignKey("IdCondominium")]
        public Condominium Condominium { get; set; }
    }

}
