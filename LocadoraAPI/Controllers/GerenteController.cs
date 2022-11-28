using AutoMapper;
using LocadoraAPI.Data;
using LocadoraAPI.Data.Gerente;
using LocadoraAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GerenteController(IMapper mapper, FilmeContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { id = gerente.Id }, gerente );
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            Gerente gerente  = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);  
            if (gerente != null)
            {
                return NotFound();
            }
            ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
            return Ok(gerenteDto);
        }
    }
}
