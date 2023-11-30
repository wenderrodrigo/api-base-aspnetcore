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
    public class ItemImage
    {
        [Key]
        public int Id { get; set; }

        [Column("id_item")]
        public int IdItem { get; set; }

        [Column("path_imagem")]
        public string PathImagem { get; set; }

        [Column("date_register")]
        public DateTime DateRegister { get; set; }

        [ForeignKey("IdItem")]
        public Item Item { get; set; }
    }
}
