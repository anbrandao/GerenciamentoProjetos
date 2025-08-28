using ControleProjetos.Models;
using ControleProjetos.Repositories.Contracts;

namespace ControleProjetos.Repositories.Contracts
{
    public interface IColaboradoresProjetosRepository : IGenericRepository<ColaboradoresProjetos>
    {
        Task<ColaboradoresProjetos> GetColaboradoresProjetosPorIdsAsync(int colaboradorId, int projetoId);
    }
}
