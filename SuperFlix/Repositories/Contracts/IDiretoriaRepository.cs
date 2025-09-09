using ControleProjetos.Colaboradores;
using ControleProjetos.Data.Dtos.ColaboradorDto;
using ControleProjetos.Diretorias;
using ControleProjetos.Repositories.Contracts;

namespace ControleProjetos.Repositories.Contracts
{
    public interface IDiretoriaRepository : IGenericRepository<Diretoria>
    {
        Task<List<Colaborador>> GetColaboradoresDaDiretoriaAsync(int diretoriaId);
        Task<Diretoria> GetDiretoriaDetailsAsync(int id);
    }
}

