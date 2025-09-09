using ControleProjetos.Colaboradores;
using ControleProjetos.Projetos;

namespace ControleProjetos.Models
{
    public class ColaboradoresProjetos
    {
        public ColaboradoresProjetos()
        {
            
        }
        public ColaboradoresProjetos(int colaboradorId, int projetoId)
        {
            ColaboradorId = colaboradorId;
            ProjetoId = projetoId;
        }

        public int ColaboradorId { get; set; }
        public int ProjetoId { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        public virtual Projeto Projeto { get; set; }
    }
}
