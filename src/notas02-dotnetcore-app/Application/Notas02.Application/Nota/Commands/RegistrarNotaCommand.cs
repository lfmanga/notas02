using MediatR;
using Notas02.Application.Core.Notifications;
using Models = Notas02.Application.Entities;

namespace Notas02.Application.Nota.Commands
{
    public class RegistrarNotaCommand : Models.Nota, IRequest<Notas02Notification>
    {

    }
}
