using Dapper;
using DesafioTecnicoAlunoTurma.Infrastructure;
using DesafioTecnicoAlunoTurma.Interfaces.Repositories;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
using System.Diagnostics.CodeAnalysis;

namespace DesafioTecnicoAlunoTurma.Repositories
{
    public class AlunoTurmaRepository : RepositoryBase, IAlunoTurmaRepository
    {
        public AlunoTurmaRepository(DbContext context) : base(context)
        {
        }

        public async Task<PagedList<AlunoTurma>> GetAll(PaginationParameters paginationParameters)
        {
            string sql = @"select 
                                att.id,
                                att.ativo,
                                t.id as TurmaId,
                                t.nome_turma as NomeTurma,
                                t.ano,
                                t.ativo,
                                a.id as AlunoId,
                                a.nome,
                                a.usuario,
                                a.senha,
                                a.ativo
                            from dbo.aluno_turma as att
                            inner join dbo.turma as t on att.turma_id = t.id
                            inner join dbo.aluno as a on att.aluno_id = a.id
                            where att.ativo = 1 and t.ativo = 1 and a.ativo = 1
                            order by t.id offset @offset rows fetch next @limit rows only";

            var result = await Connection.QueryAsync<AlunoTurma>(sql, new { offset = paginationParameters.PageNumber, limit = paginationParameters.PageSize }, Transaction);
            return PagedList<AlunoTurma>.ToPagedList(
                result.AsQueryable(),
                paginationParameters.PageNumber,
                paginationParameters.PageSize
            );
        }

        public async Task<bool> ExistsAlunoInTurma(int alunoId, int turmaId)
        {
            string sql = @"select 
                                count(*)
                            from dbo.aluno_turma as att
                            inner join dbo.turma as t on att.turma_id = t.id
                            inner join dbo.aluno as a on att.aluno_id = a.id
                            where a.id = @alunoId and t.id = @turmaId";

            return await Connection.ExecuteScalarAsync<bool>(sql, new { alunoId, turmaId }, Transaction);
        }

        public async Task Create(AlunoTurma alunoTurma)
        {
            string sql = @"insert into dbo.aluno_turma
                                (aluno_id,
                                turma_id,
                                ativo)
                            values 
                                (@alunoId,
                                @turmaId,
                                1)";

            var alunoId = alunoTurma.Aluno.Id;
            var turmaId = alunoTurma.Turma.Id;
            await Connection.ExecuteAsync(sql, new { alunoId, turmaId }, Transaction);
        }

        public async Task Update(AlunoTurma alunoTurma)
        {
            string sql = @"update dbo.aluno_turma
                                set aluno_id = @alunoId,
                                turma_id = @turmaId,
                                ativo = @ativo
                                where id = @id";

            var alunoId = alunoTurma.Aluno.Id;
            var turmaId = alunoTurma.Turma.Id;
            await Connection.ExecuteAsync(sql, new { alunoId, turmaId, alunoTurma.Ativo, alunoTurma.Id }, Transaction);
        }

        public async Task Delete(int id)
        {
            string sql = @"update dbo.aluno_turma
                                 set ativo = 0
                                 where id = @id";

            await Connection.ExecuteAsync(sql, new { id }, Transaction);
        }
    }
}
