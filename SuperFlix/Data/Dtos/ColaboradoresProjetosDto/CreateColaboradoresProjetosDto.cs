
using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Data.Dtos.ColaboradoresProjetosDto
{
    public class CreateColaboradoresProjetosDto
    {
        [Required]
        public int ColaboradorId { get; set; }
        [Required]
        public int ProjetoId { get; set; }
     
    }
}
