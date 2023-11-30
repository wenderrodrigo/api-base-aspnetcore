using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("id_category")]
        public int IdCategory { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("id_user")]
        public int IdUser { get; set; }

        [Column("date_register")]
        public DateTime DateRegister { get; set; }

        [Column("date_change")]
        public DateTime? DateChange { get; set; }

        [ForeignKey("IdCategory")]
        public Category Category { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }

        public List<ItemImage> ItemImages { get; set; } = new List<ItemImage>();
    }
}
