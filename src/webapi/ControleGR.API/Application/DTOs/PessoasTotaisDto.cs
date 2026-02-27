namespace ControleGR.API.Application.DTOs;

public class PessoasTotaisDto
{
    public Guid pessoa_id { get; set; }
    public string nome { get; set; } = string.Empty;
    public decimal total_receitas { get; set; }
    public decimal total_despesas { get; set; }
    public decimal saldo { get; set; }
}
