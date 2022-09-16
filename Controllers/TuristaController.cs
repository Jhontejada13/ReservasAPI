using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasAPI.Data;
using ReservasAPI.Data.DTOs;
using ReservasAPI.Data.Entities;

namespace ReservasAPI.Controllers
{
    [ApiController]
    [Route("api/turistas")]
    public class TuristaController : Controller
    {
        private readonly ILogger<TuristaController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TuristaController(ILogger<TuristaController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Turista>>> ObtenerTuristas()
        {
            return await _context.Turistas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TuristaDto>> ObtenerTuristaPorId(int id)
        {
            var turista = await _context.Turistas.FirstOrDefaultAsync(x => x.Id == id);

            if(turista == null)
                return NotFound();

            return _mapper.Map<TuristaDto>(turista);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TuristaCreacionDto turistaCreacionDTO)
        {
            var turista = _mapper.Map<Turista>(turistaCreacionDTO);
            _context.Add(turista);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(TuristaActualizacionDto turistaActualizacionDto, int id)
        {
            var turista = await _context.Turistas.FirstOrDefaultAsync(x => x.Id == id);

            if (turista.Id == null)
                return BadRequest("El turista no existe");

            var existe = await _context.Turistas.AnyAsync(x => x.Id == id);

            if (!existe)
                return NotFound();

            turista.Nombres = turistaActualizacionDto.Nombres;
            turista.Apellidos = turistaActualizacionDto.Apellidos;
            turista.Direccion = turistaActualizacionDto.Direccion;
            turista.Telefono = turistaActualizacionDto.Telefono;

            _context.Update(turista);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var turista = await _context.Turistas.FirstOrDefaultAsync(x => x.Id == id);

            if (turista == null)
                return NotFound();

            _context.Remove(turista);
            await _context.SaveChangesAsync();
            return NoContent(); //204
        }
    }
}
