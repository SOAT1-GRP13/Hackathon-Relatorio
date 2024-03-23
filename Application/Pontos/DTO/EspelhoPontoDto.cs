namespace Application.Pontos.DTO
{
    public class EspelhoPontoDto
    {
        public Guid UserId { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public string UserEmail { get; set; } = string.Empty;
    }
}
