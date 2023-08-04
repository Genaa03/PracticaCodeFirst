namespace Practica2CodeFirst.Respuestas
{
    public class RespuestaSucursales : RespuestaBase
    {
        public List<SucursalDTO> ListaSucursales { get; set; }

    }
    public class SucursalDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}
