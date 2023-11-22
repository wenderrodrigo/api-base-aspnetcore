using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Domain.Entities.Enum;

namespace WebApi.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Column("status_id")]
        public StatusType StatusId { get; set; }

        // Relacionamento um-para-muitos com a classe Item
        public List<Item> Items { get; set; }

        public Category()
        {
            Items = new List<Item>();
        }
    }
}