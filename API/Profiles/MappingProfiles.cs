
using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pais,PaisDto>()
                .ReverseMap()
                .ForMember( o => o.Departamentos, d=> d.Ignore());

            CreateMap<Departamento,DepartamentoDto>()
                .ReverseMap()
                .ForMember( o => o.Ciudades, d=> d.Ignore());
            CreateMap<Pais,PaisxDepDto>()
                .ReverseMap();

            CreateMap<Ciudad,CiudadDto>()
                .ReverseMap();
            CreateMap<Departamento,DepxCiudadesDto>()
                .ReverseMap();
            
        }
    }
}