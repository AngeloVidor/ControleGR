import { useState, useEffect } from "react";
import { api } from "../api";
import type { Transacao, Totais, TotaisPorCategoria } from "../types/transacao";

export const useTransacoes = () => {
  const [transacoes, setTransacoes] = useState<Transacao[]>([]);
  const [totais, setTotais] = useState<Totais | null>(null);
  const [totaisPorCategoria, setTotaisPorCategoria] = useState<TotaisPorCategoria | null>(null);

  const fetchTransacoes = async () => {
    try {
      const res = await api.get<Transacao[]>("/Transacao/transacoes");
      setTransacoes(res.data);
    } catch (err) {
      console.error("Erro ao buscar transações:", err);
    }
  };

  const fetchTotais = async () => {
    try {
      const res = await api.get<Totais>("/Transacao/totais");
      setTotais(res.data);
    } catch (err) {
      console.error("Erro ao buscar totais:", err);
    }
  };

  const fetchTotaisPorCategoria = async () => {
    try {
      const res = await api.get<TotaisPorCategoria>("/Transacao/totais-por-categoria");
      setTotaisPorCategoria(res.data);
    } catch (err) {
      console.error("Erro ao buscar totais por categoria:", err);
    }
  };

  const refetchAll = () => {
    fetchTransacoes();
    fetchTotais();
    fetchTotaisPorCategoria();
  };

  useEffect(() => {
    refetchAll();
  }, []);

  return { transacoes, totais, totaisPorCategoria, fetchTransacoes, fetchTotais, fetchTotaisPorCategoria, refetchAll };
};