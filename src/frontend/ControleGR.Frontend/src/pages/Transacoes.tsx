import React from "react";
import CadastrarTransacao from "../components/CadastrarTransacao";
import { useTransacoes } from "../hooks/useTransacoes";
import { getTipoTransacaoLabel } from "../types/transacao";

const Transacoes: React.FC = () => {
  const { transacoes, totais, totaisPorCategoria, refetchAll } = useTransacoes();

  // Função pra formatar números como dinheiro
  const formatarValor = (valor: number) => valor.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });

  // Função para obter o nome da pessoa pelo ID
  const obterNomePessoa = (pessoaId: string) => {
    return totais?.pessoas?.find(p => p.pessoa_id === pessoaId)?.nome || pessoaId;
  };

  // Calcula totais de pessoas
  const calcularTotaisPessoas = () => {
    if (!totais?.pessoas) return { totalReceitas: 0, totalDespesas: 0, saldo: 0 };
    const totalReceitas = totais.pessoas.reduce((acc, p) => acc + p.total_receitas, 0);
    const totalDespesas = totais.pessoas.reduce((acc, p) => acc + p.total_despesas, 0);
    return { totalReceitas, totalDespesas, saldo: totalReceitas - totalDespesas };
  };

  // Calcula totais de categorias
  const calcularTotaisCategorias = () => {
    if (!totaisPorCategoria?.categorias) return { totalReceitas: 0, totalDespesas: 0, saldo: 0 };
    const totalReceitas = totaisPorCategoria.categorias.reduce((acc, c) => acc + c.total_receitas, 0);
    const totalDespesas = totaisPorCategoria.categorias.reduce((acc, c) => acc + c.total_despesas, 0);
    return { totalReceitas, totalDespesas, saldo: totalReceitas - totalDespesas };
  };

  return (
    <div style={{ display: "flex", flexDirection: "column", alignItems: "center", padding: 20, minHeight: "100vh" }}>
      <h1>Transações</h1>

      <CadastrarTransacao onSucesso={refetchAll} />

      {/* Lista de transações */}
      <h2 style={{ width: "100%", maxWidth: 900, paddingTop: 20 }}>Lista de Transações</h2>
      {transacoes.length === 0 ? (
        <p>Nenhuma transação cadastrada</p>
      ) : (
        <table border={1} cellPadding={5} style={{ marginTop: 10, marginBottom: 20, width: "100%", maxWidth: 900 }}>
          <thead>
            <tr>
              <th>Descrição</th>
              <th>Valor</th>
              <th>Tipo</th>
              <th>Categoria</th>
              <th>Pessoa</th>
            </tr>
          </thead>
          <tbody>
            {transacoes.map(t => (
              <tr key={t.id}>
                <td>{t.descricao}</td>
                <td>{formatarValor(t.valor)}</td>
                <td>{getTipoTransacaoLabel(t.tipoTransacao)}</td>
                <td>{t.categoriaId}</td>
                <td>{obterNomePessoa(t.pessoaId)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      {/* Totais por pessoa */}
      <h2 style={{ width: "100%", maxWidth: 900, paddingTop: 20 }}>Totais por Pessoa</h2>
      {totais?.pessoas ? (
        <>
          <table border={1} cellPadding={5} style={{ width: "100%", maxWidth: 900, marginBottom: 20 }}>
            <thead>
              <tr>
                <th>Nome</th>
                <th>Receitas</th>
                <th>Despesas</th>
                <th>Saldo</th>
              </tr>
            </thead>
            <tbody>
              {totais.pessoas.map(p => (
                <tr key={p.pessoa_id}>
                  <td>{p.nome}</td>
                  <td>{formatarValor(p.total_receitas)}</td>
                  <td>{formatarValor(p.total_despesas)}</td>
                  <td>{formatarValor(p.saldo)}</td>
                </tr>
              ))}
              {/* Total geral de todas as pessoas */}
              <tr style={{ fontWeight: "bold", backgroundColor: "#000000" }}>
                <td>Total Geral</td>
                <td>{formatarValor(calcularTotaisPessoas().totalReceitas)}</td>
                <td>{formatarValor(calcularTotaisPessoas().totalDespesas)}</td>
                <td>{formatarValor(calcularTotaisPessoas().saldo)}</td>
              </tr>
            </tbody>
          </table>
        </>
      ) : (
        <p>Carregando totais por pessoa...</p>
      )}

      {/* Totais por categoria */}
      <h2 style={{ width: "100%", maxWidth: 900, paddingTop: 20 }}>Totais por Categoria</h2>
      {totaisPorCategoria?.categorias ? (
        <table border={1} cellPadding={5} style={{ width: "100%", maxWidth: 900, marginBottom: 20 }}>
          <thead>
            <tr>
              <th>Categoria</th>
              <th>Receitas</th>
              <th>Despesas</th>
              <th>Saldo</th>
            </tr>
          </thead>
          <tbody>
            {totaisPorCategoria.categorias.map(c => (
              <tr key={c.categoria_id}>
                <td>{c.categoria_id}</td>
                <td>{formatarValor(c.total_receitas)}</td>
                <td>{formatarValor(c.total_despesas)}</td>
                <td>{formatarValor(c.saldo)}</td>
              </tr>
            ))}
            {/* Total geral de todas as categorias */}
            <tr style={{ fontWeight: "bold", backgroundColor: "#000000" }}>
              <td>Total Geral</td>
              <td>{formatarValor(calcularTotaisCategorias().totalReceitas)}</td>
              <td>{formatarValor(calcularTotaisCategorias().totalDespesas)}</td>
              <td>{formatarValor(calcularTotaisCategorias().saldo)}</td>
            </tr>
          </tbody>
        </table>
      ) : (
        <p>Carregando totais por categoria...</p>
      )}
    </div>
  );
};

export default Transacoes;