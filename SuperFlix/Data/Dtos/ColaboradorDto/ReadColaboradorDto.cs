using ControleProjetos.Data.Dtos.ColaboradoresProjetosDto;
using ControleProjetos.Data.Dtos.DiretoriaDto;
using ControleProjetos.Models;
using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Data.Dtos.ColaboradorDto
{
    public class ReadColaboradorDto
  
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DiretoriaId { get; set; }

        public ReadDiretoriaDto Diretoria { get; set; }

        public ICollection<ReadColaboradoresProjetosDto> ColaboradoresProjetos { get; set; } = [];


    }
}

