using FluentValidation;
using ProjetoIMS.Application.DTOs.Asset;

namespace ProjetoIMS.Application.Validators
{
    public class UpdateAssetDtoValidator : AbstractValidator<UpdateAssetDto>
    {
        public UpdateAssetDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(200).WithMessage("Nome deve ter no máximo 200 caracteres");

            RuleFor(x => x.Categoria)
                .NotEmpty().WithMessage("Categoria é obrigatória")
                .MaximumLength(100).WithMessage("Categoria deve ter no máximo 100 caracteres");

            RuleFor(x => x.TaxaDepreciacao)
                .InclusiveBetween(0, 100).When(x => x.TaxaDepreciacao.HasValue)
                .WithMessage("Taxa de depreciação deve estar entre 0 e 100");

            RuleFor(x => x.NumeroSerie)
                .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.NumeroSerie))
                .WithMessage("Número de série deve ter no máximo 100 caracteres");

            RuleFor(x => x.Observacoes)
                .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Observacoes))
                .WithMessage("Observações devem ter no máximo 1000 caracteres");
        }
    }
}
