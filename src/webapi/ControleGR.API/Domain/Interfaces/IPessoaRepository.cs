namespace ControleGR.API.Domain.Interfaces;
public interface IPessoaRepository
{
    Task AddAsync(Pessoa pessoa);
    Task<Pessoa?> GetByIdAsync(Guid id);
    Task<IEnumerable<Pessoa>> GetAllAsync();
    Task<Pessoa?> UpdateAsync(Pessoa pessoa);
    Task<bool> DeleteAsync(Guid id);
}
