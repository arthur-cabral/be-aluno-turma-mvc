using DesafioTecnicoAlunoTurma.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace DesafioTecnicoAlunoTurma.DTO
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Turma>? Turmas { get; set; } = Enumerable.Empty<Turma>();
    }
}
