using Api.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Validator
{
    public class PetValidator : AbstractValidator<Pet>
    {
        public PetValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O campo não pode ser vazio.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo.")
                .MinimumLength(5)
                .WithMessage("O tamanho mínimo é de 5 caracteres")
                .MaximumLength(50)
                .WithMessage("O tamanho maxímo é de 50 caracteres");

            RuleFor(a => a.Genre)
                .NotEmpty()
                .WithMessage("O campo não pode ser vazio.")
                .IsInEnum()
                .NotNull()
                .WithMessage("O campo Genero é obrigatório.");
            

            RuleFor(a => a.BreedId)
                .NotEmpty()
                .WithMessage("O campo não pode ser nulo.")
                .NotNull()
                .WithMessage("O campo é obrigatório.");
        }

    }
}
