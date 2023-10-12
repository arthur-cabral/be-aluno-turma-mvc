using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface IAlunoTurmaService
    {
        Task<PagedList<AlunoTurmaDTO>> GetAll(PaginationParametersDTO paginationParametersDTO);
        Task<MessageResponse> Create(AlunoTurma alunoTurma);
        Task<MessageResponse> Update(AlunoTurma alunoTurma);
        Task<MessageResponse> Delete(int id);
    }
}
