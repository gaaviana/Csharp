using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Livro
    {
        public string Titulo;
        public string Autor;
        public bool Disponivel;

        public Livro(string titulo, string autor, bool disponivel)
        {
            Titulo = titulo;
            Autor = autor;
            Disponivel = disponivel;
        }
    }
}
