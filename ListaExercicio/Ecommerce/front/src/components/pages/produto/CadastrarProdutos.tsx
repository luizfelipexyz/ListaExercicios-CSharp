
import React, { useState } from 'react';
import Produto from '../../../models/Produto';

function CadastrarProduto() {

    const [nome,setNome] = useState("");
    const [descricao,setDescricao] = useState("");
    const [quantidade,setQuantidade] = useState(0);
    const [preco,setPreco] = useState(0);

    function enviarProduto(event: any){
        event.preventDefault(); //evita o recarregamento da pagina
    }
    function escreverNome(event : any){
        setNome(event.target.value)
    }
    async function submeterProdutoAPI(){

        try {
            const produto : Produto = {
                nome: nome,
                descricao: descricao,
                preco: preco,
                quantidade: quantidade
            }
            const resposta = await fetch("http://localhost:5087/api/produto/cadastrar", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(produto)
            });
            if(!resposta.ok) {
                throw new Error("Erro na requisição: " + resposta.statusText);
            }
            console.log(await resposta.json());
        } catch (error) {
            console.error("Erro no cadastro do produto: "+error);
        }
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
                    <input type="text" onChange={(e : any)=>{
                        setDescricao(e.target.value);
                    }}/>
                </div>
                <div>
                    <label>Preço</label>
                    <input type="text" onChange={(e : any)=>{
                        setPreco(Number(e.target.value));
                    }}/>
                </div>
                <div>
                    <button type="submit">Cadastrar</button>
                </div>
            </form>
        </div>
    );
}

export default CadastrarProduto;