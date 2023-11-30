using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;

namespace WebApi.Domain.Entities
{
    public class ItemImageDTO
    {
        public int Id { get; set; }

        public int IdItem { get; set; }

        public string PathImagem { get; set; }

        public DateTime DateRegister { get; set; }

        public ItemDTO ItemDTO { get; set; }
    }
}
