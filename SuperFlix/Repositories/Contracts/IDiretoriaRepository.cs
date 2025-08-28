using ControleProjetos.Data.Dtos.ColaboradorDto;
using ControleProjetos.Models;
using ControleProjetos.Repositories.Contracts;

namespace ControleProjetos.Repositories.Contracts
{
    public interface IDiretoriaRepository : IGenericRepository<Diretoria>
    {
        Task<List<Colaborador>> GetColaboradoresDaDiretoriaAsync(int diretoriaId);
        Task<Diretoria> GetDiretoriaDetailsAsync(int id);
    }
}

