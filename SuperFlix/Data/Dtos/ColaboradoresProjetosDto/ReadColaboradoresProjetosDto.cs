using ControleProjetos.Data.Dtos.ColaboradorDto;
using ControleProjetos.Data.Dtos.FilmeDto;
using ControleProjetos.Models;

namespace ControleProjetos.Data.Dtos.ColaboradoresProjetosDto
{
    public class ReadColaboradoresProjetosDto
    {
        public int ColaboradorId { get; set; }
        public int ProjetoId { get; set; }
        public virtual ReadColaboradorDto Colaborador { get; set; }
        public virtual ReadProjetoDto Projeto { get; set; }
    }
}
