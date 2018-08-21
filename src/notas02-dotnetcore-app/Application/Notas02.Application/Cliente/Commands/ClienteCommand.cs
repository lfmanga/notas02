using MediatR;
using Notas02.Application.Core.Notifications;

namespace Notas02.Application.Cliente.Commands
{
    public abstract class ClienteCommand : IRequest<Notas02Notification>
    {

    }
}