using ControleGR.API.Application.DTOs;
using ControleGR.API.Application.Responses;
using ControleGR.API.Domain;
using ControleGR.API.Domain.Enums;
using ControleGR.API.Domain.Interfaces;
using ControleGR.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleGR.API.Infrastructure.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TransacaoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Transacao transacao)
    {
        await _dbContext.Transacoes.AddAsync(transacao);
        await SaveChangesAsync();
    }

    //Para cada pessoa, calcula o total de receitas e despesas somando os valores das transações.
    //Depois calcula o total geral de receitas e despesas somando os totais individuais.
    //Retorna um objeto com a lista de pessoas e os totais agregados.
    public async Task<TotaisPorPessoaResponse> ObterTotaisPorPessoaAsync()
    {
        var pessoas = await _dbContext.Pessoas
            .Select(p => new PessoasTotaisDto
            {
                pessoa_id = p.Id,
                nome = p.Nome,

                total_receitas = p.Transacoes
                    .Where(t => t.TipoTransacao == TipoTransacao.Receita)
                    .Sum(t => (decimal?)t.Valor) ?? 0,

                total_despesas = p.Transacoes
                    .Where(t => t.TipoTransacao == TipoTransacao.Despesa)
                    .Sum(t => (decimal?)t.Valor) ?? 0,

                saldo = (p.Transacoes
                        .Where(t => t.TipoTransacao == TipoTransacao.Receita)
                        .Sum(t => (decimal?)t.Valor) ?? 0)
                    - (p.Transacoes
                        .Where(t => t.TipoTransacao == TipoTransacao.Despesa)
                        .Sum(t => (decimal?)t.Valor) ?? 0)
            })
            .ToListAsync();

        var totalReceitas = pessoas.Sum(x => x.total_receitas);
        var totalDespesas = pessoas.Sum(x => x.total_despesas);
        var saldoGeral = totalReceitas - totalDespesas;


        return new TotaisPorPessoaResponse
        {
            pessoas = pessoas,
            total_receitas = totalReceitas,
            total_despesas = totalDespesas,
            saldo = saldoGeral

        };
    }

    //Para cada categoria, calcula o total de receitas e despesas somando os valores das transações daquela categoria.
    //Depois calcula o total geral de receitas e despesas somando os totais por categoria.
    //Retorna um objeto com a lista de categorias e os totais agregados.
    public async Task<TotaisPorCategoriaResponse> ObterTotaisPorCategoriaAsync()
    {
        var categorias = await _dbContext.Categorias
            .Select(c => new CategoriaTotaisDto
            {
                categoria_id = c.Id,

                total_receitas = c.Transacoes
                    .Where(t => t.TipoTransacao == TipoTransacao.Receita)
                    .Sum(t => (decimal?)t.Valor) ?? 0,

                total_despesas = c.Transacoes
                    .Where(t => t.TipoTransacao == TipoTransacao.Despesa)
                    .Sum(t => (decimal?)t.Valor) ?? 0,

                saldo = (c.Transacoes
                        .Where(t => t.TipoTransacao == TipoTransacao.Receita)
                        .Sum(t => (decimal?)t.Valor) ?? 0)
                    - (c.Transacoes
                        .Where(t => t.TipoTransacao == TipoTransacao.Despesa)
                        .Sum(t => (decimal?)t.Valor) ?? 0)
            })
            .ToListAsync();

        var totalReceitas = categorias.Sum(x => x.total_receitas);
        var totalDespesas = categorias.Sum(x => x.total_despesas);

        return new TotaisPorCategoriaResponse
        {
            categorias = categorias,
            total_receitas = totalReceitas,
            total_despesas = totalDespesas
        };
    }

    public async Task<IEnumerable<Transacao>> GetAllAsync()
    {
        return await _dbContext.Transacoes.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }


}
