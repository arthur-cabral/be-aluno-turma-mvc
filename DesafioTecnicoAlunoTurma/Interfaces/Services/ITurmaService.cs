using DesafioTecnicoAlunoTurma.Models;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface ITurmaService
    {
        Task<IEnumerable<Turma>> GetAll();
        Task<Turma> GetById(int id);
        Task<MessageResponse> Create(Turma turma);
        Task<MessageResponse> Update(Turma turma);
        Task<MessageResponse> Delete(int id);
    }
}
