using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using veterinary_universum_articles.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja kontrolerów
builder.Services.AddControllers();

// Swagger (dokumentacja API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Rejestracja bazy danych lokalnej (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Rejestracja MediatR — poprawnie dla wersji 11.1.0
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Rejestracja repozytorium artyku³ów
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
