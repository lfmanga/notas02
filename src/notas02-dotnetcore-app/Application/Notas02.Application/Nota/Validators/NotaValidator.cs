using FluentValidation;
using System;
using Models = Notas02.Application.Entities;

namespace Notas02.Application.Nota.Validators
{
    public class NotaValidator :  AbstractValidator<Models.Nota>
    {
        public void ValidaReferencia()
        {
            RuleFor(n => n.Referencia)
                .GreaterThan(DateTime.Now)
                .WithMessage("A referência precisa ser menor ou igual que a data atual.");

            RuleFor(n => n.Referencia)
                .LessThan(DateTime.Now.AddMonths(-1))
                .WithMessage("A referência precisa ser maior que 1 mês.");
        }
        
        public void ValidaValorUnitario()
        {
            RuleFor(n => n.ValorUnitario)
                .LessThan(0)
                .WithMessage("O valor unitário não pode ser menor que zero");
        }

        public void ValidaQuantidade()
        {
            RuleFor(n => n.Quantidade)
                .LessThan(0)
                .WithMessage("A quantidade não pode ser menor que zero");
        }
    }
}
