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

        public async Task<MessageResponse> Create(AlunoTurmaDTO alunoTurmaDTO)
        {
            try
            {
                var existsAlunoInTurma = await _alunoTurmaRepository.ExistsAlunoInTurma(alunoTurmaDTO.AlunoId, alunoTurmaDTO.TurmaId);
                if (existsAlunoInTurma)
                {
                    throw new Exception("O aluno já existe na turma");
                }
                var existsAluno = await _alunoRepository.Exists(alunoTurmaDTO.AlunoId);
                var existsTurma = await _turmaRepository.Exists(alunoTurmaDTO.TurmaId);
                if (existsAluno && existsTurma)
                {
                    alunoTurmaDTO.Aluno.Id = alunoTurmaDTO.AlunoId;
                    alunoTurmaDTO.Turma.Id = alunoTurmaDTO.TurmaId;
                } else
                {
                    throw new Exception("O aluno e/ou a turma não existem");
                }
                alunoTurmaDTO.Ativo = true;
                var alunoTurmaEntity = _mapper.Map<AlunoTurma>(alunoTurmaDTO);
                await _alunoTurmaRepository.Create(alunoTurmaEntity);
                return new MessageResponse(true, "Relação aluno turma criada com sucesso!");
            }
            catch (Exception ex)
            {
                return new MessageResponse(false, ex.Message);
            }
        }

        public async Task<MessageResponse> Update(AlunoTurmaDTO alunoTurmaDTO)
        {
            try
            {
                var existsAlunoInTurma = await _alunoTurmaRepository.ExistsAlunoInTurma(alunoTurmaDTO.AlunoId, alunoTurmaDTO.TurmaId);
                if (existsAlunoInTurma)
                {
                    throw new Exception("O aluno já existe na turma");
                }
                var existsAluno = await _alunoRepository.Exists(alunoTurmaDTO.AlunoId);
                var existsTurma = await _turmaRepository.Exists(alunoTurmaDTO.TurmaId);
                if (existsAluno && existsTurma)
                {
                    alunoTurmaDTO.Aluno.Id = alunoTurmaDTO.AlunoId;
                    alunoTurmaDTO.Turma.Id = alunoTurmaDTO.TurmaId;
                }
                else
                {
                    throw new Exception("O aluno e/ou a turma não existem");
                }
                var alunoTurmaEntity = _mapper.Map<AlunoTurma>(alunoTurmaDTO);
                await _alunoTurmaRepository.Update(alunoTurmaEntity);
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
                var exists = await _alunoTurmaRepository.Exists(id);
                if (!exists)
                {
                    throw new Exception("A relação aluno turma não existe");
                }
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
