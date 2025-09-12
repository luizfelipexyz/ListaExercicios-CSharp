using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>;
{
    new Produto { Nome = "Notebook", Quantidade = 2, Preco = 3500.00 },
    new Produto { Nome = "Mouse", Quantidade = 10, Preco = 150.50 },
    new Produto { Nome = "Teclado", Quantidade = 5, Preco = 200.00 },
    new Produto { Nome = "Monitor", Quantidade = 3, Preco = 1200.00 },
    new Produto { Nome = "Impressora", Quantidade = 1, Preco = 800.00 }
};

// GET: Recupera dados de um servidor sem modificar o recurso
// POST: Envia dados ao servidor para criar um novo recurso;
// PUT: Atualiza completamente um recurso existente no servidor
// PATCH: Atualiza parcialmente um recurso existente;
// DELETE: Remove um recurso do servidor

app.MapGet("/", () => "Página principal");
app.MapGet("/api/produto/listar", () =>
{
    if(produtos.Count>0)
         return Results.Ok(produtos);
    return Results.NoContent();
});

app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto)=>
{
    foreach(Produto produtoCadastrado in produtos){
        if(produtoCadastrado.Nome == produto.Nome){
            return Results.Conflict("Produto ja cadastrado!");
        }
    }
    produtos.Add(produto);   
    return Results.Created("", produto); 
});

app.MapGet("/api/produto/buscar/{nome}", ([FromRoute] string nome)=>{
    // string nome = "Monitor";
    // foreach (Produto produtoCadastrado in produtos){
    //     if (produtoCadastrado.Nome == nome){
    //         return Results.Ok(produtoCadastrado);
    //     }
    // }
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Nome == nome);
    if(produtoEncontrado == null){
        return Results.NotFound("Produto não encontrado");
    }
    return Results.Ok(produtoEncontrado);
});

app.Run();

// JAVA
//Produto produto = new Produto();
//produto.setNome("Bolacha");
//Console.WriteLine(produto.getNome());

// C#
//Produto produto = new Produto();
//produto.Nome = "Bolacha";
//Console.WriteLine(produto.Nome);

