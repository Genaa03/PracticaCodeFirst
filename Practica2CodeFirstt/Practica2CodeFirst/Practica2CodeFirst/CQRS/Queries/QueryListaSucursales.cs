using MediatR;
using Practica2CodeFirst.Respuestas;
using Microsoft.EntityFrameworkCore;
using Practica2CodeFirst.Context;
using Practica2CodeFirst.Models;

namespace Practica2CodeFirst.CQRS.Queries
{
    public class QueryListaSucursales
    {
        public class GetSucursales : IRequest<RespuestaSucursales>
        {

        }
        public class GetSucursalesHandler : IRequestHandler<GetSucursales, RespuestaSucursales>
        {
            private readonly ContextBD _context;
            public GetSucursalesHandler(ContextBD context)
            {
                _context = context;
            }

            public async Task<RespuestaSucursales> Handle(GetSucursales request, CancellationToken cancellationToken)
            {
                RespuestaSucursales respuesta = new RespuestaSucursales();
                try
                {
                    List<Sucursal> lista = await _context.Sucursal.Include(s=>s.Ciudad).ToListAsync();
                    List<SucursalDTO> listaDTO = new List<SucursalDTO>();

                    foreach (Sucursal sucursal in lista)
                    {
                        listaDTO.Add(new SucursalDTO
                        {
                            Id=sucursal.Id,
                            Nombre=sucursal.Nombre,
                        });
                    }

                    respuesta.ListaSucursales = listaDTO;
                    return respuesta;
                }
                catch
                {
                    respuesta.setMensajeError("Error al cargar las sucursales",System.Net.HttpStatusCode.BadRequest);
                    return respuesta;
                }
            }
        }
    }
}
