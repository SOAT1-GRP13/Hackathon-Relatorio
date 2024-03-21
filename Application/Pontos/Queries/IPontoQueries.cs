using Application.Pontos.Queries.DTO;

namespace Application.Pontos.Queries
{
    public interface IPontoQueries
    {
        Task<List<PontoDto>> ObterEspelhoDePonto(Guid userId, int mes, int ano);
    }
}
