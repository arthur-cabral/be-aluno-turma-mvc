# ProjetoAlunoTurmaRazor

Neste projeto, desenvolvi páginas utilizando o Razor para uma aplicação de relacionamento Aluno-Turma.

# Configuração

Antes de prosseguir, é necessário criar um arquivo com o nome `appsettings.json` no diretório `./DesafioTecnicoAlunoTurma`. 

Copie o trecho de código abaixo para o arquivo. 

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "{sua_chave_de_conexao}"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Substitua a variável `{sua_chave_de_conexao}` pela chave de conexão recebida, ou se preferir, crie sua própria chave de conexão usando um banco de dados SQL Server e crie suas tabelas por meio do script `.sql` disponibilizado na raiz deste repositório.
