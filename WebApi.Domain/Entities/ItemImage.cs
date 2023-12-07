using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public byte[] FileImagem { get; set; }

        [Column("date_register")]
        public DateTime DateRegister { get; set; }

        [ForeignKey("IdItem")]
        public Item Item { get; set; }
    }
}
