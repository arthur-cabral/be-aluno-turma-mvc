using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;

namespace DesafioTecnicoAlunoTurma.Interfaces.Services
{
    public interface IAlunoService
    {
        Task<PagedList<AlunoDTO>> GetAll(PaginationParametersDTO paginationParametersDTO);
        Task<Aluno> GetById(int id);
        Task<MessageResponse> Create(Aluno aluno);
        Task<MessageResponse> Update(Aluno aluno);
        Task<MessageResponse> Delete(int id);
    }
}
