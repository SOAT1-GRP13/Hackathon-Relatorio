using Domain.Base.Data;

namespace Domain.Pontos
{
    public interface IPontoRepository : IRepository
    {
        Task<IEnumerable<Ponto>> ObterEspelhoDePonto(Guid userId, int mes, int ano);
    }
}
