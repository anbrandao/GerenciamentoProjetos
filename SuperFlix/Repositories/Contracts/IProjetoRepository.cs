using ControleProjetos.Models;

namespace ControleProjetos.Repositories.Contracts
{
    public interface IProjetoRepository : IGenericRepository<Projeto>
    {
        Task<Projeto> GetProjetoDetailsAsync(int id);
    }
}


