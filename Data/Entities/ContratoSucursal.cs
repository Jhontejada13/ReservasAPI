using System.ComponentModel.DataAnnotations.Schema;

namespace ReservasAPI.Data.Entities
{
    public class ContratoSucursal
    {
        public int Id { get; set; }

        public int IdTurista { get; set; }

        public int IdSucursal { get; set; }
        
        public Turista Turista { get; set; }

        public Sucursal Sucursal { get; set; }
    }
}
