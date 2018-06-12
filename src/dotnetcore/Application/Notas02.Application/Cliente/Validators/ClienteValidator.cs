using FluentValidation;
using Notas02.Application.Cliente.Commands;
using Models = Notas02.Application.Entities;

namespace Notas02.Application.Cliente.Validators
{
    public abstract class ClienteValidator : AbstractValidator<Models.Cliente>
    {
        protected void ValidaNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.");

            RuleFor(c => c.Nome)
                .MaximumLength(255)
                .WithMessage("O nome pode ter no máximo de 255 caracteres.");
        }
    }
}