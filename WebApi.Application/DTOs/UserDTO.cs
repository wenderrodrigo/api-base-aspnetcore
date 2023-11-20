using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities.Enum;
using WebApi.Domain.Entities;

namespace WebApi.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CpfCnpj { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public UserType UserType { get; set; }

        public string PasswordHash { get; set; }

        public string? StatusId { get; set; }

        public DateTime DateRegister { get; set; }

        public Nullable<DateTime> DateChange { get; set; }

        public int IdUserCondominium { get; set; }
    }
}
