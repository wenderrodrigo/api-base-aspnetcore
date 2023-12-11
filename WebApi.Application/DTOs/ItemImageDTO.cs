namespace WebApi.Application.DTOs
{
    public class ItemImageDTO
    {
        public int Id { get; set; }

        public int IdItem { get; set; }

        public string PathImagem { get; set; }

        public byte[] FileImagem { get; set; }

        public DateTime DateRegister { get; set; }

    }
}
