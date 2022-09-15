using ReservasAPI.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ReservasAPI.Data.DTOs
{
    public class HotelDto
    {
        public int Id { get; set; }

        public Guid CodHotel { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Telefono { get; set; }

        [Required]
        public int NumeroPlazas { get; set; }
    }
}
