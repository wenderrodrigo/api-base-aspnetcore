using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entities
{
    public class Condominium
    {
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("cnpj")]
        public string? Cnpj { get; set; }

        [Column("status_id")]
        public string? StatusId { get; set; }

        [Column("date_register")]
        public DateTime DateRegister { get; set; }

        [Column("date_change")]
        public Nullable<DateTime> DateChange { get; set; }

        public List<UserCondominium> userCondominiums { get; set; } = new List<UserCondominium>();
    }
}
