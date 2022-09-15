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

        [HttpGet("id")]
        public async Task<ActionResult<List<Turista>>> ObtenerTuristaPorId(int id)
        {
            var turista = _context.Turistas.FirstOrDefault(x => x.Id == id);

            if (turista == null)
                return NotFound();

            return _mapper.Map<TuristaDto>(turista);

            return await _context.Turistas.ToListAsync();
        }

        //public ApplicationDbContext Context { get; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
