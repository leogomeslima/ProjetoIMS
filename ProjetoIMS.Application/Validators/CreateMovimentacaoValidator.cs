using FluentValidation;
using ProjetoIMS.Application.DTOs.Movimentacao;

namespace ProjetoIMS.Application.Validators
{
    public class CreateMovimentacaoDtoValidator : AbstractValidator<CreateMovimentacaoDto>
    {
        public CreateMovimentacaoDtoValidator()
        {
            RuleFor(x => x.AtivoId)
                .NotEmpty().WithMessage("Ativo é obrigatório");

            RuleFor(x => x.Motivo)
                .IsInEnum().WithMessage("Motivo inválido");

            RuleFor(x => x.LocalizacaoDestinoId)
                .NotEqual(x => x.LocalizacaoOrigemId)
                .When(x => x.LocalizacaoOrigemId.HasValue && x.LocalizacaoDestinoId.HasValue)
                .WithMessage("Localização de origem e destino não podem ser iguais");

            RuleFor(x => x.Observacoes)
                .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Observacoes))
                .WithMessage("Observações devem ter no máximo 1000 caracteres");
        }
    }

}
