using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities.Enum;

namespace WebApi.Domain.Entities
{
    [Table("user_residence")]
    public class UserResidence
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_user_condominium")]
        public int UserIdCondominium { get; set; }

        [Required]
        [Column("block_or_street")]
        [MaxLength(20)]
        public string BlockOrStreet { get; set; }

        [Required]
        [Column("number")]
        [MaxLength(11)]
        public string Number { get; set; }

        [Column("type_user")]
        public UserType UserType { get; set; }

        [ForeignKey("UserIdCondominium")]
        public UserCondominium UserCondominium { get; set; }
    }
}
