using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("category")]
        public string? Category { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("image")]
        public string? Image { get; set; }

        [Column("id_user")]
        public int IdUser { get; set; }

        [Column("date_register")]
        public DateTime DateRegister { get; set; }

        [Column("date_change")]
        public Nullable<DateTime> DateChange { get; set; }
    }
}
