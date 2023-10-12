using AutoMapper;
using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Interfaces.Repositories;
using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
using DesafioTecnicoAlunoTurma.Repositories;

namespace DesafioTecnicoAlunoTurma.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public TurmaService(ITurmaRepository turmaRepository, IMapper mapper)
        {
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<TurmaDTO>> GetAll(PaginationParametersDTO paginationParametersDTO)
        {
            var paginationParametersEntity = _mapper.Map<PaginationParameters>(paginationParametersDTO);
            var turmaEntity = await _turmaRepository.GetAll(paginationParametersEntity);
            return _mapper.Map<PagedList<TurmaDTO>>(turmaEntity);
        }

        public async Task<Turma> GetById(int id)
        {
            if (await _turmaRepository.Exists(id))
            {
                return await _turmaRepository.GetById(id);
            }
            throw new Exception("Turma não encontrada.");
        }

        public async Task<MessageResponse> Create(Turma turma)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                if (turma.Ano <= dateTime.Year)
                {
                    throw new Exception("Não é possível criar uma turma com a data anterior a atual");
                }
                turma.Ativo = true;
                await _turmaRepository.Create(turma);
                return new MessageResponse(true, "Turma criado com sucesso!");
            }
            catch (Exception ex)
            {
                return new MessageResponse(false, ex.Message);
            }
        }

        public async Task<MessageResponse> Update(Turma turma)
        {
            try
            {
                await _turmaRepository.Update(turma);
                return new MessageResponse(true, "Turma atualizada com sucesso!");
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
                await _turmaRepository.Delete(id);
                return new MessageResponse(true, "Turma inativada com sucesso!");
            }
            catch (Exception ex)
            {
                return new MessageResponse(false, ex.Message);
            }
        }
    }
}
