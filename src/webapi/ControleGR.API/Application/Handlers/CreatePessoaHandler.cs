using ControleGR.API.Application.Commands;
using ControleGR.API.Domain;
using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class CreatePessoaHandler
{
    private readonly IPessoaRepository _pessoaRepository;

    public CreatePessoaHandler(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<Guid> Handle(CreatePessoaCommand command)
    {
        var pessoa = new Pessoa(command.Nome, command.Idade);
        await _pessoaRepository.AddAsync(pessoa);
        return pessoa.Id;
    }
}
