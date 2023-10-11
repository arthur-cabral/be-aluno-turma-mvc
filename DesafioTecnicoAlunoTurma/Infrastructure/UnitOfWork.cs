using DesafioTecnicoAlunoTurma.Commons;

namespace DesafioTecnicoAlunoTurma.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _session;

        public UnitOfWork(DbContext session)
        {
            this._session = session;
        }

        public void BeginTransaction()
        {
            this._session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            this._session.Transaction.Commit();
            this.Dispose();
        }

        public void Rollback()
        {
            this._session.Transaction.Rollback();
            this.Dispose();
        }

        public void Dispose() => this._session.Transaction?.Dispose();
    }
}
