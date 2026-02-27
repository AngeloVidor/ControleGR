namespace ControleGR.API.Application.Responses;
public class CreateTransacaoResponse
{
    public Guid? Id { get; set; }
    public string? ErrorMessage { get; set; }
    public bool Success => string.IsNullOrEmpty(ErrorMessage);
}
