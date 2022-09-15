namespace ReservasAPI.Data.Entities
{
    public class ReservaHotel
    {

        public int Id { get; set; }

        public int IdTurista { get; set; }

        public int IdSucursal { get; set; }

        public Turista Turista { get; set; }

        public Sucursal Sucursal { get; set; }

        public int MyProperty { get; set; }
    }
}
