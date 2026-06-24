using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Biblioteca
{
    public class Terminal
    {

        public void Start()
        {
            Biblioteca biblioteca = new Biblioteca();
            DataService dataService = new DataService();

            dataService.CarregarLivros();
            dataService.CarregarUsuarios();

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
                        biblioteca.CadasatrarUsuario();
                        break;

                    case "3":
                        biblioteca.ListarLivros();
                        break;

                    case "4":
                        biblioteca.ListarUsuarios();
                        break;

                    case "5":
                        biblioteca.EmprestarLivro();
                        break;

                    case "6":
                        biblioteca.DevolverLivro();
                        break;

                    case "7":
                        biblioteca.BuscarLivro();
                        break;

                    case "8":
                        return
                            ;
                    default:
                        Console.WriteLine("Opção invalida, tente novamente!");
                        break;
                }
            }
        }
        private void Menu()
        {
            Console.WriteLine("========== BIBLIOTECA ==========");
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Cadastrar Usuario");
            Console.WriteLine("3 - Listar Livros");
            Console.WriteLine("4 - Listar Usuarios");
            Console.WriteLine("5 - Emprestar Livro");
            Console.WriteLine("6 - Devolver Livro");
            Console.WriteLine("7 - Buscar Livro");
            Console.WriteLine("8 - Sair");
            Console.Write("Escolha uma opção: ");
            
        }
    }
}
