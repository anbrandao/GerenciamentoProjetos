using ControleProjetos.Usuarios;
using System.Net;
using System.Text.Json;

namespace ControleProjetos.Data.Dtos.UsuarioDto
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context); // Continua o pipeline
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //500

            var errorResponse = new ErrorModel(
                context.Response.StatusCode,
                "Ocorreu um erro inesperado.",
                $"Global Exception caught {ex.Message}"// Evite expor detalhes em produção
            );

            var json = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(json);
            //serializou o objeto ErrorModel para Json


        }
    }
}

