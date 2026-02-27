using Microsoft.AspNetCore.Mvc;
using ControleGR.API.Application.Commands;
using ControleGR.API.Application.Handlers;

namespace ControleGR.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoasController : ControllerBase
{
    private readonly CreatePessoaHandler _handler;
    private readonly GetPessoasHandler _getPessoasHandler;
    private readonly UpdatePessoaHandler _updatePessoaHandler;
    private readonly DeletePessoaHandler _deletePessoaHandler;

    public PessoasController(CreatePessoaHandler handler, GetPessoasHandler getPessoasHandler, UpdatePessoaHandler updatePessoaHandler, DeletePessoaHandler deletePessoaHandler)
    {
        _handler = handler;
        _getPessoasHandler = getPessoasHandler;
        _updatePessoaHandler = updatePessoaHandler;
        _deletePessoaHandler = deletePessoaHandler;
    }

    /// <summary>
    /// Cria uma nova pessoa no sistema.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePessoaCommand command)
    {
        var id = await _handler.Handle(command);
        return CreatedAtAction(nameof(Create), new { id }, new { id });
    }

    /// <summary>
    /// Retorna todas as pessoas cadastradas no sistema.
    /// </summary>
    [HttpGet("pessoas")]
    public async Task<IActionResult> GetPessoas()
    {
        var pessoas = await _getPessoasHandler.Handle();
        return Ok(pessoas);
    }

    /// <summary>
    /// Atualiza os dados de uma pessoa existente.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePessoa(Guid id, [FromBody] UpdatePessoaCommand command)
    {
        try
        {
            var pessoa = await _updatePessoaHandler.Handle(id, command);
            return Ok(pessoa);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Remove uma pessoa do sistema.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePessoa(Guid id)
    {
        try
        {
            await _deletePessoaHandler.Handle(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}