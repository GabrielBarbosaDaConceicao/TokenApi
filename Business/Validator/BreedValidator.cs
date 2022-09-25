using Api.Domain.Entities;
using FluentValidation;

namespace Business.Validator
{
    public class BreedValidator : AbstractValidator<Breed>
    {
        public BreedValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório.")
                .MinimumLength(5)
                .WithMessage("O tamanho mínimo é de 5 caracteres.")
                .MaximumLength(50)
                .WithMessage("O tamanho máximo é de 50 caracteres.");

            RuleFor(a => a.PetType)
                 .NotEmpty()
                 .WithMessage("O campo não pode ser vazio.")
                 .NotNull()
                 .WithMessage("O campo não pode ser nullo.")
                 .IsInEnum()
                 .WithMessage("Tipo inválido.");
        }
    }
}
