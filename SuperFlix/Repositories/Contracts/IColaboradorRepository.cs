using ControleProjetos.Colaboradores;
using ControleProjetos.Projetos;

namespace ControleProjetos.Repositories.Contracts
{
    public interface IColaboradorRepository : IGenericRepository<Colaborador>
    {
        Task<Colaborador> GetColaboradorDetailsAsync(int id);
        Task<ICollection<Projeto>> GetNomesProjetosDoColaboradorAsync(int colaboradorId);
    }
}

