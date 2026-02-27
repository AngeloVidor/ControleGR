using ControleGR.API.Application.Responses;
using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class GetTotaisPorCategoriaHandler
{
    private readonly ITransacaoRepository _repository;

    public GetTotaisPorCategoriaHandler(ITransacaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<TotaisPorCategoriaResponse> Handle()
    {
        return await _repository.ObterTotaisPorCategoriaAsync();
    }
}
