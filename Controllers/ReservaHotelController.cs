using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasAPI.Data.DTOs;
using ReservasAPI.Data.Entities;
using ReservasAPI.Data;

namespace ReservasAPI.Controllers
{
    [ApiController]
    [Route("api/reservas")]
    public class ReservaHotelController : Controller
    {
        private readonly ILogger<TuristaController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReservaHotelController(ILogger<TuristaController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservaHotel>>> ObtenerReservasHotel()
        {
            var reservas = await _context.ReservaHoteles.Include(x => x.Turista)
                .Include(x => x.Hotel)
                .ToListAsync();

            return reservas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaHotelDto>> ObtenerReservaHotelPorId(int id)
        {
            var reservaHotel = await _context.ReservaHoteles.Include(x => x.Turista)
                .Include(x => x.Hotel)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (reservaHotel == null)
                return NotFound();

            return _mapper.Map<ReservaHotelDto>(reservaHotel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReservaHotelCreacionDto reservaHotelCreacionDTO)
        {
            var hotel = await _context.Hoteles.FindAsync(reservaHotelCreacionDTO.IdHotel);
            var turista = await _context.Turistas.FindAsync(reservaHotelCreacionDTO.IdTurista);

            var reservaHotel = _mapper.Map<ReservaHotel>(reservaHotelCreacionDTO);

            reservaHotel.Hotel = hotel;
            reservaHotel.Turista = turista;
                
            _context.Add(reservaHotel);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ReservaHotelActualizacionDto reservaHotelActualizacionDTO, int id)
        {
            var reservaHotel = await _context.ReservaHoteles.FirstOrDefaultAsync(x => x.Id == id);

            if (reservaHotel.Id == null)
                return BadRequest("El turista no existe");

            reservaHotel.IdHotel = reservaHotelActualizacionDTO.IdHotel;
            reservaHotel.IdTurista = reservaHotelActualizacionDTO.IdTurista;
            reservaHotel.Regimen = reservaHotelActualizacionDTO.Regimen;

            _context.Update(reservaHotel);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var reservaHotel = await _context.ReservaHoteles.FirstOrDefaultAsync(x => x.Id == id);

            if (reservaHotel == null)
                return NotFound();

            _context.Remove(reservaHotel);
            await _context.SaveChangesAsync();
            return NoContent(); //204
        }
    }
}
