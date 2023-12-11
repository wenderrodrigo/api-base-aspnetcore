using WebApi.Domain.Entities.Enum;

namespace WebApi.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusType StatusId { get; set; }
    }
}
