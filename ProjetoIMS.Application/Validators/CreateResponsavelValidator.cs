using FluentValidation;
using ProjetoIMS.Application.DTOs.Responsavel;

namespace ProjetoIMS.Application.Validators
{
    public class CreateResponsavelDtoValidator : AbstractValidator<CreateResponsavelDto>
    {
        public CreateResponsavelDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(200).WithMessage("Nome deve ter no máximo 200 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email é obrigatório")
                .EmailAddress().WithMessage("Email inválido")
                .MaximumLength(200).WithMessage("Email deve ter no máximo 200 caracteres");

            RuleFor(x => x.Telefone)
                .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.Telefone))
                .WithMessage("Telefone deve ter no máximo 20 caracteres")
                .Matches(@"^\+?[\d\s\-\(\)]+$").When(x => !string.IsNullOrEmpty(x.Telefone))
                .WithMessage("Telefone inválido");
        }
    }
}
