using ReservasAPI.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ReservasAPI.Data.DTOs
{
    public class ReservaHotelCreacionDto
    {
        [Required]
        public int IdTurista { get; set; }

        [Required]
        public int IdHotel { get; set; }

        //public Turista Turista { get; set; }

        //public Hotel Hotel { get; set; }

        [Required]
        public string Regimen { get; set; }

        [Required]
        public DateTime FechaLlegada { get; set; }

        [Required]
        public DateTime FechaSalida { get; set; }
    }
}
