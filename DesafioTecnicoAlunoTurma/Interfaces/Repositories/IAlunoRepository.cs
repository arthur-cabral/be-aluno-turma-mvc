using DesafioTecnicoAlunoTurma.Models;

namespace DesafioTecnicoAlunoTurma.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> GetById(int id);
        Task<bool> Exists(int id);
        Task Create(Aluno aluno);
        Task Update(Aluno aluno);
        Task Delete(int id);
    }
}
