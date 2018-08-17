using MediatR;
using Notas02.Application.Cliente.Commands;
using Notas02.Application.Cliente.Validators;
using Notas02.Application.Core.Contracts.Repository;
using Notas02.Application.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models = Notas02.Application.Entities;

namespace Notas02.Application.Cliente
{
    public class ClienteCommandHandler :
        IRequestHandler<RegistrarClienteCommand, Notas02Notification>,
        IRequestHandler<EditarClienteCommand, Notas02Notification>,
        IRequestHandler<DeletarClienteCommand, Notas02Notification>
    {
        private readonly IWriteRepository<Models.Cliente> _writeRepository;

        public ClienteCommandHandler(IWriteRepository<Models.Cliente> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public Task<Notas02Notification> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
        {
            var entity = new Models.Cliente(Guid.Empty, request.Nome);
            var validator = new RegistrarClienteValidator();

            ValidateCliente(ref entity, validator);

            var result = validator.Validate(new Models.Cliente(Guid.Empty, request.Nome));

            if (result.IsValid)
            {
                _writeRepository.Add(new Models.Cliente(Guid.Empty, request.Nome));
                return Task.FromResult((Notas02Notification)new Notas02SuccessNotification());
            }

            var results = new Dictionary<string, string>();
            foreach (var err in result.Errors)
            {
                results.Add(err.PropertyName, err.ErrorMessage);
            }
            return Task.FromResult((Notas02Notification)new Notas02ErrorNotification(results));
        }

        public Task<Notas02Notification> Handle(EditarClienteCommand request, CancellationToken cancellationToken)
        {
            var entity = new Models.Cliente(Guid.Empty, request.Nome);
            var validator = new RegistrarClienteValidator();

            ValidateCliente(ref entity, validator);

            var result = validator.Validate(new Models.Cliente(Guid.Empty, request.Nome));

            if (result.IsValid)
            {
                _writeRepository.Edit(new Models.Cliente(request.Id, request.Nome));
                return Task.FromResult((Notas02Notification)new Notas02SuccessNotification());
            }

            var results = new Dictionary<string, string>();
            foreach (var err in result.Errors)
            {
                results.Add(err.PropertyName, err.ErrorMessage);
            }
            return Task.FromResult((Notas02Notification)new Notas02ErrorNotification(results));
        }

        public Task<Notas02Notification> Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
        {
            _writeRepository.Delete(request.Id);
            return Task.FromResult((Notas02Notification)new Notas02SuccessNotification());
        }

        private void ValidateCliente(ref Models.Cliente cliente, ClienteValidator validator)
        {
            cliente.ValidationResult = validator.Validate(cliente);
        }
    }
}