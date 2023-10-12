using AutoMapper;
using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Interfaces.Repositories;
using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
using static BCrypt.Net.BCrypt;

namespace DesafioTecnicoAlunoTurma.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<AlunoDTO>> GetAll(PaginationParametersDTO paginationParametersDTO)
        {
            var paginationParametersEntity = _mapper.Map<PaginationParameters>(paginationParametersDTO);
            var alunoEntity = await _alunoRepository.GetAll(paginationParametersEntity);
            return _mapper.Map<PagedList<AlunoDTO>>(alunoEntity);
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
                SetAlunoPreData(aluno);
                await _alunoRepository.Create(aluno);
                return new MessageResponse(true, "Aluno criado com sucesso!");
            } 
            catch (Exception ex)
            {
                return new MessageResponse(false, ex.Message);
            }
        }

        private static void SetAlunoPreData(Aluno aluno)
        {
            const int WorkFactor = 12;
            var hashedPassword = HashPassword(aluno.Senha, WorkFactor);
            aluno.Senha = hashedPassword;
            aluno.Ativo = true;
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
