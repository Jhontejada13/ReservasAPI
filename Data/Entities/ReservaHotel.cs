using System.ComponentModel.DataAnnotations;

namespace ReservasAPI.Data.Entities
{
    public class ReservaHotel
    {
        public int Id { get; set; }

        public int IdTurista { get; set; }

        public int IdSucursal { get; set; }

        public Turista Turista { get; set; }

        public Hotel Hotel { get; set; }

        [Required]
        public string Regimen { get; set; }

        [Required]
        public DateTime FechaLlegada { get; set; }

        [Required]
        public DateTime FechaSalida { get; set; }
    }
}
