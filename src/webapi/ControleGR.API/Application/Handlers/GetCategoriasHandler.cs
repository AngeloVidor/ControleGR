using ControleGR.API.Domain;
using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class GetCategoriasHandler
{
    private readonly ICategoriaRepository _categoriaRepository;

    public GetCategoriasHandler(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<IEnumerable<Categoria>> Handle()
    {
        return await _categoriaRepository.GetAllAsync();
    }
}
