using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Jobs;
using PoupaDev.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// PARA ACESSO AO BANCO EM MEMÓRIA
builder.Services.AddDbContext<PoupaDevDbContext>(o => o.UseInMemoryDatabase("PoupaDevDb"));

// PARA ACESSO AO SQL Server
// var connectionString = builder.Configuration.GetConnectionString("PoupaDevCs");
// builder.Services.AddDbContext<PoupaDevDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Job - Hosted Services
builder.Services.AddHostedService<RendimentoAutomaticoJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// INFO: Swagger visível só em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();