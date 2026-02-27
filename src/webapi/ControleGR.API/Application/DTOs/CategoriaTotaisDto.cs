namespace ControleGR.API.Application.DTOs;

public class CategoriaTotaisDto
{
    public Guid categoria_id { get; set; }
    public decimal total_receitas { get; set; }
    public decimal total_despesas { get; set; }
    public decimal saldo { get; set; }
}
