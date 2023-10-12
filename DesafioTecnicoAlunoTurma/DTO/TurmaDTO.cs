using DesafioTecnicoAlunoTurma.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace DesafioTecnicoAlunoTurma.DTO
{
    public class TurmaDTO
    {
        public int Id { get; set; }
        public string NomeTurma { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Aluno>? Alunos { get; set; } = Enumerable.Empty<Aluno>();
    }
}
