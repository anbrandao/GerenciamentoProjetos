using ControleProjetos.Colaboradores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleProjetos.Infraestrutura
{
    public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
              builder.HasOne(colaborador => colaborador.Diretoria).WithMany(diretoria => diretoria.Colaboradores)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
