using MediatR;
using Practica2CodeFirst.Respuestas;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Practica2CodeFirst.Models;
using Practica2CodeFirst.Context;
using System.Net;

namespace Practica2CodeFirst.CQRS.Commands
{
    public class PostEmpleado
    {
        public class CommandEmpleado : IRequest<RespuestaEmpleado>
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public Guid IdCargo { get; set; }
            public Guid IdSucursal { get; set; }
            public string Dni { get; set; }
            public DateTime FechaAlta { get; set; }
            public Guid IdJefe { get; set; }

        }

        public class CommandEmpleadoValidation : AbstractValidator<CommandEmpleado>
        {
            public CommandEmpleadoValidation()
            {
                RuleFor(c => c.Nombre).NotEmpty().WithMessage("Nombre vacio");
                RuleFor(c => c.Apellido).NotEmpty().WithMessage("Apellido vacio");
                RuleFor(c => c.IdCargo).NotEmpty().WithMessage("Cargo vacio");
                RuleFor(c => c.IdSucursal).NotEmpty().WithMessage("Sucursal vacia");
                RuleFor(c => c.Dni).NotEmpty().WithMessage("Dni vacio");
                RuleFor(c => c.FechaAlta).NotEmpty().WithMessage("Fecha Alta vacia");
                RuleFor(c => c.IdJefe).NotEmpty().WithMessage("Jefe vacio");
            }

        }

        public class CommandEmpleadoHandler : IRequestHandler<CommandEmpleado, RespuestaEmpleado>
        {
            private readonly ContextBD _context;
            private readonly CommandEmpleadoValidation _validator;
            public CommandEmpleadoHandler(ContextBD context, CommandEmpleadoValidation validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<RespuestaEmpleado> Handle(CommandEmpleado request, CancellationToken cancellationToken)
            {
                RespuestaEmpleado respuesta = new RespuestaEmpleado();
                try
                {
                    var validacion = _validator.Validate(request);
                    if (!validacion.IsValid)
                    {
                        respuesta.setMensajeError("Validacion erronea.", HttpStatusCode.BadRequest);
                        return respuesta;
                    }
                    await _context.Empleados.AddAsync(new Empleado
                    {
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                        IdCargo = request.IdCargo,
                        IdSucursal = request.IdSucursal,
                        FechaAlta = request.FechaAlta,
                        Dni = request.Dni,
                        IdJefe = request.IdJefe,
                    });
                    await _context.SaveChangesAsync();

                    respuesta.Nombre = request.Nombre;
                    respuesta.Apellido = request.Apellido;
                    respuesta.IdCargo = request.IdCargo;
                    respuesta.IdSucursal = request.IdSucursal;
                    respuesta.FechaAlta = request.FechaAlta;
                    respuesta.Dni = request.Dni;
                    respuesta.IdJefe = request.IdJefe;


                }
                catch
                {
                    respuesta.setMensajeError("Error al cargar el nuevo empleado.", HttpStatusCode.BadRequest);
                    return respuesta;
                }
                return respuesta;
            }
        }
    }
}
