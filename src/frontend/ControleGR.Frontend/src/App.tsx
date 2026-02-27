import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Header from "./components/Header";
import Home from "./pages/Home";
import Pessoas from "./pages/Pessoas";
import Categorias from "./pages/Categorias";
import Transacoes from "./pages/Transacoes";

const App: React.FC = () => {
  return (
    <Router>
      <div style={{ display: "flex", flexDirection: "column", minHeight: "100vh" }}>
        <Header />
        <main style={{ padding: 20, flex: 1, maxWidth: "1332px", margin: "0 auto", width: "100%" }}>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/pessoas" element={<Pessoas />} />
            <Route path="/categorias" element={<Categorias />} />
            <Route path="/transacoes" element={<Transacoes />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
};

export default App;