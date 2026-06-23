using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Terminal
    {

        public void Start()
        {
            Biblioteca biblioteca = new Biblioteca();

            while (true)
            {
                Menu();
                string opcao = Console.ReadLine();
                Console.WriteLine("================================\n");

                switch (opcao)
                {
                    case "1":
                        biblioteca.CadastrarLivro();
                        break;

                    case "2":
                        biblioteca.ListarLivros();
                        break;

                    case "3":
                        biblioteca.EmprestarLivro();
                        break;

                    case "4":
                        biblioteca.DevolverLivro();
                        break;

                    case "5":
                        biblioteca.BuscarLivro();
                        break;

                    case "6":
                        return
                            ;
                    default:
                        Console.WriteLine("Opção invalida, tente novamente!");
                        break;
                }
            }
        }
        public void Menu()
        {
            Console.WriteLine("========== BIBLIOTECA ==========");
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Listar Livros");
            Console.WriteLine("3 - Emprestar Livro");
            Console.WriteLine("4 - Devolver Livro");
            Console.WriteLine("5 - Buscar Livro");
            Console.WriteLine("6 - Sair");
            Console.Write("Escolha uma opção: ");
            
        }
    }
}
