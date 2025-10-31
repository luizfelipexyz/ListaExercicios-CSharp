import { useEffect, useState } from "react";
import Produto from "../../../models/Produto";
import axios from "axios";
// Componente
// - Composto por HTML, CSS e JS ou TS

// Regras para ser um componente
// - Precisa ser uma função
// - Precisa retornar apenas um elemento HTML pai
// - Exportar o componente


function ListarProdutos(){

    // Estados -  Variáveis
    const [produtos, setProdutos] = useState<Produto[]>([]) //get e set basicamente

    useEffect(()=>{
        console.log("O componente foi carregado!")
        buscarProdutosAPI();
    }, [])
    
    async function buscarProdutosAPI(){

        try {

            const resposta = await axios.get("http://localhost:5087/api/produto/listar");
            setProdutos(resposta.data);

        } catch (error) {
            console.log("Erro na requisição: "+error)
        }
}

// o return é a parte visual no componente
// não pode ter dois elementos PAI no return ( a nao ser q vc crie uma DIV)
    return(
        <div id="listar_produtos">
        <h1>Listar Produtos</h1>
        <table>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Nome</th>
                    <th>Descrição</th>
                    <th>Quantidade</th>
                    <th>Preço</th>
                    <th>Criado em</th>
                </tr>
            </thead>
            <tbody>
                {produtos.map((produto)=> // map e basicamente um for each q percorre cada item
                <tr>
                    <td>{produto.id}</td>
                    <td>{produto.nome}</td>
                    <td>{produto.descricao}</td>
                    <td>{produto.quantidade}</td>
                    <td>{produto.preco}</td>
                    <td>{produto.criadoEm}</td>
                </tr>
            )}
            </tbody>
        </table>
        <ul>
            
        </ul>
        </div>
        
    );
}


export default ListarProdutos; // deixou a funçao publica pra usar em outro lugar