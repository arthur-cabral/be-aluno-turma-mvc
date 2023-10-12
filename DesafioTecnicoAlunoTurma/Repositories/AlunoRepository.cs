using Dapper;
using DesafioTecnicoAlunoTurma.Infrastructure;
using DesafioTecnicoAlunoTurma.Interfaces.Repositories;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
using System.Reflection;

namespace DesafioTecnicoAlunoTurma.Repositories
{
    public class AlunoRepository : RepositoryBase, IAlunoRepository
    {
        public AlunoRepository(DbContext context) : base(context)
        {
        }
        public async Task<PagedList<Aluno>> GetAll(PaginationParameters paginationParameters)
        {
            const string sql = @"select
                               id,
                               nome,
                               usuario,
                               senha
                               from dbo.aluno
                               where ativo = 1 order by id offset @offset rows fetch next @limit rows only";

            var result = await Connection.QueryAsync<Aluno>(sql, new { offset = paginationParameters.PageNumber, limit = paginationParameters.PageSize }, Transaction);
            return PagedList<Aluno>.ToPagedList(
                result.AsQueryable(), 
                paginationParameters.PageNumber,
                paginationParameters.PageSize
            );
        }

        public async Task<Aluno> GetById(int id)
        {
            const string sql = @"select
                               id,
                               nome,
                               usuario,
                               senha
                               from dbo.aluno
                               where id = @id";

            return await Connection.QueryFirstOrDefaultAsync<Aluno>(sql, new { id }, Transaction);
        }

        public async Task<bool> Exists(int id)
        {
            const string sql = @"select count(*) from dbo.aluno where id = @id";
            return await Connection.ExecuteScalarAsync<bool>(sql, new { id }, Transaction);
        }

        public async Task Create(Aluno aluno)
        {
            string sql = @"insert into dbo.aluno
                                 (nome,
                                 usuario,
                                 senha,
                                 ativo)
                                 values
                                 (@nome, @usuario, @senha, @ativo)";

            await Connection.ExecuteAsync(sql, new { aluno.Nome, aluno.Usuario, aluno.Senha, aluno.Ativo }, Transaction);
        }
        public async Task Update(Aluno aluno)
        {
            string sql = @"update dbo.aluno
                                 set nome = @nome,
                                 usuario = @usuario,
                                 senha = @senha,
                                 ativo = @ativo
                                 where id = @id";

            await Connection.ExecuteAsync(sql, new { aluno.Nome, aluno.Usuario, aluno.Senha, aluno.Ativo, aluno.Id }, Transaction);
        }

        public async Task Delete(int id)
        {
            string sql = @"update dbo.aluno
                                 set ativo = 0
                                 where id = @id";

            await Connection.ExecuteAsync(sql, new { id }, Transaction);
        }


    }
}
