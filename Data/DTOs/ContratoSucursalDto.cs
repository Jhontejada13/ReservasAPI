using ReservasAPI.Data.Entities;

namespace ReservasAPI.Data.DTOs
{
    public class ContratoSucursalDto
    {
        public int Id { get; set; }

        public int IdTurista { get; set; }

        public int IdSucursal { get; set; }

        public Turista Turista { get; set; }

        public Sucursal Sucursal { get; set; }
    }
}
