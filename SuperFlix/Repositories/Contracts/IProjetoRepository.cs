using ControleProjetos.Projetos;

namespace ControleProjetos.Repositories.Contracts
{
    public interface IProjetoRepository : IGenericRepository<Projeto>
    {
        Task<Projeto> GetProjetoDetailsAsync(int id);
    }
}


