using MediatR;
using Infra.Services.EmailService;
using Domain.Base.Communication.Mediator;
using Application.Common.Interfaces.Services;
using Domain.Base.Messages.CommonMessages.Notifications;

namespace API.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Domain Notifications 
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Notificacao
            //services.AddScoped<IPedidoNotificacaoUseCase, PedidoNotificacaoUseCase>();
            services.AddScoped<IEmailSender, EmailSender>();
            //services.AddScoped<IRequestHandler<NotificaPedidoPagamentoAprovadoCommand, NotificacaoEnviadaPedidoDto?>, NotificaPedidoPagamentoAprovadoCommandHandler>();
            //services.AddScoped<IRequestHandler<NotificaPedidoPagamentoReprovadoCommand, NotificacaoEnviadaPedidoDto?>, NotificaPedidoPagamentoReprovadoCommandHandler>();
            //services.AddScoped<IRequestHandler<NotificaPedidoProntoCommand, NotificacaoEnviadaPedidoDto?>, NotificaPedidoProntoCommandHandler>();

        }
    }
}
