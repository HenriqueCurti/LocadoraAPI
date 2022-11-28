using AutoMapper;
using LocadoraAPI.Data.Dtos.SessaoDto;
using LocadoraAPI.Models;

namespace LocadoraAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
        }
    }
}
