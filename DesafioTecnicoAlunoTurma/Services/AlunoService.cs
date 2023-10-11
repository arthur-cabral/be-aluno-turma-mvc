using DesafioTecnicoAlunoTurma.Interfaces.Repositories;
using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;

namespace DesafioTecnicoAlunoTurma.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            return await _alunoRepository.GetAll();
        }

        public async Task<Aluno> GetById(int id)
        {
            if (await _alunoRepository.Exists(id))
            {
                return await _alunoRepository.GetById(id);
            }
            throw new Exception("Aluno não encontrado.");
        }

        public async Task<MessageResponse> Create(Aluno aluno)
        {
            try
            {
                aluno.Ativo = true;
                await _alunoRepository.Create(aluno);
                return new MessageResponse(true, "Aluno criado com sucesso!");
            } 
            catch (Exception ex)
            {
                return new MessageResponse(false, ex.Message);
            }
        }

        public async Task<MessageResponse> Update(Aluno aluno)
        {
            try
            {
                await _alunoRepository.Update(aluno);
                return new MessageResponse(true, "Aluno atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return new MessageResponse(false, ex.Message);
            }
        }

        public async Task<MessageResponse> Delete(int id)
        {
            try
            {
                await _alunoRepository.Delete(id);
                return new MessageResponse(true, "Aluno inativado com sucesso!");
            }
            catch (Exception ex) 
            {
                return new MessageResponse(false, ex.Message);
            }
        }
    }
}
