using FluentValidation;
using Notas02.Application.Cliente.Commands;

namespace Notas02.Application.Cliente.Validators
{
    public abstract class ClienteValidator : AbstractValidator<ClienteCommand>
    {
        protected void ValidaNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.");

            RuleFor(c => c.Nome)
                .MaximumLength(255)
                .WithMessage("Nome pode ter um máximo de 255 caracteres.");
        }
    }
}