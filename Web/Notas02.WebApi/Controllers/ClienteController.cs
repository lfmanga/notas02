using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notas02.Application.Core.Contracts.Repository;
using Notas02.Application.Cliente.Commands;
using Models = Notas02.Application.Entities;

namespace Notas02.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private IMediator _mediator;
        private readonly INotas02Repository<Models.Cliente> _repository;

        public ClienteController(INotas02Repository<Models.Cliente> repository, IMediator mediator)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.List());
        }

        [HttpPost]
        public IActionResult Post([FromBody]RegistrarClienteCommand cliente)
        {
            var result = _mediator.Send(cliente).Result;
            return Ok(result);
        }
    }
}