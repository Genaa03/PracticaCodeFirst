using MediatR;
using Practica2CodeFirst.Respuestas;
using Microsoft.EntityFrameworkCore;
using Practica2CodeFirst.Context;
using Practica2CodeFirst.Models;

namespace Practica2CodeFirst.CQRS.Queries
{
    public class QueryListaJefes
    {
        public class GetJefes:IRequest<RespuestaListaEmpleados>
        {

        }
        public class GetJefesHandler : IRequestHandler<GetJefes, RespuestaListaEmpleados>
        {
            private readonly ContextBD _context;
            public GetJefesHandler(ContextBD context)
            {
                _context = context;
            }

            public async Task<RespuestaListaEmpleados> Handle(GetJefes request, CancellationToken cancellationToken)
            {
                RespuestaListaEmpleados respuesta=new RespuestaListaEmpleados();
                try
                {
                    List<Empleado> lista = await _context.Empleados.Include(e=>e.Sucursal).
                                                                    Include(e=>e.Cargo).
                                                                    Where(e=>e.Cargo.Nombre.Equals("Jefe")).
                                                                    ToListAsync();
                    List<EmpleadoDTO> listaDTO = new List<EmpleadoDTO>();
                    foreach(Empleado emp in lista)
                    {
                        listaDTO.Add(new EmpleadoDTO
                        {
                            Id=emp.Id,
                            Nombre=emp.Nombre,
                            Apellido=emp.Apellido,
                            Cargo = emp.Cargo.Nombre,
                            Sucursal = emp.Sucursal.Nombre,
                            DNI = emp.Dni,
                            FechaAlta=emp.FechaAlta,
                            Jefe=emp.Jefe.Nombre,
                        });
                    }
                    respuesta.ListaEmpleados = listaDTO;
                    return respuesta;
                }
                catch
                {
                    respuesta.setMensajeError("Error al cargar los jefes",System.Net.HttpStatusCode.BadRequest);
                    return respuesta;
                }
            }
        }
    }
}
