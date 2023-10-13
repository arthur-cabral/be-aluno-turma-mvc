# DesafioTecnicoFIAP
Neste projeto, realizo o desafio técnico proposto pela FIAP para a vaga de desenvolvedor .NET

# Configuração

Antes de prosseguir, é necessário criar um arquivo com o nome `.appsettings.json` no diretório `./DesafioTecnicoAlunoTurma`.

Copie o trecho de código abaixo para o arquivo e substitua a variável `{sua_chave_de_conexao}` pela chave de conexão recebida:

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
