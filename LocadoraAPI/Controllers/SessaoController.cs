using AutoMapper;
using LocadoraAPI.Data;
using LocadoraAPI.Data.Dtos.SessaoDto;
using LocadoraAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Add(sessao);
            _context.SaveChanges();            
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new {id = sessao.Id}, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return Ok(sessaoDto);
            
        }
    }
}
