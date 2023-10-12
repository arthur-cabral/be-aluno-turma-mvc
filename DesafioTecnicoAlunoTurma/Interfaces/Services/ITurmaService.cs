using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface ITurmaService
    {
        Task<PagedList<TurmaDTO>> GetAll(PaginationParametersDTO paginationParametersDTO);
        Task<Turma> GetById(int id);
        Task<MessageResponse> Create(Turma turma);
        Task<MessageResponse> Update(Turma turma);
        Task<MessageResponse> Delete(int id);
    }
}
