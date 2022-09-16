using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservasAPI.Data.DTOs;
using ReservasAPI.Data.Entities;
using ReservasAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ReservasAPI.Controllers
{
    [ApiController]
    [Route("api/contratos")]
    public class ContratoSucursalController : Controller
    {
        private readonly ILogger<TuristaController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContratoSucursalController(ILogger<TuristaController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContratoSucursal>>> ObtenerContratos()
        {
            //return await _context.ContratosSucursales.ToListAsync();
            var contratos = await _context.ContratosSucursales.Include(x => x.Turista)
                .Include(x => x.Sucursal)
                .ToListAsync();

            return contratos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContratoSucursalDto>> ObtenerContratosPorId(int id)
        {
            var contratoSucursal = await _context.ContratosSucursales.Include(x => x.Turista)
                .Include(x => x.Sucursal)
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (contratoSucursal.Id == null)
                return BadRequest("No existe el contrato");

            if (contratoSucursal.IdSucursal == null)
                return BadRequest("La sucursal no existe");

            if (contratoSucursal.IdTurista == null)
                return BadRequest("El turista no existe");

            return _mapper.Map<ContratoSucursalDto>(contratoSucursal);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContratoSucursalDto contratoSucursalDto)
        {
            var sucursal = await _context.Sucursales.FindAsync(contratoSucursalDto.IdSucursal);
            var turista = await _context.Turistas.FindAsync(contratoSucursalDto.IdTurista);

            var contratoSucursal = _mapper.Map<ContratoSucursal>(contratoSucursalDto);

            contratoSucursal.Sucursal = sucursal;
            contratoSucursal.Turista = turista;
            

            _context.Add(contratoSucursal);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ContratoSucursalActualizacionDto contratoSucursalActualizacionDto, int id)
        {
            var contratoSucursal = await _context.ContratosSucursales.FirstOrDefaultAsync(x => x.Id == id);

            if (contratoSucursal.Id == null)
                return BadRequest("No existe el contrato");

            contratoSucursal.IdSucursal = contratoSucursalActualizacionDto.IdSucursal;
            contratoSucursal.IdTurista = contratoSucursalActualizacionDto.IdTurista;

            _context.Update(contratoSucursal);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var contratoSucursal = await _context.ContratosSucursales.FirstOrDefaultAsync(x => x.Id == id);

            if (contratoSucursal == null)
                return NotFound();

            _context.Remove(contratoSucursal);
            await _context.SaveChangesAsync();
            return NoContent(); //204
        }
    }
}
