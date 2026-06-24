using System.IO;
using System.Text.Json;

namespace Biblioteca
{
    public class DataService
    {
        public void SalvarLivros()
        {
           
            string json = JsonSerializer.Serialize(
                Biblioteca.livros, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText("livros.json", json);
        }
        public void SalvarUsuarios()
        {
           
            string json = JsonSerializer.Serialize(
                Biblioteca.usuarios, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText("usuarios.json", json);
        }
        public void CarregarLivros()
        {
          
            if (File.Exists("livros.json"))
            {
                string json = File.ReadAllText("livros.json");

                Biblioteca.livros = JsonSerializer.Deserialize<List<Livro>>(json);
            }
        }
        public void CarregarUsuarios()
        {
           
            if (File.Exists("usuarios.json"))
            {
                string json = File.ReadAllText("usuarios.json");

                Biblioteca.usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
            }
        }
    }
}
