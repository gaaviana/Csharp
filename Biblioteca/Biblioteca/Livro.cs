using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Disponivel { get; set; }
        public Usuario UsuarioEmprestimo { get; set; }

        public Livro()
        {
        }
        public Livro(int id, string titulo, string autor, Usuario usuarioEmprestimo)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Disponivel = true;
            UsuarioEmprestimo = usuarioEmprestimo;
        }

        public void Emprestar()
        {
            Disponivel = false;
        }

        public void Devolver()
        {
            Disponivel = true;
        }
    }
}
