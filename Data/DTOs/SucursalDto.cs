using ReservasAPI.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ReservasAPI.Data.DTOs
{
    public class SucursalDto
    {
        public int Id { get; set; }

        public Guid CodSucursal { get; set; }

        public string Direccion { get; set; }

        public string telefono { get; set; }

        public List<ContratoSucursal> ContratosSucursal { get; set; }
    }
}
