using AutoMapper;
using ControleProjetos.Data.Dtos.UsuarioDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControleProjetos.Usuarios
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastraUsuarioService)
        {
            _usuarioService = cadastraUsuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IResult> CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            var cadastro = await _usuarioService.CadastraUsuario(createUsuarioDto);
            return Results.Ok(cadastro);

        }

        [HttpPost("login")]
        public async Task<IResult> Login(LoginUsuarioDto loginUsuarioDto)
        {
            
            var token = await _usuarioService.Login(loginUsuarioDto);
            return Results.Ok(token);
        }

    }
}

