using FluentValidation;
using MediatR;
using Practica2CodeFirst.Context;
using Practica2CodeFirst.Models;

namespace Practica2CodeFirst.CQRS.Commands
{
    public class PostCargo
    {
        public class CommandCargo : IRequest<Cargo>
        {
            public string Nombre { get; set; }
        }

        public class CommandCargoValidator : AbstractValidator<CommandCargo>
        {
            public CommandCargoValidator()
            {
                RuleFor(c => c.Nombre).NotEmpty();
            }
        }
        public class CommandCargoHandler : IRequestHandler<CommandCargo, Cargo>
        {
            private readonly ContextBD _context;
            private readonly CommandCargoValidator _validator;
            public CommandCargoHandler(ContextBD context, CommandCargoValidator validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Cargo> Handle(CommandCargo request, CancellationToken cancellationToken)
            {
                Cargo cargo = new Cargo();
                try
                {
                    var validacion = await _validator.ValidateAsync(request);

                    if (validacion.IsValid)
                    {
                        cargo.Nombre = request.Nombre;

                        await _context.AddAsync(cargo);
                        await _context.SaveChangesAsync();
                    }
                }
                catch
                {
                    return null;
                }
                return cargo;
            }
        }
    }
}
