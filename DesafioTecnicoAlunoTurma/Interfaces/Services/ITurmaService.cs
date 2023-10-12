using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface ITurmaService
    {
        Task<PagedList<TurmaDTO>> GetAll(PaginationParametersDTO paginationParametersDTO);
        Task<Turma> GetById(int id);
        Task<MessageResponse> Create(TurmaDTO turmaDTO);
        Task<MessageResponse> Update(TurmaDTO turmaDTO);
        Task<MessageResponse> Delete(int id);
    }
}
