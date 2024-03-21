using RabbitMQ.Client;
using Domain.Configuration;
using Application.Pontos.DTO;
using Application.Pontos.Commands;
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
            var command = new GeraEspelhoDePontoCommand(espelhoPontoDto.UserId, espelhoPontoDto.Mes, espelhoPontoDto.Ano);
            mediatorHandler.EnviarComando<GeraEspelhoDePontoCommand, bool>(command).Wait();
        }
    }
}
