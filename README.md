<h1 align="center">
  PoupaDev - Jornada .NET Direto ao Ponto
</h1>
<p align="center">
  <a href="#tecnologias-e-práticas-utilizadas">Tecnologias e práticas utilizadas</a> •
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#comandos">Comandos</a>
</p>

Foi desenvolvida uma API REST completa de gerenciamento de objetivos financeiros.

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 6
- Entity Framework Core
- SQL Server / SQLite / In-Memory database
- Swagger (documentação)
- Programação Orientada a Objetos
- Injeção de Dependência
- Padrão Repository
- Hosted Services (tarefas em segundo plano)
- Clean Code
- Publicação

## Funcionalidades
- Cadastro, Listagem, Detalhes de Objetivo Financeiro
- Saque e Depósito de Objetivo Financeiro
- Rendimento Automático

###

![alt text](https://raw.githubusercontent.com/samuel-oldra/PoupaDev.API/main/README_IMGS/swagger_ui.png)

## Comandos

### Comandos básicos
```
dotnet new gitignore
dotnet new webapi -o PoupaDev.API
dotnet new console -o PoupaDev.Console

dotnet build
dotnet run
dotnet watch run

dotnet publish
```

### Tool Entity Framework Core (migrations)
```
dotnet tool install --global dotnet-ef
dotnet tool uninstall --global dotnet-ef
```

### Migrations
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```