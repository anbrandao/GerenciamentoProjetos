using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Data.Dtos.UsuarioDto
{
    public class LoginUsuarioDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
