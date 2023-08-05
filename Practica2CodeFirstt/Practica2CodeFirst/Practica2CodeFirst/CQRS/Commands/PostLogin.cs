using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using Practica2CodeFirst.Models;
using Practica2CodeFirst.Context;
using Practica2CodeFirst.Respuestas;

namespace Practica2CodeFirst.CQRS.Commands
{
    public class PostLogin
    {
        public class CommandLogin : IRequest<RespuestaLogin>
        {
            public string User { get; set; }
            public string Password { get; set; }
        }

        public class CommandLoginValidation : AbstractValidator<CommandLogin>
        {
            public CommandLoginValidation()
            {
                RuleFor(l => l.User).NotEmpty().WithMessage("Usuario Vacio");
                RuleFor(l => l.Password).NotEmpty().WithMessage("Contraseña Vacia");
            }
        }
        public class CommandLoginHandler : IRequestHandler<CommandLogin, RespuestaLogin>
        {
            private readonly ContextBD _context;
            private readonly CommandLoginValidation _validation;

            public CommandLoginHandler(ContextBD context, CommandLoginValidation validation)
            {
                _context = context;
                _validation = validation;
            }

            public async Task<RespuestaLogin> Handle(CommandLogin request, CancellationToken cancellationToken)
            {
                RespuestaLogin respuesta = new RespuestaLogin();
                try
                {
                    var validacion = await _validation.ValidateAsync(request);

                    if (validacion.IsValid)
                    {
                        var login = await _context.Empleados.FirstOrDefaultAsync(e => e.Nombre.Equals(request.User) && e.Dni.Equals(request.Password));

                        if(login != null)
                        {
                            respuesta.Login = true;
                        }
                        else
                        {
                            respuesta.Login = false;
                            respuesta.setMensajeError("Usuario o Password incorrectos",System.Net.HttpStatusCode.NotFound);
                        }
                    }
                    else
                    {
                        respuesta.setMensajeError("No se pudo validar el login.", System.Net.HttpStatusCode.NotFound);
                        return respuesta;
                    }
                    return respuesta;
                }
                catch
                {
                    respuesta.setMensajeError("Ha ocurrido un error en el login", System.Net.HttpStatusCode.NotFound);
                    return respuesta;
                }
            }
        }
    }
}
