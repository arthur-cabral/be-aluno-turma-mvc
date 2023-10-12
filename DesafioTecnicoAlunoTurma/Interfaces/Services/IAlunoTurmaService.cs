using DesafioTecnicoAlunoTurma.Models;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface IAlunoTurmaService
    {
        Task<IEnumerable<AlunoTurma>> GetAll();
        Task<MessageResponse> Create(AlunoTurma alunoTurma);
        Task<MessageResponse> Update(AlunoTurma alunoTurma);
        Task<MessageResponse> Delete(int id);
    }
}
