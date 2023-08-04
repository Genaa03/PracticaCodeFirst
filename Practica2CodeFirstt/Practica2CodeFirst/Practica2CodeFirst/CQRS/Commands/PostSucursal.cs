using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using Practica2CodeFirst.Models;
using Practica2CodeFirst.Context;
using Practica2CodeFirst.Respuestas;

namespace Practica2CodeFirst.CQRS.Commands
{
    public class PostSucursal
    {
        public class CommandSucursal : IRequest<Sucursal>
        {
            public string Nombre { get; set; }
            public Guid IdCiudad { get; set; }
        }
        public class CommandSucursalValidator : AbstractValidator<CommandSucursal>
        {
            public CommandSucursalValidator()
            {
                RuleFor(s => s.Nombre).NotEmpty().WithMessage("Nombre vacion");
                RuleFor(s => s.IdCiudad).NotEmpty().WithMessage("Ciudad vacia");
            }
        }
        public class CommandSucursalHandler : IRequestHandler<CommandSucursal, Sucursal>
        {
            private readonly ContextBD _context;
            private readonly CommandSucursalValidator _validator;
            public CommandSucursalHandler(ContextBD context, CommandSucursalValidator validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Sucursal> Handle(CommandSucursal request, CancellationToken cancellationToken)
            {
                Sucursal sucursal = new Sucursal();
                try
                {
                    var validacion = await _validator.ValidateAsync(request);
                    if (validacion.IsValid)
                    {
                        sucursal = new Sucursal
                        {
                            Nombre = request.Nombre,
                            IdCiudad = request.IdCiudad,
                        };
                        await _context.AddAsync(sucursal);
                        await _context.SaveChangesAsync();
                    }
                }
                catch
                {
                    return null;
                }
                return sucursal;
            }
        }
    }
}
