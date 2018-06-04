using System;

namespace Notas02.Application.Cliente.Commands
{
    public class RegistrarClienteCommand : ClienteCommand
    {
        public RegistrarClienteCommand()
        {
            Id = Guid.NewGuid();
        }
    }
}