using Domain.Base.Data;

namespace Domain.Pontos
{
    public interface IPontoRepository : IRepository
    {
        Task<Ponto> Adicionar(Ponto ponto);
        Task<IEnumerable<Ponto>> ObterEspelhoDePonto(Guid userId, int mes, int ano);
    }
}
