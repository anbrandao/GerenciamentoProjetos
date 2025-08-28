using ControleProjetos.Data.Dtos.ColaboradorDto;

namespace ControleProjetos.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task DeleteAsync(int id);
        Task DeleteEntityAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> Exists(int id);
      
    }
}
