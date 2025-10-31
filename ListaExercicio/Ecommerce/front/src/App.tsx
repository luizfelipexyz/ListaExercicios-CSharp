import React from 'react';
import ListarProdutos from './components/pages/produto/ListarProdutos';
import CadastrarProduto from './components/pages/produto/CadastrarProdutos';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Link } from 'react-router-dom';

function App() {
  return (
    <div>
      <BrowserRouter>
      <nav>
        <ul>
          <li><Link to="/">Listar Produtos</Link> </li>
          <li><Link to="/produto/cadastar">Cadastrar produtos</Link></li>
        </ul>
      </nav>
      <Routes>
        <Route path='/' element={<ListarProdutos/>} />
        <Route path='/produto/cadastar' element={<CadastrarProduto/>} />
      </Routes>
      <footer>
        Rodapé da aplicação
      </footer>
      </BrowserRouter>
    </div>
  );
}

export default App;
