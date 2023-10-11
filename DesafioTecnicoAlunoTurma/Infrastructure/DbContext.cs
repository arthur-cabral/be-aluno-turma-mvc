using System.Data;
using System.Data.SqlClient;

namespace DesafioTecnicoAlunoTurma.Infrastructure
{
    public sealed class DbContext : IDisposable
    {

        private readonly Guid _id;

        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; set; }

        public DbContext(string connectionString)
        {

            this._id = Guid.NewGuid();
            this.Connection = new SqlConnection(connectionString);
            this.Connection.Open();
        }

        public void Dispose() => this.Connection?.Dispose();
    }
}
