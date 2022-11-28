using AutoMapper;
using LocadoraAPI.Data.Dtos.Endereco;
using LocadoraAPI.Models;

namespace LocadoraAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
