using System.ComponentModel.DataAnnotations;

namespace ReservasAPI.Data.DTOs
{
    public class HotelActualizacionDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no puede contener más de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no puede contener más de 50 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no puede contener más de 30 caracteres")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no puede contener más de 20 caracteres")]
        public string Telefono { get; set; }

        [Required]
        public int NumeroPlazas { get; set; }
    }
}
