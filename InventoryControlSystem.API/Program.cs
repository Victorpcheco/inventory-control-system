using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Application.Services;
using InventoryControlSystem.Domain.Repositories.Interfaces;
using InventoryControlSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using InventoryControlSystem.Domain.Repositories;
using InventoryControlSystem.Application.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<TokenService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
