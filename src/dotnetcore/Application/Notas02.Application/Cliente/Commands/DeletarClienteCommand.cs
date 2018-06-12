using System;
using MediatR;
using Notas02.Application.Core.Notifications;

namespace Notas02.Application.Cliente.Commands
{
    public class DeletarClienteCommand : IRequest<Notas02Notification>
    {
        public Guid Id { get; set; }
        public DeletarClienteCommand(Guid id)
        {
            Id = id;
        }
    }
}