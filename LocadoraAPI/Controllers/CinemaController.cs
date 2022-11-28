using AutoMapper;
using Castle.Core.Internal;
using LocadoraAPI.Data;
using LocadoraAPI.Data.Dtos.Cinema;
using LocadoraAPI.Data.Dtos.Filme;
using LocadoraAPI.Models;
using LocadoraAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private List<ReadCinemaDto> _listaCinemas;
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;  
        }

        [HttpPost]
        public IActionResult CadastrarCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.CadastrarFilme(cinemaDto);            
            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarCinema([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.RecuperarCinema(nomeDoFilme);
            if (readDto == null)
            {
                return NotFound();
            }           
            return Ok(readDto);
        }
         
        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
            {
                return NotFound();
            }

            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
