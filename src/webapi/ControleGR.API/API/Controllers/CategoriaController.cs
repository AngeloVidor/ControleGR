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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoriaCommand command)
    {
        var id = await _createCategoriaHandler.Handle(command);
        return CreatedAtAction(nameof(Create), new { id }, new { id });
    }

    [HttpGet("categorias")]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _getCategoriasHandler.Handle();
        return Ok(categorias);
    }


}
