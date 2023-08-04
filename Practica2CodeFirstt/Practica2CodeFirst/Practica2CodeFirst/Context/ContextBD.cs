using Microsoft.EntityFrameworkCore;
using Practica2CodeFirst.Models;

namespace Practica2CodeFirst.Context
{
    public class ContextBD:DbContext
    {
        public ContextBD(DbContextOptions options):base(options)
        {
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
