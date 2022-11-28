using AutoMapper;
using LocadoraAPI.Data.Dtos.Filme;
using LocadoraAPI.Models;
using System.IO;
using System.Linq;

namespace LocadoraAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
