using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DesafioTecnicoAlunoTurma.Models
{
    public class Aluno
    {
        [NotNull]
        public int Id { get; set; }

        [NotNull]
        [StringLength(255)]
        public string Nome { get; set; }

        [NotNull]
        [StringLength(45)]
        public string Usuario { get; set; }

        [NotNull]
        [StringLength(60)]
        public string Senha { get; set; }

        [NotNull]
        [DefaultValue(true)]
        public bool Ativo { get; set; }
    }
}
