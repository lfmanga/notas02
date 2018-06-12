using System;

namespace Notas02.Application.Cliente.Commands
{
    public class EditarClienteCommand : ClienteCommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}