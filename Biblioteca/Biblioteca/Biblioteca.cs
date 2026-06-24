using System.IO;
using System.Text.Json;

namespace Biblioteca
{
    public class Biblioteca
    {
        public static List<Livro> livros = new List<Livro>();
        public static List<Usuario> usuarios = new List<Usuario>();
        DataService dataService = new DataService();

        public void CadastrarLivro()
        {
            Console.WriteLine("------- CADASTRAR LIVRO --------");
            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            int id = 1 + livros.Count;

            livros.Add(new Livro(id, titulo, autor, null));
            dataService.SalvarLivros();
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
                                string status = livro.Disponivel ? "Sim" : "Não";
                                Console.WriteLine($"Id: {livro.Id} | Livro: {livro.Titulo} | Autor: {livro.Autor} | Disponivel: {status} | Usuario: {(livro.UsuarioEmprestimo != null ? livro.UsuarioEmprestimo.Nome : "Nenhum")}");
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
                bool livroEncontrado = false;

                foreach (var livro in livros)
                {
                    if (livro.Titulo == livroEmprestimo)
                    {
                        livroEncontrado = true;
                        if (livro.Disponivel == true)
                        {
                            Console.Write("Emprestar para: ");
                            string usuarioEmp = Console.ReadLine();
                            bool usarioEncontrado = false;

                            foreach(var usuario in usuarios)
                            {
                                if(usuario.Nome == usuarioEmp)
                                {
                                    usarioEncontrado = true;
                                    livro.Emprestar();
                                    livro.UsuarioEmprestimo = usuario;
                                    dataService.SalvarLivros();
                                    Console.WriteLine($"\nEmprestimo realizado com sucesso! (Livro: {livroEmprestimo} Para: {usuarioEmp})");
                                    break;
                                }

                            }

                            if(!usarioEncontrado)
                            {
                                Console.WriteLine("\nUsuário não encontrado, tente novamente");
                            }
               
                        }
                        else
                        {
                            Console.WriteLine($"\nO livro {livroEmprestimo} ja esta emprestado para outra pessoa");
                           
                        }

                        break;
                    }
                }

                if (!livroEncontrado)
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
                        livro.Devolver();
                        dataService.SalvarLivros();
                        livro.UsuarioEmprestimo = null;
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
                Console.Write("Digite o nome ou o Id do livro: ");
                string busca = Console.ReadLine();
                bool encontrou = false;

                Console.WriteLine($"BUSCA: {busca}");
                foreach (var livro in livros)
                {
                    if (livro.Titulo.ToLower().Contains(busca.ToLower()) || livro.Id.ToString().Contains(busca.ToLower()))
                    {
                        encontrou = true;
                        string status = livro.Disponivel ? "Sim" : "Não";
                        Console.WriteLine($"\nId: {livro.Id} | Livro: {livro.Titulo} | Autor: {livro.Autor} | Disponivel: {status}");
                    }
                }

                if (!encontrou)
                {
                    Console.WriteLine("\nLivro não encontrado, tente novamente!");
                }

                Console.WriteLine("--------------------------------\n");
            }
        }

        public void CadasatrarUsuario()
        {
            Console.WriteLine("------- CADASTRAR USUARIO--------");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            int id = 1 + usuarios.Count;

            usuarios.Add(new Usuario(id,nome));
            dataService.SalvarUsuarios();
            Console.WriteLine("\nUsuario cadastrado com sucesso!");
            Console.WriteLine("--------------------------------\n");
        }

        public void ListarUsuarios()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("------- LISTA DE USUARIOS --------");
                Console.WriteLine("Nenhum Usuario cadastrado!");

            }
            else
            {
                Console.WriteLine("------- LISTA DE USUARIOS --------");
                foreach (var usuario in usuarios)
                {
                    
                    Console.WriteLine($"Id: {usuario.Id} | Usuario: {usuario.Nome}");
                }
            }
            Console.WriteLine("--------------------------------\n");

        }

    }
}
