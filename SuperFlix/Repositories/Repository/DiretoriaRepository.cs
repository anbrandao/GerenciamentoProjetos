using ControleProjetos.Colaboradores;
using ControleProjetos.Diretorias;
using ControleProjetos.Infraestrutura;
using ControleProjetos.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ControleProjetos.Repositories.Repository
{
    public class DiretoriaRepository : GenericRepository<Diretoria>, IDiretoriaRepository
    {

        public DiretoriaRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Diretoria> GetDiretoriaDetailsAsync(int id)
        {
            var diretoria = await _context.Diretorias
                .Include(q => q.Colaboradores).
                ThenInclude(q => q.ColaboradoresProjetos).
                ThenInclude(q => q.Projeto)
                .FirstOrDefaultAsync(q => q.Id == id);
            return diretoria;
        }

        public async Task<List<Colaborador>> GetColaboradoresDaDiretoriaAsync(int diretoriaId)
        {
            var colaboradores = await _context.Diretorias
                .Where(d => d.Id == diretoriaId)
                .SelectMany(d => d.Colaboradores)
                .Select(c => new Colaborador
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Diretoria = new Diretoria { Id =  diretoriaId, Nome = c.Diretoria.Nome}

                })
                .ToListAsync();

            return colaboradores;
        }


    }
}


