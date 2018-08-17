﻿using FluentValidation.Results;
using System;

namespace Notas02.Application.Entities
{
    public class Nota
    {
        public Guid Id { get; set; }
        public DateTime Referencia { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorTotal { get { return ValorUnitario * Quantidade; } }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid
        {
            get
            {
                return ValidationResult != null && ValidationResult.IsValid;
            }
        }
    }
}