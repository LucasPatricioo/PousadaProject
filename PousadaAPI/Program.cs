using Data.DAO;
using PousadaAPI.Data.DAO;
using PousadaAPI.Interfaces;
using PousadaAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IUsuarioDAO, UsuarioDAO>(provider => new UsuarioDAO(connectionString));
builder.Services.AddScoped<IModuloDAO, ModuloDAO>(provider => new ModuloDAO(connectionString));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IModuloService, ModuloService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); // Especifica o uso de endpoints de controladores

app.Run();