using MediatR;
using Microsoft.EntityFrameworkCore;
using Practica2CodeFirst.Context;
using Practica2CodeFirst.Respuestas;

namespace Practica2CodeFirst.CQRS.Queries
{
    public class QueryListaCargos
    {
        public class GetCargos:IRequest<RespuestaCargos>
        {

        }
        public class GetCargosHandler : IRequestHandler<GetCargos, RespuestaCargos>
        {
            private readonly ContextBD _context;
            public GetCargosHandler(ContextBD context)
            {
                _context = context;
            }

            public async Task<RespuestaCargos> Handle(GetCargos request, CancellationToken cancellationToken)
            {
                RespuestaCargos respuesta = new RespuestaCargos();
                try
                {
                    respuesta.ListaCargos = await _context.Cargos.ToListAsync();

                    return respuesta;
                }
                catch
                {
                    respuesta.setMensajeError("Error al cargar los cargos", System.Net.HttpStatusCode.BadRequest);
                    return respuesta;
                }
            }
        }
    }
}
