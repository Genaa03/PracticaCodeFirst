using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using Practica2CodeFirst.Models;
using Practica2CodeFirst.Context;

namespace Practica2CodeFirst.CQRS.Commands
{
    public class PostCiudad
    {
        public class CommandCiudad:IRequest<Ciudad>
        {
            public string Nombre { get; set; }
        }

        public class CommandCiudadValidator : AbstractValidator<CommandCiudad>
        {
            public CommandCiudadValidator()
            {
                RuleFor(c => c.Nombre).NotEmpty();
            }
        }

        public class CommandCiudadHandler : IRequestHandler<CommandCiudad, Ciudad>
        {
            private readonly ContextBD _context;
            private readonly CommandCiudadValidator _validator;
            public CommandCiudadHandler(ContextBD context, CommandCiudadValidator validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Ciudad> Handle(CommandCiudad request, CancellationToken cancellationToken)
            {
                Ciudad ciudad = new Ciudad();
                try
                {
                    var validacion = await _validator.ValidateAsync(request);
                    if (validacion.IsValid)
                    {
                        ciudad.Nombre = request.Nombre;

                        await _context.AddAsync(ciudad);
                        await _context.SaveChangesAsync();
                    }
                }
                catch
                {
                    return null;
                }
                return ciudad;
            }
        }
    }
}
