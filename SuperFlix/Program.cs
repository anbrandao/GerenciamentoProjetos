using Microsoft.EntityFrameworkCore;
using ControleProjetos.Data;
using ControleProjetos.Repositories.Contracts;
using ControleProjetos.Repositories.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("ProjetosDBConnection");
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseLazyLoadingProxies().UseSqlServer(conn);
});

//builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
builder.Services.AddScoped<IColaboradoresProjetosRepository, ColaboradoresProjetosRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<IDiretoriaRepository, DiretoriaRepository>();



builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>
    (options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


