import React from "react";
import { Link } from "react-router-dom";

const Header: React.FC = () => {
  return (
    <header style={{ display: "flex", gap: 20, padding: 20, borderBottom: "2px solid #ccc" }}>
      <Link to="/">Home</Link>
      <Link to="/pessoas">Pessoas</Link>
      <Link to="/categorias">Categorias</Link>
      <Link to="/transacoes">Transações</Link>
    </header>
  );
};

export default Header;