using FluentValidation;
using ProjetoIMS.Application.DTOs.Localizacao;

namespace ProjetoIMS.Application.Validators
{
    public class CreateLocalizacaoDtoValidator : AbstractValidator<CreateLocalizacaoDto>
    {
        public CreateLocalizacaoDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(200).WithMessage("Nome deve ter no máximo 200 caracteres");

            RuleFor(x => x.Descricao)
                .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Descricao))
                .WithMessage("Descrição deve ter no máximo 500 caracteres");
        }
    }
}
