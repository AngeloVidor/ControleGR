import React, { useState } from "react";
import type { Pessoa as PessoaType } from "../types/pessoa";
import { usePessoas } from "../hooks/usePessoas";

const CadastrarPessoa: React.FC<{ onSucesso?: () => void }> = ({ onSucesso }) => {
  // Estado do formulário para nova pessoa
  const [pessoa, setPessoa] = useState<Omit<PessoaType, "id">>({ nome: "", idade: 0 });
  const [mensagem, setMensagem] = useState("");
  
  // Obtém função para cadastrar pessoa
  const { cadastrarPessoa } = usePessoas();

  // Manipula mudanças nos campos do formulário
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setPessoa(prev => ({
      ...prev,
      [name]: name === "idade" ? (value === "" ? 0 : Number(value)) : value,
    }));
  };

  // Manipula o envio do formulário
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      // Cadastra a pessoa via API
      await cadastrarPessoa(pessoa);
      
      // Limpa o formulário e exibe mensagem de sucesso
      setMensagem("Pessoa cadastrada com sucesso!");
      setPessoa({ nome: "", idade: 0 });
      onSucesso?.();
    } catch (error: any) {
      setMensagem(error.message);
    }
  };

  return (
    <div style={{ display: "flex", flexDirection: "column", gap: 10 }}>
      <h2>Cadastrar Pessoa</h2>
      <form onSubmit={handleSubmit} style={{ display: "flex", flexDirection: "column", gap: 10 }}>
        {/* Campo de nome */}
        <input
          type="text"
          name="nome"
          placeholder="Nome"
          value={pessoa.nome}
          onChange={handleChange}
          required
          style={{ padding: 8 }}
        />

        {/* Campo de idade */}
        <input
          type="number"
          name="idade"
          placeholder="Idade"
          value={pessoa.idade === 0 ? "" : pessoa.idade}
          onChange={handleChange}
          required
          style={{ padding: 8 }}
        />

        {/* Botão de envio */}
        <button type="submit" style={{ padding: "10px 20px" }}>Cadastrar</button>
      </form>

      {/* Mensagem de sucesso ou erro */}
      {mensagem && <p>{mensagem}</p>}
    </div>
  );
};

export default CadastrarPessoa;