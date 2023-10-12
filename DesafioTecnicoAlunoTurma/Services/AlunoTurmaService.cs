using AutoMapper;
using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Interfaces.Repositories;
using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
using DesafioTecnicoAlunoTurma.Repositories;

namespace DesafioTecnicoAlunoTurma.Services
{
    public class AlunoTurmaService : IAlunoTurmaService
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public AlunoTurmaService(IAlunoTurmaRepository alunoTurmaRepository, IAlunoRepository alunoRepository, ITurmaRepository turmaRepository, IMapper mapper)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<AlunoTurmaDTO>> GetAll(PaginationParametersDTO paginationParametersDTO)
        {
            var paginationParametersEntity = _mapper.Map<PaginationParameters>(paginationParametersDTO);
            var alunosTurmas = await _alunoTurmaRepository.GetAll(paginationParametersEntity);
            foreach (var at in alunosTurmas)
            {
                at.Turma = await _turmaRepository.GetById(at.TurmaId);
                at.Aluno = await _alunoRepository.GetById(at.AlunoId);
            }
            return _mapper.Map<PagedList<AlunoTurmaDTO>>(alunosTurmas);
        }

        public async Task<MessageResponse> Create(AlunoTurma alunoTurma)
        {
            try
            {
                var existsAlunoInTurma = await _alunoTurmaRepository.ExistsAlunoInTurma(alunoTurma.AlunoId, alunoTurma.TurmaId);
                if (existsAlunoInTurma)
                {
                    throw new Exception("O aluno já existe na turma");
                }
                var existsAluno = await _alunoRepository.Exists(alunoTurma.AlunoId);
                var existsTurma = await _turmaRepository.Exists(alunoTurma.TurmaId);
                if (existsAluno && existsTurma)
                {
                    alunoTurma.Aluno.Id = alunoTurma.AlunoId;
                    alunoTurma.Turma.Id = alunoTurma.TurmaId;
                }
                alunoTurma.Ativo = true;
                await _alunoTurmaRepository.Create(alunoTurma);
                return new MessageResponse(true, "Relação aluno turma criada com sucesso!");
            }
            catch (Exception ex)
            {
                return new MessageResponse(false, ex.Message);
            }
        }

        public async Task<MessageResponse> Update(AlunoTurma alunoTurma)
        {
            try
            {
                var existsAlunoInTurma = await _alunoTurmaRepository.ExistsAlunoInTurma(alunoTurma.AlunoId, alunoTurma.TurmaId);
                if (existsAlunoInTurma)
                {
                    throw new Exception("O aluno já existe na turma");
                }
                await _alunoTurmaRepository.Update(alunoTurma);
                return new MessageResponse(true, "Relação aluno turma atualizada com sucesso!");
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
                await _alunoTurmaRepository.Delete(id);
                return new MessageResponse(true, "Relação aluno turma inativada com sucesso!");
            }
            catch (Exception ex)
            {
                return new MessageResponse(false, ex.Message);
            }
        }
    }
}
