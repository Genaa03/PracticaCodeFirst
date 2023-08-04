﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica2CodeFirst.Models;
using Practica2CodeFirst.Respuestas;
using static Practica2CodeFirst.CQRS.Commands.PostCargo;
using static Practica2CodeFirst.CQRS.Commands.PostCiudad;
using static Practica2CodeFirst.CQRS.Commands.PostEmpleado;
using static Practica2CodeFirst.CQRS.Commands.PostSucursal;
using static Practica2CodeFirst.CQRS.Queries.QueryListaEmpleados;
using static Practica2CodeFirst.CQRS.Queries.QueryListaJefes;

namespace Practica2CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmpleadoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getListaEmpleados")]
        public async Task<RespuestaListaEmpleados> getListaEmpleados()
        {
            return await _mediator.Send(new GetListaEmpleados());
        }

        [HttpGet]
        [Route("getListaJefes")]
        public async Task<RespuestaListaEmpleados> getListaJefes()
        {
            return await _mediator.Send(new GetJefes());
        }

        [HttpPost]
        [Route("postEmpleado")]
        public async Task<RespuestaEmpleado> postEmpleado([FromBody] CommandEmpleado comando)
        {
            return await _mediator.Send(comando);
        }

        [HttpPost]
        [Route("postSucursal")]
        public async Task<Sucursal> postSucursal([FromBody] CommandSucursal comando)
        {
            return await _mediator.Send(comando);
        }

        [HttpPost]
        [Route("postCiudad")]
        public async Task<Ciudad> postCiudad([FromBody] CommandCiudad comando)
        {
            return await _mediator.Send(comando);
        }

        [HttpPost]
        [Route("postCargo")]
        public async Task<Cargo> postCargo([FromBody] CommandCargo comando)
        {
            return await _mediator.Send(comando);
        }
    }
}
