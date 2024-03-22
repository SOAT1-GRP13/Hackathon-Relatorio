using MediatR;
using Infra.Pontos;
using Domain.Pontos;
using Infra.Pontos.Repository;
using Application.Pontos.Queries;
using Infra.Services.EmailService;
using Application.Pontos.Commands;
using Application.Pontos.Handlers;
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
            services.AddScoped<IPontoRepository, PontoRepository>();
            services.AddScoped<IPontoQueries, PontoQueries>();
            services.AddScoped<PontosContext>();

            services.AddScoped<IRequestHandler<GeraEspelhoDePontoCommand, bool>, GeraEspelhoDePontoCommandHandler>();
            services.AddScoped<IEmailSender, EmailSender>();

        }
    }
}
