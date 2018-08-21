using MediatR;
using Notas02.Application.Core.Contracts.Repository;
using Notas02.Application.Core.Notifications;
using Notas02.Application.Nota.Commands;
using Notas02.Application.Nota.Validators;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models = Notas02.Application.Entities;

namespace Notas02.Application.Nota
{
    public class NotaCommandHandler :
        IRequestHandler<RegistrarNotaCommand, Notas02Notification>
    {
        private readonly IWriteRepository<Models.Nota> _writeRepository;

        public NotaCommandHandler(IWriteRepository<Models.Nota> writeRepository)
        {
            _writeRepository = writeRepository;
        }


        public Task<Notas02Notification> Handle(RegistrarNotaCommand request, CancellationToken cancellationToken)
        {
            Notas02Notification notification = new Notas02SuccessNotification();

            var validator = new RegistrarNotaValidator();
            var validationResult = validator.Validate(request);

            if(validationResult.IsValid)
            {

                return Task.FromResult(notification);
            }

            var results = new Dictionary<string, string>();
            foreach(var err in validationResult.Errors)
            {
                results.Add(err.PropertyName, err.ErrorMessage);
            }
            notification = new Notas02ErrorNotification(results);
            return Task.FromResult(notification);
        }
    }
}
