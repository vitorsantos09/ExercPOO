using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBiblioteca.Abstract; // Referencia a classe abstrata Funcionario
using ProjetoBiblioteca.Enums; // Referencia a enumeração Cargos

namespace ProjetoBiblioteca.Class
{
    class Administrador : Funcionario
    {
        public Administrador(string nome, string email, string telefone, string cpf, int matricula) : base(nome, email, telefone, cpf, matricula, Cargos.Administrador)
        {

        }
    }
}