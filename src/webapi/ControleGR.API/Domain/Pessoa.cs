using System.Text.Json.Serialization;

namespace ControleGR.API.Domain;
public class Pessoa
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public int Idade { get; private set; }
    [JsonIgnore]
    public ICollection<Transacao> Transacoes { get; private set; } = new List<Transacao>();


    public Pessoa(string nome, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("nome obrigatorio");

        if (nome.Length > 200)
            throw new ArgumentException("nome deve ter no maximo 200 caracteres");

        if (idade <= 0)
            throw new ArgumentException("idade invalida");

        Id = Guid.NewGuid();
        Nome = nome;
        Idade = idade;
    }

    public void Atualizar(string nome, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("nome obrigatorio");

        if (nome.Length > 200)
            throw new ArgumentException("nome deve ter no maximo 200 caracteres");

        if (idade < 0)
            throw new ArgumentException("idade invalida");

        Nome = nome;
        Idade = idade;
    }

    // Verifica se a pessoa é menor de idade.
    // Retorna true se a idade for menor que 18 anos, false caso contrário.
    public bool EhMenorDeIdade()
        => Idade < 18;
}
