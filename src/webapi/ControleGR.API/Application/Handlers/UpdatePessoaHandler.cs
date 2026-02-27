using ControleGR.API.Application.Commands;
using ControleGR.API.Domain;
using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class UpdatePessoaHandler
{
    private readonly IPessoaRepository _pessoaRepository;

    public UpdatePessoaHandler(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<Pessoa?> Handle(Guid id, UpdatePessoaCommand command)
    {
        var existingPessoa = await _pessoaRepository.GetByIdAsync(id);
        if (existingPessoa == null)
            throw new Exception("Pessoa não encontrada");

        existingPessoa.Atualizar(command.Nome, command.Idade);

        return await _pessoaRepository.UpdateAsync(existingPessoa);
    }
}
