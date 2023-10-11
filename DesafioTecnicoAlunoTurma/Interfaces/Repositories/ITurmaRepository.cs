using DesafioTecnicoAlunoTurma.Models;

namespace DesafioTecnicoAlunoTurma.Interfaces.Repositories
{
    public interface ITurmaRepository
    {
        Task<IEnumerable<Turma>> GetAll();
        Task<Turma> GetById(int id);
        Task<bool> Exists(int id);
        Task Create(Turma aluno);
        Task Update(Turma aluno);
        Task Delete(int id);
    }
}
