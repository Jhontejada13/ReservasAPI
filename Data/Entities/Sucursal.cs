using System.ComponentModel.DataAnnotations;

namespace ReservasAPI.Data.Entities
{
    public class Sucursal
    {

        public int Id { get; set; }

        [Required]
        public Guid CodSucursal { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no puede contener más de 30 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no puede contener más de 20 caracteres")]
        public string telefono { get; set; }

        //public List<ContratoSucursal> ContratosSucursal { get; set; }

    }
}
