using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int IdCategory { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public DateTime DateChange { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
