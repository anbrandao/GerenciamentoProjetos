using ControleProjetos.Usuarios;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleProjetos.Infraestrutura
{ 
    public class UsuarioDbContext : IdentityDbContext<Usuario> {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts) 
        { 
        }
        //protected override void OnModelCreating(ModelBuilder builder) 
        //{base.OnModelCreating(builder);
        //    builder.ApplyConfiguration(new UsuarioRoleConfiguration());
        //}
    }
}
