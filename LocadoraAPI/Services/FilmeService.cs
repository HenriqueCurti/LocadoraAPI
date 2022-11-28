using AutoMapper;
using LocadoraAPI.Data;
using LocadoraAPI.Data.Dtos.Filme;
using LocadoraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAPI.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdcionarFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            Console.WriteLine(filme.Titulo);
            return _mapper.Map<ReadFilmeDto>(filme);
            
        }

        public List<ReadFilmeDto> RecuperarFilme(int? classificao)
        {
            List<Filme> filmes;

            if (classificao == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificao).ToList(); ;
            }
            if (filmes != null)
            {
                List<ReadFilmeDto> filmeDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return filmeDto;
            }
            return null;
        }

        public ReadFilmeDto RecuperarFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filmes => filmes.ID == id);

            if (filme != null) {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return filmeDto;
            }
            return null;
        }
    }
}
