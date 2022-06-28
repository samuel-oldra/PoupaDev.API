# Projeto de API usando C# e .NET 6

## PoupaDev - Jornada .NET Direto ao Ponto

Foi desenvolvida uma API REST completa de gerenciamento de objetivos financeiros.

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 6
- Entity Framework Core
- SQL Server / In-Memory database
- Swagger
- Injeção de Dependência
- Programação Orientada a Objetos
- Padrão Repository
- Hosted Services
- Clean Code
- Publicação

## Funcionalidades
- Cadastro, Listagem, Detalhes de Objetivo Financeiro
- Saque e Depósito de Objetivo Financeiro
- Rendimento Automático

###

![alt text](https://raw.githubusercontent.com/samuel-oldra/PoupaDev.API/main/README_IMGS/swagger_ui.png)

## Comandos básicos
```
dotnet new gitignore
dotnet new webapi -o PoupaDev.API
dotnet new console -o PoupaDev.Console
dotnet build
dotnet run
dotnet watch run
dotnet publish
```

## Tool Entity Framework Core (migrations)
```
dotnet tool install --global dotnet-ef
dotnet tool uninstall --global dotnet-ef
```

## Migrations
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```