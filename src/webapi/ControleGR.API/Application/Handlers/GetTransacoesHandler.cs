using ControleGR.API.Domain;
using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class GetTransacoesHandler
{
    private readonly ITransacaoRepository _transacaoRepository;

    public GetTransacoesHandler(ITransacaoRepository transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }

    public async Task<IEnumerable<Transacao>> Handle()
    {
        return await _transacaoRepository.GetAllAsync();
    }
}
