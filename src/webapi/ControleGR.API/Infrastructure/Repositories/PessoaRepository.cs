using ControleGR.API.Domain;
using ControleGR.API.Domain.Interfaces;
using ControleGR.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleGR.API.Infrastructure.Repositories;
public class PessoaRepository : IPessoaRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PessoaRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Pessoa pessoa)
    {
        await _dbContext.Pessoas.AddAsync(pessoa);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<Pessoa>> GetAllAsync()
    {
        return await _dbContext.Pessoas.ToListAsync();
    }

    public async Task<Pessoa?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Pessoas.FindAsync(id);
    }

    public async Task<Pessoa?> UpdateAsync(Pessoa pessoa)
    {
        _dbContext.Pessoas.Update(pessoa);
        await SaveChangesAsync();
        return pessoa;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var pessoa = await _dbContext.Pessoas.FindAsync(id);

        if (pessoa == null)
            return false;

        _dbContext.Pessoas.Remove(pessoa);
        await SaveChangesAsync();

        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
