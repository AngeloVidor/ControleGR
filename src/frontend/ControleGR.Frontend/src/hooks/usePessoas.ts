import { useState, useEffect } from "react";
import { api } from "../api";
import type { Pessoa } from "../types/pessoa";

export const usePessoas = () => {
  const [pessoas, setPessoas] = useState<Pessoa[]>([]);
  const [editando, setEditando] = useState<Pessoa | null>(null);

  const fetchPessoas = async () => {
    try {
      const res = await api.get<Pessoa[]>("/Pessoas/pessoas");
      setPessoas(res.data);
    } catch (err) {
      console.error("Erro ao buscar pessoas:", err);
    }
  };

  useEffect(() => {
    fetchPessoas();
  }, []);

  const cadastrarPessoa = async (pessoa: Omit<Pessoa, "id">) => {
    try {
      const res = await api.post<Pessoa>("/Pessoas", pessoa);
      setPessoas(prev => [...prev, res.data]); 
      return res.data;
    } catch (err: any) {
      throw new Error(err?.response?.data?.message || "Erro ao cadastrar pessoa");
    }
  };

  const handleDelete = async (id: string) => {
    if (!window.confirm("Tem certeza que quer deletar?")) return;
    try {
      await api.delete(`/Pessoas/${id}`);
      setPessoas(prev => prev.filter(p => p.id !== id));
    } catch (err) {
      console.error("Erro ao deletar pessoa:", err);
    }
  };

  const handleUpdate = async (pessoa: Pessoa) => {
    try {
      await api.put(`/Pessoas/${pessoa.id}`, {
        nome: pessoa.nome,
        idade: pessoa.idade,
      });
      setEditando(null);
      fetchPessoas();
    } catch (err) {
      console.error("Erro ao atualizar pessoa:", err);
    }
  };

  return {
    pessoas,
    editando,
    setEditando,
    fetchPessoas,
    cadastrarPessoa,
    handleDelete,
    handleUpdate,
  };
};