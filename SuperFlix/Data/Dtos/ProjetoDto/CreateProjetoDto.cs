using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Data.Dtos.ProjetoDto
{
    public class CreateProjetoDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int Duracao { get; set; }
    }
}
