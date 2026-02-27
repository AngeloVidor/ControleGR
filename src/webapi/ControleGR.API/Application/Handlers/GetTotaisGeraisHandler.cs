using ControleGR.API.Application.Responses;
using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class GetTotaisGeraisHandler
{
    private readonly ITransacaoRepository _transacaoRepository;

    public GetTotaisGeraisHandler(ITransacaoRepository transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }

    public async Task<TotaisPorPessoaResponse> Handle()
    {
        return await _transacaoRepository.ObterTotaisPorPessoaAsync();
    }
}
