using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBiblioteca.Abstract
{
    abstract class Pessoa { // Classe não pode mais ser instaciada, apenas herdada
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Cpf { get; private set; }

        public Pessoa(string nome, string email, string telefone, string cpf)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Cpf = cpf;
        }
    }
}
