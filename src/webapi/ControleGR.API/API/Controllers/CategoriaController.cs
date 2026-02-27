using ControleGR.API.Application.Commands;
using ControleGR.API.Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ControleGR.API.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly CreateCategoriaHandler _createCategoriaHandler;
    private readonly GetCategoriasHandler _getCategoriasHandler;

    public CategoriaController(CreateCategoriaHandler createCategoriaHandler, GetCategoriasHandler getCategoriasHandler)
    {
        _createCategoriaHandler = createCategoriaHandler;
        _getCategoriasHandler = getCategoriasHandler;
    }

    /// <summary>
    /// Cria uma nova categoria no sistema.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoriaCommand command)
    {
        var id = await _createCategoriaHandler.Handle(command);
        return CreatedAtAction(nameof(Create), new { id }, new { id });
    }

    /// <summary>
    /// Retorna todas as categorias cadastradas no sistema.
    /// </summary>
    [HttpGet("categorias")]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _getCategoriasHandler.Handle();
        return Ok(categorias);
    }
}