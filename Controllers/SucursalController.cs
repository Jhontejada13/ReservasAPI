using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasAPI.Data;
using ReservasAPI.Data.DTOs;
using ReservasAPI.Data.Entities;

namespace ReservasAPI.Controllers
{
    [ApiController]
    [Route("api/sucursales")]
    public class SucursalController : Controller
    {
        private readonly ILogger<TuristaController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SucursalController(ILogger<TuristaController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sucursal>>> ObtenerSucursales()
        {
            return await _context.Sucursales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalDto>> ObtenerSucursalPorId(int id)
        {
            var sucursal = await _context.Sucursales.FirstOrDefaultAsync(x => x.Id == id);

            if (sucursal == null)
                return NotFound();

            return _mapper.Map<SucursalDto>(sucursal);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SucursalCreacionDto sucursalCreacionDTO)
        {
            var sucursal = _mapper.Map<Sucursal>(sucursalCreacionDTO);
            _context.Add(sucursal);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(SucursalActualizacionDto sucursalActualizacionDto, int id)
        {
            var sucursal = await _context.Sucursales.FirstOrDefaultAsync(x => x.Id == id);

            if (sucursal.Id == null)
                return BadRequest("La sucursal no existe");

            sucursal.Direccion = sucursalActualizacionDto.Direccion;
            sucursal.telefono = sucursalActualizacionDto.telefono;

            _context.Update(sucursal);
            await _context.SaveChangesAsync();
            return Ok(); //200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var sucursal = await _context.Sucursales.FirstOrDefaultAsync(x => x.Id == id);

            if (sucursal == null)
                return NotFound();

            _context.Remove(sucursal);
            await _context.SaveChangesAsync();
            return NoContent(); //204
        }
    }
}
