using AutoMapper;
using LocadoraAPI.Data.Dtos.Cinema;
using LocadoraAPI.Models;

namespace LocadoraAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
