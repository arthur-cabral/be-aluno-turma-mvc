using DesafioTecnicoAlunoTurma.Commons;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace DesafioTecnicoAlunoTurma.Infrastructure
{
    public abstract class RepositoryBase : IRepository
    {
        private readonly DbContext _context;

        public IDbConnection Connection => this._context.Connection;

        public IDbTransaction Transaction
        {
            get => this._context.Transaction;
            set => this._context.Transaction = value;
        }

        protected RepositoryBase([NotNull] DbContext context)
        {
            this._context = context;
        }
    }
}
