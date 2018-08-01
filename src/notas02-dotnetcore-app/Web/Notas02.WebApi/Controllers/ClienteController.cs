using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notas02.Application.Core.Contracts.Repository;
using Notas02.Application.Cliente.Commands;
using Models = Notas02.Application.Entities;
using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("Guid:id")]
        public IActionResult Get(Guid id) => Ok(_readRepository.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody]RegistrarClienteCommand cliente) => Ok(_mediator.Send(cliente).Result);

        [HttpPut("Guid:id")]
        public IActionResult Put(Guid id, [FromBody] EditarClienteCommand cliente)
        {
            cliente.Id = id;
            return Ok(_mediator.Send(cliente).Result);
        }

        [HttpDelete("Guid:id")]
        public IActionResult Delete(Guid id)
        {
            var command = new DeletarClienteCommand(id);
            return Ok(_mediator.Send(command));
        }
    }
}