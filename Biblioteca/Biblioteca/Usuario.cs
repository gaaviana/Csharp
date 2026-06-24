using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Usuario
    {
        public string Nome;
        public int Id;
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
