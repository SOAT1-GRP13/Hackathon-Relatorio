using Domain.Pontos;
using Application.Pontos.Queries.DTO;

namespace Application.Pontos.Queries
{
    public class PontoQueries : IPontoQueries
    {
        private readonly IPontoRepository _pontoRepository;

        public PontoQueries(IPontoRepository pontoRepository)
        {
            _pontoRepository = pontoRepository;
        }

        public async Task<List<PontoDto>> ObterEspelhoDePonto(Guid userId, int mes, int ano)
        {
            var pontos = await _pontoRepository.ObterEspelhoDePonto(userId, mes, ano);
            if (pontos == null) return new List<PontoDto>();

            return pontos.Select(ponto => new PontoDto
            {
                Id = ponto.Id,
                UserId = ponto.UserId,
                DataHora = TimeZoneInfo.ConvertTimeFromUtc(ponto.DataHora, TimeZoneInfo.Local),
                TipoPonto = (int)ponto.TipoPonto,
                TipoPontoDescricao = ponto.TipoPonto.ToString(),
                Observacao = ponto.Observacao
            }).ToList();
        }
    }
}
