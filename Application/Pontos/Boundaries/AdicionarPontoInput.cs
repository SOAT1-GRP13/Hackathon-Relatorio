using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Application.Pontos.Boundaries
{
    public class AdicionarPontoInput
    {

        [Required]
        [SwaggerSchema(
            Description = "Tipo do ponto",
            Format = "int")]
        public int TipoPonto { get; set; }

        [Required]
        [SwaggerSchema(
            Title = "Observacao",
            Format = "string")]
        public string? Observacao { get; set; }

    }
}
