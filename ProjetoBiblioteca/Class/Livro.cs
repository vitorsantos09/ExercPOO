using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBiblioteca.Enums;

namespace ProjetoBiblioteca.Class
{
    class Livro
    {
        public string? Nome { get; private set; }
        public ClassificacaoIndicativa Classificacao { get; set; } // Declara o enumerador como propriedade da classe Livro
        public GeneroLivro Genero { get; set; }

        public Livro(string nome, ClassificacaoIndicativa classificacao, GeneroLivro genero)
        {
            this.Nome = nome;
            this.Classificacao = classificacao;
            this.Genero = genero;
        }

    }
}