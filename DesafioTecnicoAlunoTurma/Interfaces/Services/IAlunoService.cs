using DesafioTecnicoAlunoTurma.Models;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> GetById(int id);
        Task<MessageResponse> Create(Aluno aluno);
        Task<MessageResponse> Update(Aluno aluno);
        Task<MessageResponse> Delete(int id);
    }
}
