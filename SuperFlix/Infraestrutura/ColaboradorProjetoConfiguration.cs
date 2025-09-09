using ControleProjetos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleProjetos.Infraestrutura
{
    public class ColaboradorProjetoConfiguration : IEntityTypeConfiguration<ColaboradoresProjetos>
    {
        public void Configure(EntityTypeBuilder<ColaboradoresProjetos> builder)
        {
         
                builder.HasKey(cp => new { cp.ColaboradorId, cp.ProjetoId });
         
         
                builder.HasOne(cp => cp.Colaborador).
                WithMany(c => c.ColaboradoresProjetos).
                HasPrincipalKey(c => c.Id).// Ao inves de como abaixo pode
                //mencionar que o cliente tem chavePrimaria Id
                HasForeignKey(cp => cp.ColaboradorId);
            // A entidade ColaboradoresProjetos(ex:pedido) tem 1 colaborador com muitos colaboradoresProjetos (ex. pedidos)

                builder.HasOne(ColaboradoresProjetos => ColaboradoresProjetos.Projeto).
                WithMany(projetos => projetos.ColaboradoresProjetos).
                HasForeignKey(ColaboradoresProjetos => ColaboradoresProjetos.ProjetoId);
        }
    }
}
