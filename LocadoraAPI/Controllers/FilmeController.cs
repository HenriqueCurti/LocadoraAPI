using LocadoraAPI.Data;
using LocadoraAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LocadoraAPI.Data.Dtos.Filme;
using LocadoraAPI.Services;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        FilmeService _filmeService;

        public FilmeController(FilmeService filmeservice)
        {
            _filmeService = filmeservice;
        }


        [HttpPost]
        public IActionResult CadadstrarFilme([FromBody] CreateFilmeDto filmeDto)
        {            
            ReadFilmeDto readDto = _filmeService.AdcionarFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = readDto.ID }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarFilme([FromQuery] int? classificao = null)
        {            
            List<ReadFilmeDto> readDto = _filmeService.RecuperarFilme(classificao);
            if (readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();

        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            ReadFilmeDto readDto = _filmeService.RecuperarFilmePorId(id);
            if (readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filmes => filmes.ID == id);    
            if (filme == null)
            {
               return NotFound("O FIlme Não Existe");
            }

            _mapper.Map(filmeDto, filme);
            
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme=> filme.ID == id);
            if (filme == null)
            {
                return NotFound("Filme Não Encontrado");  
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
