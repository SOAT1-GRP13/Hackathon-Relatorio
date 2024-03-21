using MediatR;
using Domain.Base.DomainObjects;
using Application.Pontos.Commands;
using Application.Pontos.UseCases;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.CommonMessages.Notifications;


namespace Application.Pontos.Handlers
{
    public class AdicionarPontoCommandHandler : IRequestHandler<AdicionarPontoCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPontoUseCase _pontoUseCase;

        public AdicionarPontoCommandHandler(IMediatorHandler mediatorHandler, IPontoUseCase pontoUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _pontoUseCase = pontoUseCase;
        }

        public async Task<bool> Handle(AdicionarPontoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido())
            {
                foreach (var error in message.ValidationResult.Errors)
                    await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));

                return false;
            }

            bool retorno;
            try
            {
                retorno = await _pontoUseCase.AdicionarPonto(message.DataHora, message.TipoPonto, message.Observacao, message.UserId);
            }
            catch (DomainException ex)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, ex.Message));
                return false;
            }

            if (!retorno)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, "Erro ao adicionar o registro de ponto!"));
                return false;
            }

            return true;
        }
    }
}
