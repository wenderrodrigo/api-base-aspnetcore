using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Column("status_id")]
        public int StatusId { get; set; }

        public List<Item> Items { get; set; }
    }
}
