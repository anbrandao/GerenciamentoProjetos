using ControleProjetos.Colaboradores;
using ControleProjetos.Diretorias;
using ControleProjetos.Models;
using ControleProjetos.Projetos;
using ControleProjetos.Usuarios;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ControleProjetos.Infraestrutura;

public class AppDbContext :  DbContext
{
    private readonly string _connectionstring;

    public AppDbContext()
    {
     
    }

    public AppDbContext(string connectionstring)
    {
        _connectionstring = connectionstring;
    }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }


    // CONFIGURACAO REDUNDANTE QUE FALOU NA POS
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionstring);
        }

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.ApplyConfiguration(new ColaboradorProjetoConfiguration());
        //builder.ApplyConfiguration(new ColaboradorConfiguration());

        //O codigo abaixo faz isso de cima mas por baixo dos panos usando
        //o IEntityTypeConfiguration
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
 
   

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    builder.Entity<ColaboradoresProjetos>(cp =>
    //    {
    //        cp.HasKey(p => new { p.ColaboradorId, p.ProjetoId });
    //    } // A entidade tem uma chave que pega as propriedade que tem na classe <ColaboradoresProjetos>
    //    );


    //    builder.Entity<ColaboradoresProjetos>(e =>
    //    {
    //        e.HasOne(p => p.Colaborador).
    //        WithMany(c => c.ColaboradoresProjetos).
    //        //HasPrincipalKey(c => c.Id); Ao inves de como abaixo pode
    //        //mencionar que o cliente tem chavePrimaria Id
    //        HasForeignKey(e => e.ColaboradorId);
    //    } // A entidade ColaboradoresProjetos(ex:pedido) tem 1 colaborador com muitos colaboradoresProjetos (ex. pedidos)
    //    );
            

    //    builder.Entity<ColaboradoresProjetos>().
    //        HasOne(ColaboradoresProjetos => ColaboradoresProjetos.Projeto).
    //        WithMany(projetos => projetos.ColaboradoresProjetos).
    //        HasForeignKey(ColaboradoresProjetos => ColaboradoresProjetos.ProjetoId);

    //    builder.Entity<Colaborador>().HasOne(colaborador => colaborador.Diretoria).WithMany(diretoria => diretoria.Colaboradores)
    //        .OnDelete(DeleteBehavior.Restrict);


    //}

    public DbSet<Projeto> Projetos { get; set; }

    public DbSet<Colaborador> Colaboradores { get; set; }

    public DbSet<Diretoria> Diretorias { get; set; }

    public DbSet<ColaboradoresProjetos> ColaboradoresProjetos {  get; set; }

    

}
