
import React, { useState } from 'react';
import Produto from '../../../models/Produto';

function CadastrarProduto() {
    const [nome,setNome] = useState("");
    function enviarProduto(event: any){
        event.preventDefault(); //evita o recarregamento da pagina
    }
    function escreverNome(event : any){
        setNome(event.target.value)
    }
    async function submeterProdutoAPI(){
        const produto : Produto = {
            nome: nome,
            descricao: "Teste",
            preco: 1234,
            quantidade: 2
        }
        const resposta = await fetch("http://localhost:5087/api/produto/cadastrar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(produto)
        });
    }

           
    return (
        <div>
            <h1>Cadastrar Produto</h1>
            <form onSubmit={enviarProduto}>
                <div>
                    <label>Nome</label>
                    <input onChange={escreverNome} type="text" />
                </div>
                <div>
                    <label>Descrição</label>
                    <input type="text" />
                </div>
                <div>
                    <button type="submit">Cadastrar</button>
                </div>
            </form>
        </div>
    );
}

export default CadastrarProduto;