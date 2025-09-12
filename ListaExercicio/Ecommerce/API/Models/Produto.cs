namespace API.Models;

public class Produto
{
    // Caracteristicas EM JAVA
    // id, nome, preco ,quantidade
    //private string id;
    //private string nome;
    //private double preco;
    //private int quantidade;
    public string Id { get; set; }
    public string? Nome { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }

    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    // getter e setter em JAVA

    //public string getNome()
    //{
    //    return "Nome: " + nome;
    //}
    //public void setNome(string nome)
    //{
    //   this.nome = nome + " " + DateTime.Now;
    //}

    // getter e setter C#
   // public string Nome { get; set; }
}