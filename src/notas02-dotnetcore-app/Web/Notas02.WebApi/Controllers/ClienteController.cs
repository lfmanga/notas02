using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Notas02.Application.Cliente.Commands;
using Notas02.Application.Core.Contracts.Repository;
using System;
using Models = Notas02.Application.Entities;

namespace Notas02.WebApi.Controllers
{
    [Authorize("Bearer")]
    [EnableCors("AllowAllOrigin")]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private IMediator _mediator;
        private readonly IReadRepository<Models.Cliente> _readRepository;

        public ClienteController(IReadRepository<Models.Cliente> readRepository, IMediator mediator)
        {
            _mediator = mediator;
            _readRepository = readRepository;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_readRepository.List());

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]Guid id) => Ok(_readRepository.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody]RegistrarClienteCommand cliente) => Ok(_mediator.Send(cliente).Result);

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody] EditarClienteCommand cliente)
        {
            cliente.Id = id;
            return Ok(_mediator.Send(cliente).Result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            var command = new DeletarClienteCommand(id);
            return Ok(_mediator.Send(command));
        }
    }
}