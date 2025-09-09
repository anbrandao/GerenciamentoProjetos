using ControleProjetos.Models;
using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Data.Dtos.DiretoriaDto
{
    public class CreateDiretoriaDto
    {
        [Required]
        public string Nome { get; set; }

    }
}
