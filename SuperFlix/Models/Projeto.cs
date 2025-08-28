using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Models
{
    public class Projeto
    {
        public Projeto()
        {

        }
        public Projeto(string titulo, int duracao)
        {
            Titulo = titulo;
            Duracao = duracao;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public string Titulo { get; set; }

        public int Duracao { get; set; }
        public virtual ICollection<ColaboradoresProjetos> ColaboradoresProjetos { get; set; } = [];

    }
}
