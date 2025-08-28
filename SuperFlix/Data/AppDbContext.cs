using ControleProjetos.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ControleProjetos.Data;

public class AppDbContext : DbContext
{


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
      
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ColaboradoresProjetos>().
            HasKey(colaboradoresProjetos => new { colaboradoresProjetos.ColaboradorId, colaboradoresProjetos.ProjetoId });

        builder.Entity<ColaboradoresProjetos>().
            HasOne(colaboradoresProjetos => colaboradoresProjetos.Colaborador).
            WithMany(colaborador => colaborador.ColaboradoresProjetos).
            HasForeignKey(ColaboradoresProjetos => ColaboradoresProjetos.ColaboradorId);

        builder.Entity<ColaboradoresProjetos>().
            HasOne(ColaboradoresProjetos => ColaboradoresProjetos.Projeto).
            WithMany(projetos => projetos.ColaboradoresProjetos).
            HasForeignKey(ColaboradoresProjetos => ColaboradoresProjetos.ProjetoId);

        builder.Entity<Colaborador>().HasOne(colaborador => colaborador.Diretoria).WithMany(diretoria => diretoria.Colaboradores)
            .OnDelete(DeleteBehavior.Restrict);


    }

    public DbSet<Projeto> Projetos { get; set; }

    public DbSet<Colaborador> Colaboradores { get; set; }

    public DbSet<Diretoria> Diretorias { get; set; }

    public DbSet<ColaboradoresProjetos> ColaboradoresProjetos {  get; set; }

}
