using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface IAlunoService
    {
        Task<PagedList<AlunoDTO>> GetAll(PaginationParametersDTO paginationParametersDTO);
        Task<Aluno> GetById(int id);
        Task<MessageResponse> Create(AlunoDTO alunoDTO);
        Task<MessageResponse> Update(AlunoDTO alunoDTO);
        Task<MessageResponse> Delete(int id);
    }
}
