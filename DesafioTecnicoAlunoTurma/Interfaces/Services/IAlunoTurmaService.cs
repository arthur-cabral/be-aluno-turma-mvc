using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface IAlunoTurmaService
    {
        Task<PagedList<AlunoTurmaDTO>> GetAll(PaginationParametersDTO paginationParametersDTO);
        Task<MessageResponse> Create(AlunoTurmaDTO alunoTurmaDTO);
        Task<MessageResponse> Update(AlunoTurmaDTO alunoTurmaDTO);
        Task<MessageResponse> Delete(int id);
    }
}
