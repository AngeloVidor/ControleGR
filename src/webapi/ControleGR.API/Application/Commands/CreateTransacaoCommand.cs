using ControleGR.API.Domain.Enums;

namespace ControleGR.API.Application.Commands;

public record CreateTransacaoCommand(string Descricao, decimal Valor, TipoTransacao TipoTransacao, Guid CategoriaId, Guid PessoaId);

