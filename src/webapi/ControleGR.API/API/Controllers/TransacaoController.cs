using ControleGR.API.Application.Commands;
using ControleGR.API.Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ControleGR.API.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacaoController : ControllerBase
{
    private readonly CreateTransacaoHandler _createTransacaoHandler;
    private readonly GetTotaisGeraisHandler _obterTotaisGeraisHandler;
    private readonly GetTotaisPorCategoriaHandler _obterTotaisPorCategoriaHandler;
    private readonly GetTransacoesHandler _getTransacoesHandler;

    public TransacaoController(CreateTransacaoHandler createTransacaoHandler, GetTotaisGeraisHandler obterTotaisGeraisHandler, GetTotaisPorCategoriaHandler obterTotaisPorCategoriaHandler, GetTransacoesHandler getTransacoesHandler)
    {
        _createTransacaoHandler = createTransacaoHandler;
        _obterTotaisGeraisHandler = obterTotaisGeraisHandler;
        _obterTotaisPorCategoriaHandler = obterTotaisPorCategoriaHandler;
        _getTransacoesHandler = getTransacoesHandler;
    }

    /// <summary>
    /// Cria uma nova transação no sistema.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateTransacao([FromBody] CreateTransacaoCommand command)
    {
        var transacaoId = await _createTransacaoHandler.Handle(command);
        return Ok(transacaoId);
    }

    /// <summary>
    /// Retorna os totais financeiros agrupados por pessoa.
    /// </summary>
    [HttpGet("totais-por-pessoa")]
    public async Task<IActionResult> ObterTotais()
    {
        var resultado = await _obterTotaisGeraisHandler.Handle();
        return Ok(resultado);
    }

    /// <summary>
    /// Retorna os totais financeiros agrupados por categoria.
    /// </summary>
    [HttpGet("totais-por-categoria")]
    public async Task<IActionResult> ObterTotaisPorCategoria()
    {
        var resultado = await _obterTotaisPorCategoriaHandler.Handle();
        return Ok(resultado);
    }

    /// <summary>
    /// Retorna todas as transações cadastradas no sistema.
    /// </summary>
    [HttpGet("transacoes")]
    public async Task<IActionResult> ObterTransacoes()
    {
        var transacoes = await _getTransacoesHandler.Handle();
        return Ok(transacoes);
    }
}