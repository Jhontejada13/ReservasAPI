using ReservasAPI.Data.Entities;

namespace ReservasAPI.Data.DTOs
{
    public class ReservaHotelActualizacionDto
    {
        public int IdTurista { get; set; }

        public int IdHotel { get; set; }

        public string Regimen { get; set; }

        public DateTime FechaLlegada { get; set; }

        public DateTime FechaSalida { get; set; }
    }
}
