using Microsoft.EntityFrameworkCore;
using ReservasAPI.Data.Entities;

namespace ReservasAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Turista> Turistas { get; set; }

        public DbSet<Sucursal> Sucursales { get; set; }

        public DbSet<ContratoSucursal> ContratosSucursales { get; set; }

    }
}
