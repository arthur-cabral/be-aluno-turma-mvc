using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        Task<PagedList<Aluno>> GetAll(PaginationParameters paginationParameters);
        Task<Aluno> GetById(int id);
        Task<bool> Exists(int id);
        Task Create(Aluno aluno);
        Task Update(Aluno aluno);
        Task Delete(int id);
    }
}
