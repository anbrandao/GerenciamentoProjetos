using ControleProjetos.Models;
using System.ComponentModel.DataAnnotations;

namespace ControleProjetos.Projetos
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
        public int Id { get; set; }
        public required string Titulo { get; set; }

        public int Duracao { get; set; }
        public virtual ICollection<ColaboradoresProjetos> ColaboradoresProjetos { get; set; } = [];

    }
}
