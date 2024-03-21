using FluentValidation;
using Domain.Base.Messages;

namespace Application.Pontos.Commands
{
    public class AdicionarPontoCommand : Command<bool>
    {
        public DateTime DataHora { get; set; }

        public int TipoPonto { get; set; }

        public string? Observacao { get; set; }

        public Guid UserId { get; set; }

        public AdicionarPontoCommand(DateTime dataHora, int tipoPonto, string? observacao, Guid userId)
        {
            DataHora = dataHora;
            TipoPonto = tipoPonto;
            Observacao = observacao;
            UserId = userId;
        }
        public override bool EhValido()
        {
            ValidationResult = new AdicionarPontoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarPontoCommandValidation : AbstractValidator<AdicionarPontoCommand>
        {
            public static string DataHoraErroMsg => "DataHora é obrigatório";
            public static string TipoPontoErroMsg => "TipoPonto é obrigatório";

            public static string UserIdErroMsg => "UserId é obrigatório";
            public AdicionarPontoCommandValidation()
            {
                RuleFor(c => c.DataHora)
                    .NotEmpty().WithMessage("DataHora é obrigatório");

                RuleFor(c => c.TipoPonto)
                    .NotNull().WithMessage("TipoPonto é obrigatório");

                RuleFor(c => c.UserId)
                    .NotEmpty().WithMessage("UserId é obrigatório");
            }
        }

    }
}
