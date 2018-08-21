using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Notas02.Application.Core.Contracts.Repository;
using Notas02.Application.Nota.Commands;
using Models = Notas02.Application.Entities;

namespace Notas02.WebApi.Controllers
{
    // [Authorize("Bearer")]
    [EnableCors("AllowAllOrigin")]
    [Route("api/[controller]")]
    public class NotaController : Controller
    {
        private IMediator _mediator;
        private readonly IReadRepository<Models.Nota> _readRepository;

        public NotaController(IMediator mediator, IReadRepository<Models.Nota> readRepository)
        {
            _mediator = mediator;
            _readRepository = readRepository;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_readRepository.List());

        [HttpPost]
        public IActionResult Post([FromBody]RegistrarNotaCommand command) => Ok(_mediator.Send(command).Result);
    }
}