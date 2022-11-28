using AutoMapper;
using LocadoraAPI.Data;
using LocadoraAPI.Data.Dtos.Endereco;
using LocadoraAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges(); 
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable RecuperarEndereco()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id==id);
            if (endereco == null)
            {
                return NotFound();
            }
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(enderecoDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id==id); 

            if (endereco == null)
            {
                return NotFound();
            }
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpPut("{id}")]
        public IActionResult AlterarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id== id);
            if (endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}
