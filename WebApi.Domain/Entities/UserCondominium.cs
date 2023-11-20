using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entities
{
    public class UserCondominium
    {
        [Key]
        public int Id { get; set; }

        [Column("id_user")]
        public string IdUser { get; set; }

        [Column("id_condominium")]
        public int IdCondominium { get; set; }

        [Column("status_id")]
        public string? StatusId { get; set; }

        public User User { get; set; }
        public Condominium Condominium { get; set; }
    }
}
