using ControleProjetos.Data.Dtos.DiretoriaDto;
using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Data.Dtos.ColaboradorDto
{
    public class CreateColaboradorDto
    {
        [Display(Name = "Nome (*)", Prompt = "Digite o nome completo do colaborador.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }
        [Required]
        public int DiretoriaId { get; set; }
       

    }
}


