using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DesafioTecnicoAlunoTurma.Models
{
    public class Turma
    {
        [NotNull]
        public int Id { get; set; }

        [NotNull]
        [StringLength(255)]
        public string NomeTurma { get; set; }

        [NotNull]
        public int Ano { get; set; }

        [NotNull]
        [DefaultValue(true)]
        public bool Ativo { get; set; }
    }
}
