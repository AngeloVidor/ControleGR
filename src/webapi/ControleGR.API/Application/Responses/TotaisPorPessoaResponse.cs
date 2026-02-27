using ControleGR.API.Application.DTOs;

namespace ControleGR.API.Application.Responses;

public class TotaisPorPessoaResponse
{
    public decimal total_receitas { get; set; }
    public decimal total_despesas { get; set; }
    public decimal saldo { get; set; }
    public List<PessoasTotaisDto> pessoas { get; set; } = new();

}
