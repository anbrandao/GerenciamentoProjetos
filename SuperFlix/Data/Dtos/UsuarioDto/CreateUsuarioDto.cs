using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Data.Dtos.UsuarioDto
{
    public class CreateUsuarioDto
    {
        [Display(Name = "E-mail (*)", Prompt = "Digite seu melhor e-mail.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required]
        [Compare("Password")]
        public string Repassword{ get; set; }
        [Required]
        public string Role {  get; set; }
    }
}
