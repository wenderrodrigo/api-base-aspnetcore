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
    public class UserCondominiumDTO
    {
        public int Id { get; set; }

        public int IdCondominium { get; set; }

        public int IdUser { get; set; }

        public StatusType StatusId { get; set; }
    }
}
