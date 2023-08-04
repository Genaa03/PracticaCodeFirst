using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica2CodeFirst.Respuestas;
using static Practica2CodeFirst.CQRS.Queries.QueryListaCargos;
using static Practica2CodeFirst.CQRS.Queries.QueryListaSucursales;

namespace Practica2CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SucursalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getSucursales")]
        public async Task<RespuestaSucursales> getSucursales()
        {
            return await _mediator.Send(new GetSucursales());
        }
    }
}