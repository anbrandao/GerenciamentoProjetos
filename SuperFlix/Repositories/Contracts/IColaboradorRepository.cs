using ControleProjetos.Models;
using ControleProjetos.Repositories.Contracts;

namespace ControleProjetos.Repositories.Contracts
{
    public interface IColaboradorRepository : IGenericRepository<Colaborador>
    {
        Task<Colaborador> GetColaboradorDetailsAsync(int id);
        Task<ICollection<Projeto>> GetNomesProjetosDoColaboradorAsync(int colaboradorId);
    }
}

