using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBiblioteca.Enums; // Referencia a enumeração Cargos

namespace ProjetoBiblioteca.Abstract
{
    abstract class Funcionario : Pessoa
    {
        public Funcionario(string nome, string email, string telefone, string cpf, int matricula, Cargos cargo) : base(nome, email, telefone, cpf)
        {
            this.Matricula = matricula;
            this.cargo = cargo;
        }
        public int Matricula { get; private set; }
        public Cargos cargo { get; private set; }


    }
}
