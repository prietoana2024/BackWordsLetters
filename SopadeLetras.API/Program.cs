using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SopadeLetras.DAL.DBContext;
using SopadeLetras.IOC;
using SopadeLetras.MODELS;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BdSopaLetrasContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.InyectarDependencias(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica",
    app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseAuthorization();

//app.MapControllers();
// Otros servicios...
//builder.Services.AddControllers();

// Habilitar CORS
//app.UseCors("NuevaPolitica");

// Otros middleware...
app.MapControllers();
app.Run();
