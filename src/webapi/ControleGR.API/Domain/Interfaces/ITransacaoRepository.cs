using ControleGR.API.Application.Responses;

namespace ControleGR.API.Domain.Interfaces;
public interface ITransacaoRepository
{
    Task AddAsync(Transacao transacao);
    Task<IEnumerable<Transacao>> GetAllAsync();
    Task<TotaisPorPessoaResponse> ObterTotaisPorPessoaAsync();
    Task<TotaisPorCategoriaResponse> ObterTotaisPorCategoriaAsync();
}
