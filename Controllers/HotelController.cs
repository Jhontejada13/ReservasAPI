using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservasAPI.Data.DTOs;
using ReservasAPI.Data.Entities;
using ReservasAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ReservasAPI.Controllers
{
    [ApiController]
    [Route("api/hoteles")]
    public class HotelController : Controller
    {
        private readonly ILogger<TuristaController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelController(ILogger<TuristaController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> ObtenerHoteles()
        {
            var hoteles = await _context.Hoteles
                .ToListAsync();

            return hoteles;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> ObtenerHotelPorId(int id)
        {
            var hotel = await _context.Hoteles
                .FirstOrDefaultAsync(x => x.Id == id);

            if (hotel == null)
                return NotFound();

            return _mapper.Map<HotelDto>(hotel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] HotelCreacionDto hotelCreacionDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelCreacionDto);
            _context.Add(hotel);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(HotelActualizacionDto hotelActualizacionDto, int id)
        {
            var hotel = await _context.Hoteles.FirstOrDefaultAsync(x => x.Id == id);

            if (hotel.Id == null)
                return BadRequest("El turista no existe");

            hotel.Nombre = hotelActualizacionDto.Nombre;
            hotel.Ciudad = hotelActualizacionDto.Ciudad;
            hotel.Telefono = hotelActualizacionDto.Telefono;
            hotel.Direccion = hotelActualizacionDto.Direccion;
            hotel.NumeroPlazas = hotelActualizacionDto.NumeroPlazas;

            _context.Update(hotel);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var hotel = await _context.Hoteles.FirstOrDefaultAsync(x => x.Id == id);

            if (hotel == null)
                return NotFound();

            _context.Remove(hotel);
            await _context.SaveChangesAsync();
            return NoContent(); //204
        }
    }
}
