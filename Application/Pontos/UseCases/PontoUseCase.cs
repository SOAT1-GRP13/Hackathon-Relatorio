using Domain.Pontos;

namespace Application.Pontos.UseCases
{
    public sealed class PontoUseCase : IPontoUseCase
    {
        private readonly IPontoRepository _pontoRepository;

        public PontoUseCase(
            IPontoRepository pontoRepository)
        {
            _pontoRepository = pontoRepository;
        }

        public async Task<bool> AdicionarPonto(DateTime dataHora, int tipoPonto, string? observacao, Guid userId)
        {
            var ponto = new Ponto(dataHora, (TipoPontoEnum)tipoPonto, observacao, userId);
            await _pontoRepository.Adicionar(ponto);
            return await _pontoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _pontoRepository?.Dispose();
        }
    }
}
