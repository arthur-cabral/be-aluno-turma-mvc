using AutoMapper;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.DTO.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<PaginationParameters, PaginationParametersDTO>().ReverseMap();
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
            CreateMap<Turma, TurmaDTO>().ReverseMap();
            CreateMap<AlunoTurma, AlunoTurmaDTO>().ReverseMap();
        }
    }
}
