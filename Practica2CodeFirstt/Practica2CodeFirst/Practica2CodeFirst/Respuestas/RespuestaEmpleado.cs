namespace Practica2CodeFirst.Respuestas
{
    public class RespuestaEmpleado:RespuestaBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Guid IdCargo { get; set; }
        public Guid IdSucursal { get; set; }
        public string Dni { get; set; }
        public DateTime FechaAlta { get; set; }
        public Guid IdJefe { get; set; }
    }
}
