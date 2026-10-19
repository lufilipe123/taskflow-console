# taskflow-console

Aplicação de console para gerenciar tarefas em memória.

## Pré-requisitos

- .NET SDK 10.0

## Compilar

Na raiz do repositório, execute:

```sh
dotnet build TaskFlow.Console/TaskFlow.Console.csproj
```

## Executar

```sh
dotnet run --project TaskFlow.Console/TaskFlow.Console.csproj
```

Use o menu para adicionar, listar e concluir tarefas. As tarefas ficam em
memória e são descartadas ao encerrar a aplicação.

## Executar os testes

```sh
dotnet test TaskFlow.Tests/TaskFlow.Tests.csproj
```
