using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApi.Domain.Entities;
using WebApi.Domain.Entities.Enum;

namespace WebApi.Application.DTOs
{
    public class UserResidenceDTO
    {
        public int Id { get; set; }
        
        public int UserIdCondominium { get; set; }
        
        public string BlockOrStreet { get; set; }
        
        public string Number { get; set; }
        
        public UserType UserType { get; set; }
    }
}
