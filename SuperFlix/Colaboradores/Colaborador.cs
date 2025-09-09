using ControleProjetos.Diretorias;
using ControleProjetos.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleProjetos.Colaboradores
{
    /// <summary>
    /// Pessoa física funcionário da empresa <see href="https://wiki.projetosAzure.com"/>
    /// </summary>
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
        public int Id { get; set; }
        [JsonPropertyName("NomeJSONTeste")]
        public string Nome { get; set; }
        public int DiretoriaId { get; set; }
        public virtual Diretoria Diretoria { get; set; }
        public virtual ICollection<ColaboradoresProjetos> ColaboradoresProjetos { get; set; } = [];
        
        public bool ehValido(string validou)
        { if (validou.Length >= 7)
                return true;
            return false;
        
        }
    }
}
