using Microsoft.AspNetCore.Identity;

namespace ControleProjetos.Usuarios
{
    public class Usuario : IdentityUser
    {
        public Usuario() : base()
        {
        }

        public DateTime DataNascimento { get; set; }

        public string Role { get; set; }

    }
}
