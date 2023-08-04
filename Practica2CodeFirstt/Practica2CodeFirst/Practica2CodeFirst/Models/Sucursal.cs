using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2CodeFirst.Models
{
    public class Sucursal
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("Ciudad")]
        public Guid IdCiudad { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
