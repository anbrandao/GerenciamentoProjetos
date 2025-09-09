using ControleProjetos.Colaboradores;
using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Diretorias
{
    public class Diretoria
    {
        public Diretoria()
        {
            
        }
        public Diretoria(string nome)
        {
            Nome = nome;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Colaborador> Colaboradores { get; set; } = [];

    }
}
