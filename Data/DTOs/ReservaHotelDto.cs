using ReservasAPI.Data.Entities;

namespace ReservasAPI.Data.DTOs
{
    public class ReservaHotelDto
    {
        public int Id { get; set; }

        public int IdTurista { get; set; }

        public int IdSucursal { get; set; }

        public Turista Turista { get; set; }

        public Hotel Hotel { get; set; }

        public string Regimen { get; set; }

        public DateTime FechaLlegada { get; set; }

        public DateTime FechaSalida { get; set; }
    }
}
