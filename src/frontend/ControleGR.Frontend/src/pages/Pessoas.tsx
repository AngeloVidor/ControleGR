import React from "react";
import { usePessoas } from "../hooks/usePessoas";
import CadastrarPessoa from "../components/CadastrarPessoa";

const Pessoas: React.FC = () => {
  // Obtém lista de pessoas, estado de edição e funções de manipulação
  const { pessoas, editando, setEditando, fetchPessoas, handleDelete, handleUpdate } = usePessoas();

  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        padding: 20,
        minHeight: "100vh",
      }}
    >
      <h1>Pessoas</h1>

      {/* Componente para cadastrar nova pessoa */}
      <div
        style={{
          width: "100%",
          maxWidth: 800,
          paddingBottom: 20,
          borderBottom: "2px solid #ccc",
        }}
      >
        <CadastrarPessoa onSucesso={fetchPessoas} />
      </div>

      {/* Lista de pessoas */}
      <h2 style={{ width: "100%", maxWidth: 800, paddingTop: 20 }}>Lista de Pessoas</h2>
      <table
        border={1}
        cellPadding={5}
        style={{ marginTop: 10, width: "100%", maxWidth: 800 }}
      >
        <thead>
          <tr>
            <th>Nome</th>
            <th>Idade</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          {/* Mapeia cada pessoa em uma linha da tabela com opções de edição/deleção */}
          {pessoas.map(p => (
            <tr key={p.id!}>
              {/* Coluna de nome - edição inline se em modo edição */}
              <td>
                {editando?.id === p.id ? (
                  <input
                    type="text"
                    value={editando!.nome}
                    onChange={e =>
                      setEditando(prev => prev && { ...prev, nome: e.target.value })
                    }
                    style={{ padding: 4 }}
                  />
                ) : (
                  p.nome
                )}
              </td>

              {/* Coluna de idade - edição inline se em modo edição */}
              <td>
                {editando?.id === p.id ? (
                  <input
                    type="number"
                    value={editando!.idade}
                    onChange={e =>
                      setEditando(prev => prev && { ...prev, idade: Number(e.target.value) || 0 })
                    }
                    placeholder="Idade"
                    style={{ padding: 4 }}
                  />
                ) : (
                  p.idade
                )}
              </td>

              {/* Coluna de ações - botões mudam conforme o estado de edição */}
              <td>
                {editando?.id === p.id ? (
                  <>
                    <button onClick={() => editando && handleUpdate(editando)}>Salvar</button>
                    <button onClick={() => setEditando(null)}>Cancelar</button>
                  </>
                ) : (
                  <>
                    <button onClick={() => setEditando(p)}>Editar</button>
                    <button onClick={() => handleDelete(p.id!)}>Deletar</button>
                  </>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Pessoas;