using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBiblioteca.Abstract;

namespace ProjetoBiblioteca.Class
{
    class Usuario : Pessoa
    {
        public DateTime DataNasc { get; set; }

        public Usuario(string nome, string email, string telefone, string cpf, DateTime datanasc) : base(nome, email, telefone, cpf)
        {
            this.DataNasc = datanasc;
        }
    }
}