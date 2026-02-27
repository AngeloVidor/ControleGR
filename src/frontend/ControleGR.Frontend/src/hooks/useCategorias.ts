import { useState, useEffect } from "react";
import { api } from "../api";
import type { Categoria } from "../types/categoria";

export const useCategorias = () => {
  const [categorias, setCategorias] = useState<Categoria[]>([]);

  const fetchCategorias = async () => {
    try {
      const res = await api.get<Categoria[]>("/Categoria/categorias");
      setCategorias(res.data);
    } catch (err) {
      console.error("Erro ao buscar categorias:", err);
    }
  };

  useEffect(() => {
    fetchCategorias();
  }, []);

  return { categorias, fetchCategorias };
};