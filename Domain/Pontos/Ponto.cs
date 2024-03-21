using Domain.Base.DomainObjects;

namespace Domain.Pontos
{
    public class Ponto : Entity, IAggregateRoot
    {
        public Ponto()
        {

        }
        public Ponto(DateTime dataHora, TipoPontoEnum tipoPonto, string? observacao, Guid userId)
        {
            DataHora = dataHora;
            TipoPonto = tipoPonto;
            Observacao = observacao;
            UserId = userId;
        }

        public DateTime DataHora { get; set; }

        public TipoPontoEnum TipoPonto { get; set; }

        public string? Observacao { get; set; }

        public Guid? UserId { get; set; }
    }
}
