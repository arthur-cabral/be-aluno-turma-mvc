using System.Data;

namespace DesafioTecnicoAlunoTurma.Commons
{
    public interface IRepository
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }
    }
}
