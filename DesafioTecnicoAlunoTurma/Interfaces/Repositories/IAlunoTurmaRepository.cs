using DesafioTecnicoAlunoTurma.Models;

namespace DesafioTecnicoAlunoTurma.Interfaces.Repositories
{
    public interface IAlunoTurmaRepository
    {
        Task<IEnumerable<AlunoTurma>> GetAllAlunosTurmas();
        Task<bool> ExistsAlunoInTurma(int alunoId, int turmaId);
        Task Create(AlunoTurma alunoTurma);
        Task Update(AlunoTurma alunoTurma);
        Task Delete(int id);
    }
}
