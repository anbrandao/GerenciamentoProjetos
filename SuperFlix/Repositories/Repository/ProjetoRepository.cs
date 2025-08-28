

using ControleProjetos.Data;
using ControleProjetos.Models;
using ControleProjetos.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ControleProjetos.Repositories.Repository
{
    public class ProjetoRepository : GenericRepository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Projeto> GetProjetoDetailsAsync(int id)
        {
            var projeto = await _context.Projetos
                .Include(q => q.ColaboradoresProjetos)
                .ThenInclude(q => q.Colaborador)
                .FirstOrDefaultAsync(q => q.Id == id);
            return projeto;
        }
    }
}
