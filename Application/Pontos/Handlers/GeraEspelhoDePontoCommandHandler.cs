using MediatR;
using System.Text;
using Domain.Base.DomainObjects;
using Application.Pontos.Queries;
using Application.Pontos.Commands;
using Application.Pontos.Queries.DTO;
using Domain.Base.Communication.Mediator;
using Application.Common.Interfaces.Services;
using Domain.Base.Messages.CommonMessages.Notifications;
using Application.Models.Email;
using Domain.Pontos;

namespace Application.Pontos.Handlers
{
    public class GeraEspelhoDePontoCommandHandler : IRequestHandler<GeraEspelhoDePontoCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPontoQueries _pontoQueries;
        private readonly IEmailSender _emailSender;

        public GeraEspelhoDePontoCommandHandler(IMediatorHandler mediatorHandler, IPontoQueries pontoQueries, IEmailSender emailSender)
        {
            _mediatorHandler = mediatorHandler;
            _pontoQueries = pontoQueries;
            _emailSender = emailSender;
        }

        public async Task<bool> Handle(GeraEspelhoDePontoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido())
            {
                foreach (var error in message.ValidationResult.Errors)
                    await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));

                return false;
            }

            List<PontoDto> espelhoDePonto;
            try
            {
                espelhoDePonto = await _pontoQueries.ObterEspelhoDePonto(message.UserId, message.Mes, message.Ano);
            }
            catch (DomainException ex)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, ex.Message));
                return false;
            }

            if (espelhoDePonto.Count <= 0)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, "Erro ao gerar espelho de ponto!"));
                return false;
            }

            var email = montaCorpoEmail(espelhoDePonto);
            await _emailSender.SendEmailAsync(email);

            return true;
        }

        private EmailMessage montaCorpoEmail(List<PontoDto> espelhoDePonto) 
        {
            var corpoEmail = new StringBuilder();

            var gruposPorData = espelhoDePonto
                .GroupBy(p => p.DataHora.Date)
                .ToList();

            foreach (var grupo in gruposPorData)
            {
                var entrada = "";
                var almoco = "";
                var retorno = "";
                var saida = "";
                var pontosDoDia = grupo.OrderBy(p => p.DataHora).ToList();
                var dia = grupo.First().DataHora.Date;
                corpoEmail.AppendLine($"Data: {dia.ToString("dd/MM/yyyy")}");

                foreach (var ponto in pontosDoDia)
                {
                    switch (ponto.TipoPonto)
                    {
                        case (int)TipoPontoEnum.Entrada:
                            entrada = ponto.DataHora.ToString("HH:mm");
                            break;
                        case (int)TipoPontoEnum.Retorno:
                            retorno = ponto.DataHora.ToString("HH:mm");
                            break;
                        case (int)TipoPontoEnum.Almoco:
                            almoco = ponto.DataHora.ToString("HH:mm");
                            break;
                        case (int)TipoPontoEnum.Saida:
                            saida = ponto.DataHora.ToString("HH:mm");
                            break;
                    }
                }

                corpoEmail.AppendLine($"Data: {dia.ToString("dd/MM/yyyy")}");
                corpoEmail.AppendLine($"Entrada: {entrada} - Almoco: {almoco} - Retorno: {retorno} - Saída: {saida}");
            }


            corpoEmail.AppendLine($"Total de horas trabalhadas: {calculaHorasTrabalhadas(espelhoDePonto, gruposPorData)} horas");

            var email = new EmailMessage();
            email.Subject = "Espelho de Ponto";
            email.To = ""; //TODO -> Adicionar email do usuário
            email.Body = corpoEmail.ToString();

            return email;
        }

        private string calculaHorasTrabalhadas(List<PontoDto> espelhoDePonto, List<IGrouping<DateTime, PontoDto>> gruposPorData)
        {
            TimeSpan totalHorasTrabalhadas = TimeSpan.Zero;

            foreach (var grupo in gruposPorData)
            {
                var pontosDoDia = grupo.OrderBy(p => p.DataHora).ToList();
                TimeSpan horasTrabalhadasNoDia = TimeSpan.Zero;
                DateTime? inicioPeriodo = null;

                foreach (var ponto in pontosDoDia)
                {
                    switch (ponto.TipoPonto)
                    {
                        case (int)TipoPontoEnum.Entrada:
                        case (int)TipoPontoEnum.Retorno:
                            inicioPeriodo = ponto.DataHora;
                            break;
                        case (int)TipoPontoEnum.Almoco:
                        case (int)TipoPontoEnum.Saida:
                            if (inicioPeriodo.HasValue)
                            {
                                horasTrabalhadasNoDia += ponto.DataHora - inicioPeriodo.Value;
                                inicioPeriodo = null; // Reseta o início do período para o próximo cálculo
                            }
                            break;
                    }
                }

                totalHorasTrabalhadas += horasTrabalhadasNoDia;
            }

            //return totalHorasTrabalhadas.TotalHours;

            int horas = (int)totalHorasTrabalhadas.TotalHours;
            int minutos = (int)((totalHorasTrabalhadas.TotalHours - horas) * 60);

            // Retorna o resultado formatado
            return $"{horas}:{minutos:D2}";
        }
    }
}
