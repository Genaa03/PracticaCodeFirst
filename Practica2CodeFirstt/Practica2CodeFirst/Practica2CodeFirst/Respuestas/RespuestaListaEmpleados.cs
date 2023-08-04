using Practica2CodeFirst.Models;

namespace Practica2CodeFirst.Respuestas
{
    public class RespuestaListaEmpleados:RespuestaBase
    {
        public List<EmpleadoDTO> ListaEmpleados { get; set; }
    }
    public class EmpleadoDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public string Sucursal { get; set; }
        public string Ciudad { get; set; }
        public string Jefe { get; set; }
        public string DNI { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
