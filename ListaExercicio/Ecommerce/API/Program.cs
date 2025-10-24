using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Acesso total", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();


List<Produto> produtos = new List<Produto>
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

// Listar todos os produtos
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.Produtos.Count()>0)
         return Results.Ok(ctx.Produtos.ToList());
    return Results.BadRequest("Lista vazia");
});

// Cadastrar produto
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto, [FromServices] AppDataContext ctx)=>
{
    Produto? produtoEncontrado = ctx.Produtos.FirstOrDefault(x => x.Nome == produto.Nome);
    if (produtoEncontrado is not null)
    {
        return Results.Conflict("Produto já existente!");
    }
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto); 
});

// Buscar produto por nome
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    // string i = "Monitor";
    // foreach (Produto produtoCadastrado in produtos){
    //     if (produtoCadastrado.Nome == nome){
    //         return Results.Ok(produtoCadastrado);
    //     }
    // }
    Produto? produtoEncontrado = ctx.Produtos.Find(id); // find so funciona pra chave primaria
    if (produtoEncontrado == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    return Results.Ok(produtoEncontrado);
});

// Remover produto pelo nome
app.MapDelete("/api/produto/deletar/{nome}", ([FromRoute] string nome, [FromServices] AppDataContext ctx) =>
{
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Nome == nome);
    if (produtoEncontrado == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    produtos.Remove(produtoEncontrado);
    return Results.Ok("Produto excluido com sucesso!");
});

app.MapPatch("/api/produto/atualizar/{nome}", ([FromRoute] string nome, [FromBody] Produto produtoAtualizado, [FromServices] AppDataContext ctx) =>
{
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Nome == nome);
    if (produtoEncontrado == null)
    {
        return Results.NotFound("Produto não encontrado");
    }

    produtoEncontrado.Nome = produtoAtualizado.Nome;
    produtoEncontrado.Quantidade = produtoAtualizado.Quantidade;
    produtoEncontrado.Preco = produtoAtualizado.Preco;

    // Retorna resposta de sucesso
    return Results.Ok("Produto atualizado com sucesso!");
});
app.UseCors("Acesso total");

app.Run();

// JAVA
//Produto produto = new Produto();
//produto.setNome("Bolacha");
//Console.WriteLine(produto.getNome());

// C#
//Produto produto = new Produto();
//produto.Nome = "Bolacha";
//Console.WriteLine(produto.Nome);

