using AutoMapper;
using LocadoraAPI.Data;
using LocadoraAPI.Data.Dtos.Cinema;
using LocadoraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAPI.Services
{
    public class CinemaService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
        }

        public ReadCinemaDto CadastrarFilme(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            if (cinema != null)
            {
                _mapper.Map<ReadCinemaDto>(cinema);
            }
            return null;
        }

        public List<ReadCinemaDto> RecuperarCinema(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(
                                             sessao => sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;
                cinemas = query.ToList();
            }
            List<ReadCinemaDto> cinemaDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);
            return cinemaDto;
        }
    }
}
