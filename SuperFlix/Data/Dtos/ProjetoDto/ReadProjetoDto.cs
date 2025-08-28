using ControleProjetos.Data.Dtos.ColaboradoresProjetosDto;
using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Data.Dtos.FilmeDto
{
    public class ReadProjetoDto
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }

        public ICollection<ReadColaboradoresProjetosDto> ColaboradoresProjetos { get; set; } = [];
    }
}
