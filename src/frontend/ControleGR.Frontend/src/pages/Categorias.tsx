import React from "react";
import CadastrarCategoria from "../components/CadastrarCategoria";
import { useCategorias } from "../hooks/useCategorias";

// Função para converter o código de finalidade em label legível
const getFinalidadeLabel = (finalidade: number) => {
  switch (finalidade) {
    case 1: return "Despesa";
    case 2: return "Receita";
    case 3: return "Ambas";
    default: return finalidade;
  }
};

const Categorias: React.FC = () => {
  // Obtém a lista de categorias e função para atualizar a lista
  const { categorias, fetchCategorias } = useCategorias();

  return (
    <div style={{ display: "flex", flexDirection: "column", alignItems: "center", padding: 20, minHeight: "100vh" }}>
      <h1>Categorias</h1>
      
      {/* Componente para cadastrar nova categoria */}
      <CadastrarCategoria onSucesso={fetchCategorias} />

      {/* Lista de categorias */}
      <h2 style={{ width: "100%", maxWidth: 600, paddingTop: 20 }}>Lista de Categorias</h2>
      <table border={1} cellPadding={5} style={{ marginTop: 10, width: "100%", maxWidth: 600 }}>
        <thead>
          <tr>
            <th>Descrição</th>
            <th>Finalidade</th>
          </tr>
        </thead>
        <tbody>
          {/* Mapeia todas as categorias em linhas da tabela */}
          {categorias.map(cat => (
            <tr key={cat.id}>
              <td>{cat.descricao}</td>
              <td>{getFinalidadeLabel(cat.finalidade)}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Categorias;