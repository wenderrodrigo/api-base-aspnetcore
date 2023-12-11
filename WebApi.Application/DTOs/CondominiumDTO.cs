using WebApi.Domain.Entities.Enum;

namespace WebApi.Application.DTOs
{
    public class CondominiumDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Cnpj { get; set; }

        public StatusType StatusId { get; set; }

        public DateTime DateRegister { get; set; }

        public Nullable<DateTime> DateChange { get; set; }

        public int IdUserCondominium { get; set; }
    }
}
