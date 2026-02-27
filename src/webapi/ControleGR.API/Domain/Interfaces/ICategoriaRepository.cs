
namespace ControleGR.API.Domain.Interfaces;
public interface ICategoriaRepository
{
    Task AddAsync(Categoria categoria);
    Task<Categoria?> GetByIdAsync(Guid id);
    Task<IEnumerable<Categoria>> GetAllAsync();
}
