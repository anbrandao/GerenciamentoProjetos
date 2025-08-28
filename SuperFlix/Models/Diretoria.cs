using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Models
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
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Colaborador> Colaboradores { get; set; } = [];

    }
}
