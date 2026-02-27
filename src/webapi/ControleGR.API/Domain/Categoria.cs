using System.Text.Json.Serialization;
using ControleGR.API.Domain.Enums;

namespace ControleGR.API.Domain;
public class Categoria
{
    public Guid Id { get; private set; }
    public string Descricao { get; private set; }
    public Finalidade Finalidade { get; private set; }
    [JsonIgnore]
    public ICollection<Transacao> Transacoes { get; private set; } = new List<Transacao>();


    public Categoria(string descricao, Finalidade finalidade)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("descricao obrigatoria");

        if (descricao.Length > 400)
            throw new ArgumentException("descricao deve ter no maximo 400 caracteres");

        Id = Guid.NewGuid();
        Descricao = descricao;
        Finalidade = finalidade;
    }

    //Verifica se o tipo de transação passado é compatível com a finalidade da categoria.
    //Se a categoria aceita "Ambas", sempre retorna true.
    //Se a categoria é "Despesa", retorna true apenas para transações de despesa.
    //Se a categoria é "Receita", retorna true apenas para transações de receita.
    //Caso contrário, retorna false.
    public bool Permite(TipoTransacao tipo)
    {
        if (Finalidade == Finalidade.Ambas)
            return true;

        if (Finalidade == Finalidade.Despesa && tipo == TipoTransacao.Despesa)
            return true;

        if (Finalidade == Finalidade.Receita && tipo == TipoTransacao.Receita)
            return true;

        return false;
    }

}