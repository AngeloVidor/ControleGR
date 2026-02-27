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

    [HttpPost]
    public async Task<IActionResult> CreateTransacao([FromBody] CreateTransacaoCommand command)
    {
        var transacaoId = await _createTransacaoHandler.Handle(command);
        return Ok(transacaoId);
    }

    [HttpGet("totais")]
    public async Task<IActionResult> ObterTotais()
    {
        var resultado = await _obterTotaisGeraisHandler.Handle();
        return Ok(resultado);
    }

    [HttpGet("totais-por-categoria")]
    public async Task<IActionResult> ObterTotaisPorCategoria()
    {
        var resultado = await _obterTotaisPorCategoriaHandler.Handle();
        return Ok(resultado);
    }

    [HttpGet("transacoes")]
    public async Task<IActionResult> ObterTransacoes()
    {
        var transacoes = await _getTransacoesHandler.Handle();
        return Ok(transacoes);
    }
}
