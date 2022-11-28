using AutoMapper;
using LocadoraAPI.Data.Dtos.Cinema;
using LocadoraAPI.Data.Gerente;
using LocadoraAPI.Models;
using System.Linq;

namespace LocadoraAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>();
            //    .ForMember(gerente => gerente.Cinemas, opts => opts
            //    .MapFrom(gerente => gerente.Cinemas.Select
            //    (c => new { c.Id, c.Name, c.Endereco, c.EnderecoId }))) ;
            CreateMap<UpdateGerenteDto, Gerente>();
        }
    }
}
