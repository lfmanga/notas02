using MediatR;
using Notas02.Application.Core.Notifications;

namespace Notas02.Application.Nota.Commands
{
    public abstract class NotaCommand : IRequest<Notas02Notification>
    {
    }
}
