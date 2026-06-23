namespace gerenciador;

using System.IO;

public class Program
{
    public static void Main()
    {
        // estrutura
        string path = @"C:\Users\Gaavi\OneDrive\Desktop\Csharp\gerenciador_de_lista_de_compras\";
        string fileName = "lista_de_compras.txt";
        string filePath = path + fileName;

        List<string> listaCompras  = new List<string>();

        // logica

        if (File.Exists(filePath))
        {
            listaCompras.AddRange(File.ReadAllLines(filePath));
        }

        while (true)
        {
            Console.WriteLine("\n== Lista de Compras==");
            Console.WriteLine("1. Adicionar item");
            Console.WriteLine("2. Remover item");
            Console.WriteLine("3. Exibir Lista");
            // limpar lista: desafio mega bolado uhuuu
            Console.WriteLine("4. Exportar lista");
            Console.Write("Escolha um número para continuar: ");

            string opcao = Console.ReadLine();

            switch(opcao)
            {
                case "1":
                    Console.Write("Digite o nome do item a adicionar: ");
                    string itemAdicionado = Console.ReadLine();

                    if (!string.IsNullOrEmpty(itemAdicionado))
                    {
                        listaCompras.Add(itemAdicionado);
                        Console.WriteLine($"Item '{itemAdicionado}' adicionado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("O item não pode ser vazio!");
                    }

                    break;

                case "2":
                    Console.Write("Digite o nome do item para remover: ");
                    string itemRemovido = Console.ReadLine();

                    if (listaCompras.Remove(itemRemovido)) // se a condição for verdadeira, remova o item
                    {
                        Console.WriteLine($"Item '{itemRemovido}' com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"Item {itemRemovido} não encontrado");
                    }

                    break;

                case "3":
                    Console.WriteLine("\nItens na sua lista de compras: ");

                    if (listaCompras.Count == 0)
                    {
                        Console.WriteLine("Sua lista esta vazia!");
                    }
                    else
                    {
                        for (int i = 0; i < listaCompras.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {listaCompras[i]}");
                        }
                    }

                    break;

                case "4":
                    File.WriteAllLines(filePath, listaCompras);
                    Console.WriteLine("Lista salva com sucesso! Saindo...");
                    return;

                default:
                    Console.WriteLine("Opção invélida. Tente novamente");

                    break;
            }
        }
    }
}
