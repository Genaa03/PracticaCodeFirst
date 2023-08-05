using FluentValidation;
using MediatR;
using Practica2CodeFirst.Context;
using Practica2CodeFirst.Respuestas;
using Microsoft.EntityFrameworkCore;

namespace Practica2CodeFirst.CQRS.Queries
{
    public class QueryEmpleadoByID
    {
        public class GetEmpleadoID : IRequest<RespuestaEmpleado>
        {
            public Guid Id { get; set; }
        }
        public class GetEmpleadoIDValidation : AbstractValidator<GetEmpleadoID>
        {
            public GetEmpleadoIDValidation()
            {
                RuleFor(e => e.Id).NotEmpty().WithMessage("ID vacio");
            }
        }
        public class GetEmpleadoIDHandler : IRequestHandler<GetEmpleadoID, RespuestaEmpleado>
        {
            private readonly ContextBD _context;
            private readonly GetEmpleadoIDValidation _validator;

            public GetEmpleadoIDHandler(ContextBD context,GetEmpleadoIDValidation validator)
            {
                _context = context;
                _validator = validator;
            }
            public async Task<RespuestaEmpleado> Handle(GetEmpleadoID request, CancellationToken cancellationToken)
            {
                RespuestaEmpleado respuesta = new RespuestaEmpleado();
                try
                {
                    var empleado = await _context.Empleados.FirstOrDefaultAsync(e=>e.Id.Equals(request.Id));

                    if(empleado != null)
                    {
                        respuesta.Nombre = empleado.Nombre;
                        respuesta.Apellido = empleado.Apellido;
                        respuesta.IdSucursal = empleado.IdSucursal;
                        respuesta.IdCargo = empleado.IdCargo;
                        respuesta.Dni = empleado.Dni;
                        respuesta.FechaAlta = empleado.FechaAlta;
                    }
                    else
                    {
                        respuesta.setMensajeError("No se obtuvo el empleado con ID " + request.Id, System.Net.HttpStatusCode.BadRequest);
                    }
                    
                }
                catch
                {
                    respuesta.setMensajeError("Error al obtener el empleado con ID " + request.Id, System.Net.HttpStatusCode.BadRequest);
                    return respuesta;
                }
                return respuesta;
            }
        }
    }
}
