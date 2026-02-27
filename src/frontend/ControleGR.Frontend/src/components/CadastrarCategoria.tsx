import React, { useState } from "react";
import { api } from "../api";
import type { Finalidade } from "../types/categoria";

interface Props {
  onSucesso?: () => void;
}

const CadastrarCategoria: React.FC<Props> = ({ onSucesso }) => {
  // Estados do formulário
  const [descricao, setDescricao] = useState("");
  const [finalidade, setFinalidade] = useState<Finalidade>(1);
  const [mensagem, setMensagem] = useState("");

  // Manipula o envio do formulário
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      // Envia a categoria para a API
      await api.post("/Categoria", { descricao, finalidade });
      
      // Limpa o formulário e exibe mensagem de sucesso
      setMensagem("Categoria cadastrada com sucesso!");
      setDescricao("");
      setFinalidade(1);
      onSucesso?.();
    } catch (err: any) {
      setMensagem(err.message || "Erro ao cadastrar categoria");
    }
  };

  return (
    <div style={{ display: "flex", flexDirection: "column", gap: 10, marginBottom: 20, width: "100%", maxWidth: 600, paddingBottom: 20, borderBottom: "2px solid #ccc" }}>
      <h2>Cadastrar Categoria</h2>
      <form onSubmit={handleSubmit} style={{ display: "flex", flexDirection: "column", gap: 10 }}>
        {/* Campo de descrição */}
        <input
          type="text"
          placeholder="Descrição"
          value={descricao}
          onChange={e => setDescricao(e.target.value)}
          required
          style={{ padding: 8 }}
        />

        {/* Seletor de finalidade (Despesa/Receita/Ambas) */}
        <select
          value={finalidade}
          onChange={e => setFinalidade(Number(e.target.value))}
          required
          style={{ padding: 8 }}
        >
          <option value={1}>Despesa</option>
          <option value={2}>Receita</option>
          <option value={3}>Ambas</option>
        </select>

        {/* Botão de envio */}
        <button type="submit" style={{ padding: "10px 20px" }}>Cadastrar</button>
      </form>

      {/* Mensagem de sucesso ou erro */}
      {mensagem && <p>{mensagem}</p>}
    </div>
  );
};

export default CadastrarCategoria;