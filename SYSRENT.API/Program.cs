using SYSRENT.Application;
using SYSRENT.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//AGREGAR REGLAS DE CORS
var MisReglasCors = "ReglasCors";

builder.Services.AddCors(option =>
    option.AddPolicy(name: MisReglasCors,
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    }));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

object value = builder.Services.AddServicesApplication();
builder.Services.AddServicesInfrasttructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(x => x.SwaggerEndpoint("/openapi/v1.json", "SYSRENT"));
}

//HABILITAR EL USO DE LOS CORS
app.UseCors(MisReglasCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
