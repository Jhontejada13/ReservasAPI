using ReservasAPI.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ReservasAPI.Data.DTOs
{
    public class SucursalCreacionDto
    {

        [Required]
        public Guid CodSucursal { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no puede contener más de 30 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no puede contener más de 20 caracteres")]
        public string telefono { get; set; }

    }
}
