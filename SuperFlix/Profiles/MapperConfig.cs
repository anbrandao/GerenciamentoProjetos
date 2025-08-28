using AutoMapper;
using ControleProjetos.Data.Dtos.ColaboradorDto;
using ControleProjetos.Data.Dtos.ColaboradoresProjetosDto;
using ControleProjetos.Data.Dtos.DiretoriaDto;
using ControleProjetos.Data.Dtos.FilmeDto;
using ControleProjetos.Models;


namespace ControleProjetos.Profiles
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Projeto, ReadProjetoDto>().ReverseMap().
                ForMember(readProjetoDto => readProjetoDto.ColaboradoresProjetos,
                opt =>opt.MapFrom(Projeto => Projeto.ColaboradoresProjetos));

            CreateMap<Projeto, CreateProjetoDto>().ReverseMap();

            CreateMap<Colaborador, ReadColaboradorDto>().
                ForMember(readColaboradorDto => readColaboradorDto.Diretoria,
                opt => opt.MapFrom(colaborador => colaborador.Diretoria)).
                ForMember(readColaboradorDto => readColaboradorDto.ColaboradoresProjetos,
                opt => opt.MapFrom(colaborador => colaborador.ColaboradoresProjetos));

            CreateMap<Colaborador, CreateColaboradorDto>().ReverseMap();

            CreateMap<Diretoria, ReadDiretoriaDto>().
                ForMember(readDiretoriaDto => readDiretoriaDto.Colaboradores,
                opt => opt.MapFrom(diretoria => diretoria.Colaboradores));

            CreateMap<Diretoria, CreateDiretoriaDto>().ReverseMap();

            CreateMap<ColaboradoresProjetos, ReadColaboradoresProjetosDto>().ReverseMap();
            CreateMap<ColaboradoresProjetos, CreateColaboradoresProjetosDto>().ReverseMap();
        }
    }
}
