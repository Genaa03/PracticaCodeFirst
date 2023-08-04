using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2CodeFirst.Models
{
    public class Empleado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [ForeignKey("Cargo")]
        public Guid IdCargo { get; set; }
        public Cargo Cargo { get; set; }

        [ForeignKey("Sucursal")]
        public Guid IdSucursal { get; set; }
        public Sucursal Sucursal { get; set; }
        public string Dni { get; set; }
        public DateTime FechaAlta { get; set; }
        [ForeignKey("Jefe")]
        public Guid IdJefe { get; set; }
        public Empleado Jefe { get; set; }
    }
}
