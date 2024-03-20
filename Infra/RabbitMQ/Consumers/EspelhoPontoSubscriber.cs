using RabbitMQ.Client;
using Domain.Configuration;
using Application.Pontos.DTO;
using Microsoft.Extensions.Options;
using Domain.Base.Communication.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.RabbitMQ.Consumers
{
    public class EspelhoPontoSubscriber : RabbitMQSubscriber
    {
        public EspelhoPontoSubscriber(IServiceScopeFactory scopeFactory, IOptions<Secrets> options, IModel model) : base(options.Value.ExchangeEspelhoPonto, options.Value.QueueEspelhoPonto, scopeFactory, model) { }

        protected override void InvokeCommand(EspelhoPontoDto espelhoPontoDto, IMediatorHandler mediatorHandler)
        {
            /*var input = new PedidoInput(pedidoDto);
            var command = new NotificaPedidoPagamentoAprovadoCommand(input);
            mediatorHandler.EnviarComando<NotificaPedidoPagamentoAprovadoCommand, NotificacaoEnviadaPedidoDto?>(command).Wait();*/
        }
    }
}
