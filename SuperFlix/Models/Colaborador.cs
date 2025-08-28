using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Models
{
    public class Colaborador
    {
        public Colaborador()
        {
           
        }
        public Colaborador(string nome, Diretoria diretoria)
        {
            Nome = nome;
            Diretoria = diretoria;

        }

        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public int DiretoriaId { get; set; }
        public virtual Diretoria Diretoria { get; set; }
        public virtual ICollection<ColaboradoresProjetos> ColaboradoresProjetos { get; set; } = [];
        
        public bool ehValido(bool validou)
        { if (validou == true)
                return true;
            return false;
        
        }
    }
}
