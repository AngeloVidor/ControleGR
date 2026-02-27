using ControleGR.API.Domain.Enums;

namespace ControleGR.API.Domain;
public class Transacao
{
    public Guid Id { get; private set; }
    public string Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public TipoTransacao TipoTransacao { get; private set; }

    public Guid CategoriaId { get; private set; }
    public Categoria Categoria { get; private set; }

    public Guid PessoaId { get; private set; }
    public Pessoa Pessoa { get; private set; }

    protected Transacao() { }

    public Transacao(string descricao, decimal valor, TipoTransacao tipoTransacao, Categoria categoria, Pessoa pessoa)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("descricao obrigatoria");

        //Descricao obrigatória e com no máximo 400 caracteres.
        if (descricao.Length > 400)
            throw new ArgumentException("descricao deve ter no maximo 400 caracteres");

        //Valor deve ser positivo.
        if (valor <= 0)
            throw new ArgumentException("valor deve ser positivo");

        //Menor de idade não pode receber receita.
        if (pessoa.EhMenorDeIdade() && tipoTransacao == TipoTransacao.Receita)
            throw new ArgumentException("menor de idade nao pode ter receita");

        //A categoria deve permitir o tipo da transação(receita/despesa).
        if (!categoria.Permite(tipoTransacao))
            throw new ArgumentException("categoria nao permite esse tipo de transacao");

        Id = Guid.NewGuid();
        Descricao = descricao;
        Valor = valor;
        TipoTransacao = tipoTransacao;

        CategoriaId = categoria.Id;
        PessoaId = pessoa.Id;

        Categoria = categoria;
        Pessoa = pessoa;
    }
}