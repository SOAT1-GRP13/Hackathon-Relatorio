using FluentValidation;
using Domain.Base.Messages;

namespace Application.Pontos.Commands
{
    public class GeraEspelhoDePontoCommand : Command<bool>
    {
        public Guid UserId { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public GeraEspelhoDePontoCommand(Guid userId, int mes, int ano)
        {
            UserId = userId;
            Mes = mes;
            Ano = ano;
        }

        public override bool EhValido()
        {
            ValidationResult = new GeraEspelhoDePontoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class GeraEspelhoDePontoCommandValidation : AbstractValidator<GeraEspelhoDePontoCommand>
        {
            public GeraEspelhoDePontoCommandValidation()
            {
                RuleFor(c => c.Mes)
                    .NotEmpty().WithMessage("Mes é obrigatório");

                RuleFor(c => c.Ano)
                    .NotNull().WithMessage("Ano é obrigatório");

                RuleFor(c => c.UserId)
                    .NotEmpty().WithMessage("UserId é obrigatório");
            }
        }

    }
}
