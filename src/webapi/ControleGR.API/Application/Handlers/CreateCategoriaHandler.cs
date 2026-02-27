using ControleGR.API.Application.Commands;
using ControleGR.API.Domain;
using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class CreateCategoriaHandler
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CreateCategoriaHandler(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<Guid> Handle(CreateCategoriaCommand command)
    {
        var categoria = new Categoria(command.Descricao, command.Finalidade);
        await _categoriaRepository.AddAsync(categoria);
        return categoria.Id;
    }
}
