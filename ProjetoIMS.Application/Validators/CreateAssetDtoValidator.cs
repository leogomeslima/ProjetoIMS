using FluentValidation;
using ProjetoIMS.Application.DTOs.Asset;

namespace ProjetoIMS.Application.Validators
{
    public class CreateAssetDtoValidator : AbstractValidator<CreateAssetDto>
    {
        public CreateAssetDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(200).WithMessage("Nome deve ter no máximo 200 caracteres");

            RuleFor(x => x.CodigoPatrimonio)
                .NotEmpty().WithMessage("Código de patrimônio é obrigatório")
                .MaximumLength(50).WithMessage("Código de patrimônio deve ter no máximo 50 caracteres");

            RuleFor(x => x.Categoria)
                .NotEmpty().WithMessage("Categoria é obrigatória")
                .MaximumLength(100).WithMessage("Categoria deve ter no máximo 100 caracteres");

            RuleFor(x => x.DataCompra)
                .NotEmpty().WithMessage("Data de compra é obrigatória")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Data de compra não pode ser futura");

            RuleFor(x => x.ValorCompra)
                .GreaterThan(0).WithMessage("Valor de compra deve ser maior que zero");

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
