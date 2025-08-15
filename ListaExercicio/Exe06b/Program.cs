//1 - Criar um vetor para receber os valores aleatórios
//2 - Percorrer o vetor com um laço de repetição
//3 - Preencher cada posição com um valor aleatório
//4 - Imprimir o vetor com valores aleatórios

int tamanho = 100;
int[] vetor = new int[tamanho];

Random random = new Random();
for (int i = 0; i < vetor.Length; i++)
{
    vetor[i] = random.Next(1000);
}

for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}

Array.Sort(vetor);

Console.WriteLine("\n");
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i]+ " ");
}