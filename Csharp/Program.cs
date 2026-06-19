using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    internal class Program
    {
        static Dictionary<int, int> notas = new Dictionary<int, int>()
        {
            { 100, 0 },
            { 50, 0 },
            { 20, 0 },
            { 10, 0 }
        };
        static void Main(string[] args)
        {
            int opcao;

            do
            {
                opcao = Menu();

                switch (opcao)
                {
                    case 0:
                        MostrarNotas(notas, "NOTAS DISPONIVEIS");
                        break;

                    case 1:
                        AbastecerATM();
                        break;

                    case 2:
                        Sacar();
                        break;

                    case 9:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
            } while (opcao != 9);

            Console.ReadLine();
        }
        static int Menu()
        {
            Console.WriteLine("====================");
            Console.WriteLine("UNICSUL - Simulador de Saque de ATM – versão 2026 ");
            Console.WriteLine("Menu");
            Console.WriteLine("0 - Mostrar quantidade de notas disponiveis de cada valor");
            Console.WriteLine("1 - Abastecer ATM com qunatidade de notas para cada valor");
            Console.WriteLine("2 - Sacar dinheiro no ATM");
            Console.WriteLine("9 - Sair");

            int opcao = validarInt("Escolha operação: ");
            Console.WriteLine("====================");

            return opcao;
        }
        static void MostrarNotas(Dictionary<int, int> dic, string msg)
        {
            Console.WriteLine(msg);
            Console.Write("");

            foreach (var item in dic)
            {
                Console.WriteLine($"Nota: {item.Key} | Quantidade {item.Value}");
            }
        }

        static void AbastecerATM()
        {
            int[] valores = { 10, 20, 50, 100 };

            Console.WriteLine("ABASTECER ATM");
            Console.WriteLine("Digite a quantidade de notas que dejesa adicionar (digite 0 caso não queira adicionar nehuma)");
            Console.Write("");

            foreach (int valor in valores)
            {
                
                int qtdNotas = validarInt($"Notas de R${valor}: ");

                notas[valor] += qtdNotas;
            }
        }

        static void Sacar()
        {
            Console.WriteLine("SAQUE");
            Console.Write("");
            int valorSaque = validarInt("Digite o valor do saque: ");

            Dictionary<int, int> notasUtilizadas = new Dictionary<int, int>()
        {
            { 100, 0 },
            { 50, 0 },
            { 20, 0 },
            { 10, 0 }
        };

            Dictionary<int, int> notasTemp = new Dictionary<int, int>(notas);

            int[] valores = { 100, 50, 20, 10 };

            foreach (int valor in valores)
            {
                while (valorSaque >= valor && notasTemp[valor] > 0)
                {
                    valorSaque -= valor;

                    notasTemp[valor] --;
                    notasUtilizadas[valor] ++;

                    
                }

            }
            if (valorSaque == 0)
                    {
                        notas = notasTemp;

                        Console.WriteLine("Saque realizado com sucesso!");
                        MostrarNotas(notasUtilizadas, "NOTAS UTILIZADAS");
                        Console.WriteLine("----------------------------");
                    } else
                    {
                        Console.WriteLine("Notas insuficientes ou combinação indisponivel");
                    }
           
        }
        static int validarInt(string msg)
        {
            int valor;

            Console.Write(msg);

            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Digite apenas números: ");
            }

            return valor;
        }
    }
}
