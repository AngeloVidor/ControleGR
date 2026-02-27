using ControleGR.API.Application.DTOs;

namespace ControleGR.API.Application.Responses;

public class TotaisPorCategoriaResponse
{
    public List<CategoriaTotaisDto> categorias { get; set; } = new();
    public decimal total_receitas { get; set; }
    public decimal total_despesas { get; set; }
    public decimal saldo { get; set; }
}
