using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Application.DTOs
{
    public class CondominiumDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Cnpj { get; set; }

        public string? StatusId { get; set; }

        public DateTime DateRegister { get; set; }

        public Nullable<DateTime> DateChange { get; set; }

        public int IdUserCondominium { get; set; }
    }
}
