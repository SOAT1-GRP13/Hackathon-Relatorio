namespace Application.Pontos.UseCases
{
    public interface IPontoUseCase : IDisposable
    {
        Task<bool> AdicionarPonto(DateTime dataHora, int tipoPonto, string? observacao, Guid userId);
    }
}
