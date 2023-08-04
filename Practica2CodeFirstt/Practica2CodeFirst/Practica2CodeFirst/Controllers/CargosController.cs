using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica2CodeFirst.Respuestas;
using static Practica2CodeFirst.CQRS.Queries.QueryListaCargos;

namespace Practica2CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CargosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getCargos")]
        public async Task<RespuestaCargos> getCargos()
        {
            return await _mediator.Send(new GetCargos());
        }
    }
}
