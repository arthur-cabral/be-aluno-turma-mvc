using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Repositories
{
    public interface IAlunoTurmaRepository
    {
        Task<PagedList<AlunoTurma>> GetAll(PaginationParameters paginationParameters);
        Task<bool> ExistsAlunoInTurma(int alunoId, int turmaId);
        Task<bool> Exists(int alunoTurmaId);
        Task Create(AlunoTurma alunoTurma);
        Task Update(AlunoTurma alunoTurma);
        Task Delete(int id);
    }
}
