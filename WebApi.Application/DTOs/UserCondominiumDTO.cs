using WebApi.Domain.Entities.Enum;

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
