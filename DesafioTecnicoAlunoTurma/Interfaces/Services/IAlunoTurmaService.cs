using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface IAlunoTurmaService
    {
        Task<PagedList<AlunoTurma>> GetAll(PaginationParameters paginationParameters);
        Task<MessageResponse> Create(AlunoTurma alunoTurma);
        Task<MessageResponse> Update(AlunoTurma alunoTurma);
        Task<MessageResponse> Delete(int id);
    }
}
