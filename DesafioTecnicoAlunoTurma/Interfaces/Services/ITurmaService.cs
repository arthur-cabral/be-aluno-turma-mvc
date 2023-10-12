using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface ITurmaService
    {
        Task<PagedList<Turma>> GetAll(PaginationParameters paginationParameters);
        Task<Turma> GetById(int id);
        Task<MessageResponse> Create(Turma turma);
        Task<MessageResponse> Update(Turma turma);
        Task<MessageResponse> Delete(int id);
    }
}
