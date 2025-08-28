using ControleProjetos.Data;
using ControleProjetos.Models;
using ControleProjetos.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ControleProjetos.Repositories.Repository
{
    public class ColaboradorRepository : GenericRepository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Colaborador> GetColaboradorDetailsAsync(int id)
        {
            var colaborador = await _context.Colaboradores
                .Include(q => q.ColaboradoresProjetos)
                .ThenInclude(q => q.Projeto)
                .FirstOrDefaultAsync(q => q.Id == id);
            return colaborador;
        }

     

        public async Task<ICollection<Projeto>> GetNomesProjetosDoColaboradorAsync(int colaboradorId)
        {
            var titulos = await _context.Colaboradores
                .Where(c => c.Id == colaboradorId)
                .SelectMany(c => c.ColaboradoresProjetos)
                .Select(cp => new Projeto
                {
                    Id = cp.ProjetoId,
                    Titulo = cp.Projeto.Titulo,
                    Duracao = cp.Projeto.Duracao
                })
                .Distinct()
                .ToListAsync();

            return titulos;
        }

    }


}


