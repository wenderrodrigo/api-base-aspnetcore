using WebApi.Domain.Entities.Enum;

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

        public StatusType StatusId { get; set; }

        public DateTime DateRegister { get; set; }

        public Nullable<DateTime> DateChange { get; set; }

        public int IdUserCondominium { get; set; }

        public List<UserResidenceDTO> UsersResidencesDTO { get; set; }
    }
}
