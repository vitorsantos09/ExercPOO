using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBiblioteca.Enums; // Referencia a enumeração StatusSolicita

namespace ProjetoBiblioteca.Class
{
    class SolicitaEmprestimo
    {
        public Usuario User { get; private set; }
        public Livro Book { get; private set; }
        public DateTime DataSolicitacao { get; private set; }
        public StatusSolicita Status { get; private set; }
        public SolicitaEmprestimo(Usuario user, Livro book)
        {
            User = user;
            Book = book;
            DataSolicitacao = DateTime.Now;
            Status = StatusSolicita.Pendente; // Inicializa o status como Pendente
        }

        public void Aprovar()
        {
            Status = StatusSolicita.Aprovada;
        }

        public void Reprovar()
        {
            Status = StatusSolicita.Recusada;
        }
    }
}
