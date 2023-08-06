using MediatR;
using Microsoft.EntityFrameworkCore;
using Practica2CodeFirst.Context;

namespace Practica2CodeFirst.CQRS.Queries
{
    public class QueryCantidad
    {
        public class GetCantidad : IRequest<string>
        {

        }
        public class GetCantidadHandler : IRequestHandler<GetCantidad, string>
        {
            private readonly ContextBD _context;
            public GetCantidadHandler(ContextBD context)
            {
                _context = context;
            }
            public async Task<string> Handle(GetCantidad request, CancellationToken cancellationToken)
            {
                try
                {
                    var cant = await _context.Empleados.CountAsync();
                    var cant2 = await _context.Empleados.Where(a=>a.Sucursal.Nombre.Contains("Sucu 4")).CountAsync();

                    if(cant <= 0)
                    {
                        return "No hay empleados.";
                    }
                    if (cant2 <= 0)
                    {
                        return "No hay empleados en la sucursal dicha";
                    }

                    return "En la empresa hay " + cant + " de empleados, de los cuales " + cant2 + " son de la sucursal dicha";
                }
                catch
                {
                    return "No se pudo encontrar";
                }
            }
        }
    }
}
