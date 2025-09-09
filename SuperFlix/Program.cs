using ControleProjetos.Data.Dtos.UsuarioDto;
using ControleProjetos.Infraestrutura;
using ControleProjetos.Repositories.Contracts;
using ControleProjetos.Repositories.Repository;
using ControleProjetos.SeuProjeto.Configurations;
using ControleProjetos.Usuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//aula Entity Pos //GetConnectionString Usando Pós
var configuracao = new ConfigurationBuilder().
    AddJsonFile("appsettings.json").
    Build();

#region[DB]
//GetConnectionString Usando aula Alura
var conn = builder.Configuration.GetConnectionString("ProjetosDBConnection");
//Configuração do Contexto
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    //GetConnectionString Usando Pós
    opts.UseLazyLoadingProxies().UseSqlServer(configuracao.GetConnectionString("ProjetosDBConnection"));
}, ServiceLifetime.Scoped);

builder.Services.AddDbContext<UsuarioDbContext>(opts =>
{
    //GetConnectionString Usando Pós
    opts.UseLazyLoadingProxies().UseSqlServer(conn);
}, ServiceLifetime.Scoped);

#endregion

builder.Services.
    AddIdentity<Usuario, IdentityRole>().
    AddRoles< IdentityRole >().
    AddEntityFrameworkStores<UsuarioDbContext>().
    AddDefaultTokenProviders();


//builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerDocumentation();

#region[DI]
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
builder.Services.AddScoped<IColaboradoresProjetosRepository, ColaboradoresProjetosRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<IDiretoriaRepository, DiretoriaRepository>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();
#endregion

#region [JWT]


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["chaveSecreta"])),
        ValidateAudience = false,
        ValidateIssuer = false,
        //ValidateIssuer = builder.Configuration["Jwt:Issuer"],
        ClockSkew = TimeSpan.Zero,
        RoleClaimType = ClaimTypes.Role
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

#endregion




builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>
    (options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

//builder.Services.AddHttpLogging(options =>
//{
//    // Configurações opcionais
//    //options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
//}); //Usa esse com esse...




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
//app.UseExceptionHandler("/error");

//app.Map("/error", (HttpContext context) =>
//{
//    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
//    var exception = exceptionFeature?.Error;

//    var problemDetails = new ProblemDetails
//    {
//        Status = StatusCodes.Status500InternalServerError,
//        Title = "Erro interno no servidor",
//        Detail = exception?.Message,
//        Instance = context.Request.Path
//    };

//    return Results.Problem(
//        detail: problemDetails.Detail,
//        statusCode: problemDetails.Status,
//        title: problemDetails.Title,
//        instance: problemDetails.Instance
//    );
//});

//app.UseDeveloperExceptionPage();

//app.UseHttpLogging(); usa esse com..

app.UseHttpsRedirection();

app.UseAuthentication ();

app.UseAuthorization();



app.MapControllers();

app.Run();


