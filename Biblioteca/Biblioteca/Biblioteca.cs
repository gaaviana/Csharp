using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Biblioteca
    {
        static List<Livro> livros = new List<Livro>();

        public void CadastrarLivro()
        {
            Console.WriteLine("------- CADASTRAR LIVRO --------");
            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            bool disponivel = true;

            livros.Add(new Livro(titulo, autor, disponivel));
            Console.WriteLine("\nLivro cadastrado com sucesso!");
            Console.WriteLine("--------------------------------\n");
        }

        public void ListarLivros()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("------- LISTA DE LIVROS --------");
                Console.WriteLine("Nenhum livro cadastrado!");
               
            }
            else
            {
                Console.WriteLine("------- LISTA DE LIVROS --------");
                foreach (var livro in livros)
                            {
                                Console.WriteLine($"Livro: {livro.Titulo} | Autor: {livro.Autor} | Disponivel: {livro.Disponivel}");
                            }
            }
                Console.WriteLine("--------------------------------\n");
            
        }

        public void EmprestarLivro()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("------- EMPRESTAR LIVRO --------");
                Console.WriteLine("Nenhum livro cadastrado!");
                
            }
            else
            {
                Console.WriteLine("------- EMPRESTAR LIVRO --------");
                Console.Write("Nome do livro: ");
                string livroEmprestimo = Console.ReadLine();
                bool encontrou = false;

                foreach (var livro in livros)
                {
                    if (livro.Titulo == livroEmprestimo)
                    {
                        encontrou = true;
                        if (livro.Disponivel == true)
                        {
                            livro.Disponivel = false;
                            Console.WriteLine($"\nEmprestimo realizado com sucesso! ({livroEmprestimo})");
                           
                        }
                        else
                        {
                            Console.WriteLine($"\nO livro {livroEmprestimo} ja esta emprestado para outra pessoa");
                           
                        }

                        break;
                    }
                }

                if (!encontrou)
                {
                    Console.WriteLine("\nLivro não encontrado, tente novamente!");
                }
                
            }
                    Console.WriteLine("--------------------------------\n");
        }

        public void DevolverLivro()
        {
            Console.WriteLine("------- DEVOLVER LIVRO --------");
            Console.Write("Nome do livro: ");
            string livroDevolvido = Console.ReadLine();
            bool encontrou = false;

            foreach (var livro in livros)
            {
                if (livro.Titulo == livroDevolvido)
                {
                    encontrou = true;
                    if (livro.Disponivel == false)
                    {
                        livro.Disponivel = true;
                        Console.WriteLine($"\nLivro devolvido com sucesso! ({livroDevolvido})");
                       
                    }
                    else
                    {
                        Console.WriteLine($"\nEsse livro não esta emprestado, tente novamente!");
                      
                    }

                    break;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("\nLivro não encontrado, tente novamente!");
            }
                Console.WriteLine("--------------------------------\n");
        }

        public void BuscarLivro()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("------- BUSCAR LIVROS --------");
                Console.WriteLine("Nenhum livro cadastrado!\n");
            }
            else
            {
                Console.WriteLine("------- BUSCAR LIVROS --------");
                Console.Write("Nome do livro: ");
                string busca = Console.ReadLine();
                bool encontrou = false;

                Console.WriteLine("BUSCA: ");
                foreach (var livro in livros)
                {
                    if (livro.Titulo.ToLower().Contains(busca.ToLower()))
                    {
                        encontrou = true;
                        Console.WriteLine($"\nLivro: {livro.Titulo} | Autor: {livro.Autor} | Disponivel: {livro.Disponivel}");
                    }
                }

                if (!encontrou)
                {
                    Console.WriteLine("\nLivro não encontrado, tente novamente!");
                }

                Console.WriteLine("--------------------------------\n");
            }
        }
    }
}
