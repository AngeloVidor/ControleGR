import React, { useState } from "react";
import { api } from "../api";
import type { TipoTransacao } from "../types/transacao";
import { usePessoas } from "../hooks/usePessoas";
import { useCategorias } from "../hooks/useCategorias";

interface Props {
  onSucesso?: () => void;
}

const CadastrarTransacao: React.FC<Props> = ({ onSucesso }) => {
  // Obtém lista de pessoas e categorias
  const { pessoas } = usePessoas();
  const { categorias } = useCategorias();

  // Estados do formulário
  const [descricao, setDescricao] = useState("");
  const [valor, setValor] = useState("");
  const [tipoTransacao, setTipoTransacao] = useState<TipoTransacao>(1);
  const [categoriaId, setCategoriaId] = useState("");
  const [pessoaId, setPessoaId] = useState("");
  const [mensagem, setMensagem] = useState("");
  const [erro, setErro] = useState("");

  // Filtra categorias por tipo de transação
  // tipoTransacao: 1 = Despesa, 2 = Receita
  // finalidade: 1 = Despesa, 2 = Receita, 3 = Ambas
  const categoriasFiltradasPorTipo = categorias.filter(
    cat => cat.finalidade === tipoTransacao || cat.finalidade === 3
  );

  // Manipula o envio do formulário
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setMensagem("");
    setErro("");

    try {
      // Envia a transação para a API
      const response = await api.post<{
        id?: string;
        errorMessage?: string;
        success: boolean;
      }>("/Transacao", {
        descricao,
        valor: Number(valor),
        tipoTransacao,
        categoriaId,
        pessoaId,
      });

      // Verifica se houve erro na resposta
      if (!response.data.success && response.data.errorMessage) {
        setErro(response.data.errorMessage);
        return;
      }

      // Limpa o formulário e exibe mensagem de sucesso
      setMensagem("Transação cadastrada com sucesso!");
      setDescricao("");
      setValor("");
      setTipoTransacao(1);
      setCategoriaId("");
      setPessoaId("");
      onSucesso?.();
    } catch (err: any) {
      setErro(err.response?.data?.errorMessage || err.message || "Erro ao cadastrar transação");
    }
  };

  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        gap: 10,
        marginBottom: 20,
        width: "100%",
        maxWidth: 600,
        paddingBottom: 20,
        borderBottom: "2px solid #ccc",
      }}
    >
      <h2>Cadastrar Transação</h2>
      <form onSubmit={handleSubmit} style={{ display: "flex", flexDirection: "column", gap: 10 }}>
        {/* Campo de descrição */}
        <input
          type="text"
          placeholder="Descrição"
          value={descricao}
          onChange={(e) => setDescricao(e.target.value)}
          required
          style={{ padding: 8 }}
        />

        {/* Campo de valor */}
        <input
          type="number"
          placeholder="Valor"
          value={valor}
          onChange={(e) => setValor(e.target.value)}
          required
          step="0.01"
          style={{ padding: 8 }}
        />

        {/* Seletor de tipo de transação (Despesa/Receita) */}
        <select
          value={tipoTransacao}
          onChange={(e) => {
            setTipoTransacao(Number(e.target.value) as TipoTransacao);
            setCategoriaId(""); // Limpa categoria ao mudar tipo
          }}
          required
          style={{ padding: 8 }}
        >
          <option value={1}>Despesa</option>
          <option value={2}>Receita</option>
        </select>

        {/* Seletor de categoria filtrada por tipo de transação */}
        <select
          value={categoriaId}
          onChange={(e) => setCategoriaId(e.target.value)}
          required
          style={{ padding: 8 }}
        >
          <option value="">Selecione uma categoria</option>
          {categoriasFiltradasPorTipo.length > 0 ? (
            categoriasFiltradasPorTipo.map((categoria) => (
              <option key={categoria.id} value={categoria.id}>
                {categoria.descricao}
              </option>
            ))
          ) : (
            <option disabled>Nenhuma categoria disponível</option>
          )}
        </select>

        {/* Seletor de pessoa */}
        <select
          value={pessoaId}
          onChange={(e) => setPessoaId(e.target.value)}
          required
          style={{ padding: 8 }}
        >
          <option value="">Selecione uma pessoa</option>
          {pessoas.length > 0 ? (
            pessoas.map((pessoa) => (
              <option key={pessoa.id} value={pessoa.id}>
                {pessoa.nome}
              </option>
            ))
          ) : (
            <option disabled>Nenhuma pessoa cadastrada</option>
          )}
        </select>

        {/* Botão de envio */}
        <button type="submit" style={{ padding: "10px 20px" }}>
          Cadastrar
        </button>
      </form>

      {/* Mensagens de sucesso e erro */}
      {mensagem && <p style={{ color: "green" }}>{mensagem}</p>}
      {erro && <p style={{ color: "red" }}>{erro}</p>}
    </div>
  );
};

export default CadastrarTransacao;