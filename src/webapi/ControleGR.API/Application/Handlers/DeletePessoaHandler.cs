using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class DeletePessoaHandler
{
    private readonly IPessoaRepository _repository;

    public DeletePessoaHandler(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(Guid id)
    {
        var deleted = await _repository.DeleteAsync(id);

        if (!deleted)
            throw new Exception("Pessoa não encontrada");

        return true;
    }
}
