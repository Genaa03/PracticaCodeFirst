using System.Net;

namespace Practica2CodeFirst.Respuestas
{
    public class RespuestaBase
    {
        public bool Ok { get; set; } = true;
        public string Mensaje { get; set; } = "";
        public HttpStatusCode Codigo { get; set; }=HttpStatusCode.OK;

        public void setMensajeError(string mensaje,HttpStatusCode codigo)
        {
            Ok = false;
            Codigo = codigo;
            Mensaje = mensaje;
        }
    }
}
