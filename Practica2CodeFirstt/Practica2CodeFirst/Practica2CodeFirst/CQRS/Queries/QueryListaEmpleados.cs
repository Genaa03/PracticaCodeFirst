using MediatR;
using Microsoft.EntityFrameworkCore;
using Practica2CodeFirst.Context;
using Practica2CodeFirst.Models;
using Practica2CodeFirst.Respuestas;
using System.Net;

namespace Practica2CodeFirst.CQRS.Queries
{
    public class QueryListaEmpleados
    {
        public class GetListaEmpleados:IRequest<RespuestaListaEmpleados>
        {

        }
        public class GetListaEmpleadosHandler : IRequestHandler<GetListaEmpleados, RespuestaListaEmpleados>
        {
            private readonly ContextBD _context;
            public GetListaEmpleadosHandler(ContextBD context)
            {
                _context = context;
            }
            public async Task<RespuestaListaEmpleados> Handle(GetListaEmpleados request, CancellationToken cancellationToken)
            {
                RespuestaListaEmpleados respuesta = new RespuestaListaEmpleados();
                try
                {
                    List<Empleado> lista= await _context.Empleados.Include(e => e.Sucursal).
                                                                   Include(e => e.Sucursal.Ciudad).
                                                                   Include(e => e.Cargo).
                                                                   ToListAsync();
                    List<EmpleadoDTO> listaDTO = new List<EmpleadoDTO>();
                    foreach (Empleado empleado in lista)
                    {
                        EmpleadoDTO emp = new EmpleadoDTO();
                        emp.Id = empleado.Id;
                        emp.Nombre = empleado.Nombre;
                        emp.Apellido = empleado.Apellido;
                        emp.Cargo = empleado.Cargo.Nombre;
                        emp.Sucursal = empleado.Sucursal.Nombre;
                        emp.Ciudad = empleado.Sucursal.Ciudad.Nombre;
                        emp.Jefe = empleado.Jefe.Nombre;
                        emp.DNI = empleado.Dni;
                        emp.FechaAlta = empleado.FechaAlta;
                        listaDTO.Add(emp);
                    }

                    respuesta.ListaEmpleados = listaDTO;

                    return respuesta;
                }
                catch
                {
                    respuesta.setMensajeError("Se produjo un error", HttpStatusCode.BadRequest);
                    return respuesta;
                }
            }
        }
    }
}
