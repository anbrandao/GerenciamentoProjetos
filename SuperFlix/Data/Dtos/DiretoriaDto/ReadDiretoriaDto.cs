using ControleProjetos.Data.Dtos.ColaboradorDto;
using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Data.Dtos.DiretoriaDto
{
    public class ReadDiretoriaDto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<ReadColaboradorDto> Colaboradores { get; set; } = [];

    }
}

