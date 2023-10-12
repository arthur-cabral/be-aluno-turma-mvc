namespace DesafioTecnicoAlunoTurma.Models
{
    public class AlunoTurma
    {
        public int Id { get; set; }
        public Aluno Aluno { get; set; } = new Aluno();
        public int AlunoId { get; set; }
        public Turma Turma { get; set; } = new Turma();
        public int TurmaId { get; set; }
        public bool Ativo { get; set; }
    }
}
