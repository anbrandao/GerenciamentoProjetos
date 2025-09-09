using ControleProjetos.Infraestrutura;
using ControleProjetos.Models;
using ControleProjetos.Repositories.Contracts;
using ControleProjetos.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace ControleProjetos.Repositories.Repository
{
    public class ColaboradoresProjetosRepository : GenericRepository<ColaboradoresProjetos>, IColaboradoresProjetosRepository
    {

        public ColaboradoresProjetosRepository(AppDbContext context) : base(context)
        {
        }
   
        public async Task<ColaboradoresProjetos> GetColaboradoresProjetosPorIdsAsync(int colaboradorId, int projetoId)
        {
            var colaboradorProjeto = await _context.ColaboradoresProjetos
                .FirstOrDefaultAsync(colaboradoresProjetos => colaboradoresProjetos.ColaboradorId == colaboradorId && colaboradoresProjetos.ProjetoId == projetoId);
            return colaboradorProjeto;
        }
    }
}
