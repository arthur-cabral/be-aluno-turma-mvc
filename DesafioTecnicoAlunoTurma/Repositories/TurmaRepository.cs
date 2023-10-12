using Dapper;
using DesafioTecnicoAlunoTurma.Infrastructure;
using DesafioTecnicoAlunoTurma.Interfaces.Repositories;
using DesafioTecnicoAlunoTurma.Models;
using System.Transactions;

namespace DesafioTecnicoAlunoTurma.Repositories
{
    public class TurmaRepository : RepositoryBase, ITurmaRepository
    {
        public TurmaRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Turma>> GetAll()
        {
            const string sql = @"select
                               id,
                               nome_turma as NomeTurma,
                               ano
                               from dbo.turma
                               where ativo = 1";

            return await Connection.QueryAsync<Turma>(sql, Transaction);
        }

        public async Task<Turma> GetById(int id)
        {
            const string sql = @"select
                               id,
                               nome_turma as NomeTurma,
                               ano
                               from dbo.turma
                               where id = @id";

            return await Connection.QueryFirstOrDefaultAsync<Turma>(sql, new { id }, Transaction);
        }

        public async Task<bool> Exists(int id)
        {
            const string sql = @"select count(*) from dbo.turma where id = @id";
            return await Connection.ExecuteScalarAsync<bool>(sql, new { id }, Transaction);
        }

        public async Task Create(Turma turma)
        {
            string sql = @"insert into dbo.turma
                                 (nome_turma,
                                 ano,
                                 ativo)
                                 values
                                 (@nomeTurma, @ano, @ativo)";

            await Connection.ExecuteAsync(sql, new { turma.NomeTurma, turma.Ano, turma.Ativo }, Transaction);
        }
        public async Task Update(Turma turma)
        {
            string sql = @"update dbo.turma
                                 set nome_turma = @nomeTurma,
                                 ano = @ano
                                 where id = @id";

            await Connection.ExecuteAsync(sql, new { turma.NomeTurma, turma.Ano, turma.Id }, Transaction);
        }

        public async Task Delete(int id)
        {
            string sql = @"update dbo.turma
                                 set ativo = 0
                                 where id = @id";

            await Connection.ExecuteAsync(sql, new { id }, Transaction);
        }
    }
}
