using ControleGR.API.Domain;
using ControleGR.API.Domain.Interfaces;
using ControleGR.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleGR.API.Infrastructure.Repositories;
public class CategoriaRepository : ICategoriaRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoriaRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Categoria categoria)
    {
        await _dbContext.Categorias.AddAsync(categoria);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _dbContext.Categorias.ToListAsync();
    }

    public async Task<Categoria?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Categorias.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
