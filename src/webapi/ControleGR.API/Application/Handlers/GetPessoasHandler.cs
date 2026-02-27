using ControleGR.API.Domain;
using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class GetPessoasHandler
{
    private readonly IPessoaRepository _pessoaRepository;

    public GetPessoasHandler(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<IEnumerable<Pessoa>> Handle()
    {
        return await _pessoaRepository.GetAllAsync();
    }
}
