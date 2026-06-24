using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
