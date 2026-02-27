using ControleGR.API.Application.Commands;
using ControleGR.API.Application.Responses;
using ControleGR.API.Domain;
using ControleGR.API.Domain.Interfaces;

namespace ControleGR.API.Application.Handlers;
public class CreateTransacaoHandler
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly ITransacaoRepository _transacaoRepository;

    public CreateTransacaoHandler(IPessoaRepository pessoaRepository, ICategoriaRepository categoriaRepository, ITransacaoRepository transacaoRepository)
    {
        _pessoaRepository = pessoaRepository;
        _categoriaRepository = categoriaRepository;
        _transacaoRepository = transacaoRepository;
    }

    public async Task<CreateTransacaoResponse> Handle(CreateTransacaoCommand command)
    {
        try
        {
            var pessoa = await _pessoaRepository.GetByIdAsync(command.PessoaId);
            if (pessoa == null)
                return new CreateTransacaoResponse { ErrorMessage = "Pessoa não encontrada" };

            var categoria = await _categoriaRepository.GetByIdAsync(command.CategoriaId);
            if (categoria == null)
                return new CreateTransacaoResponse { ErrorMessage = "Categoria não encontrada" };

            var transacao = new Transacao(
                command.Descricao,
                command.Valor,
                command.TipoTransacao,
                categoria,
                pessoa
            );

            await _transacaoRepository.AddAsync(transacao);

            return new CreateTransacaoResponse { Id = transacao.Id };
        }
        catch (Exception ex)
        {
            return new CreateTransacaoResponse { ErrorMessage = ex.Message };
        }
    }
}
