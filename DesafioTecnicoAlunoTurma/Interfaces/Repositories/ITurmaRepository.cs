using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Repositories
{
    public interface ITurmaRepository
    {
        Task<PagedList<Turma>> GetAll(PaginationParameters paginationParameters);
        Task<Turma> GetById(int id);
        Task<bool> Exists(int id);
        Task<bool> ExistsByName(string name);
        Task Create(Turma aluno);
        Task Update(Turma aluno);
        Task Delete(int id);
    }
}
