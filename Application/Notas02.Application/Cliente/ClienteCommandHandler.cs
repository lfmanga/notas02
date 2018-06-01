using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notas02.Application.Cliente.Commands;
using Notas02.Application.Cliente.Validators;
using Notas02.Application.Core.Contracts.Repository;
using Notas02.Application.Core.Notifications;
using Models = Notas02.Application.Entities;

namespace Notas02.Application.Cliente
{
    public class ClienteCommandHandler : IRequestHandler<RegistrarClienteCommand, Notas02Notification>
    {
        private readonly IWriteRepository<Models.Cliente> _writeRepository;

        public ClienteCommandHandler(IWriteRepository<Models.Cliente> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public Task<Notas02Notification> Handle(RegistrarClienteCommand command, CancellationToken cancellationToken)
        {
            var validator = new RegistrarClienteValidator();
            var result = validator.Validate(command);
            var notification = new Notas02Notification(true);

            if (result.IsValid)
            {
                _writeRepository.Add(new Models.Cliente(command.Nome));
                return Task.FromResult(notification);
            }

            notification.Success = false;
            notification.Results = new Dictionary<string, string>();

            foreach (var err in result.Errors)
            {
                notification.Results.Add(err.PropertyName, err.ErrorMessage);
            }
            
            return Task.FromResult(notification);
        }
    }
}