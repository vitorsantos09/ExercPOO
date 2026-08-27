class Emprestimo // Recebe referencias dos objetos User e Livro e registra qual usuario e qual livro foi emprestado
{
    public DateTime DataEmprestimo{get;private set;} // somente leitura externa
    public DateTime? DataDevolucao{get;private set;} // Por ser criado apenas se o usuario emprestar um livro, a data devolução precisa poder exibir um valor null
    
    //public Usuario User; campo publico
    public Usuario User{get; private set;} // Propriedade armazena uma referência para um objeto
    
    public Livro Book{get; private set;}
    public Emprestimo(Usuario user, Livro book)
    {
        this.User = user;
        this.Book = book;
        DataEmprestimo = DateTime.Now;
    }
    public string RegistrarDevolucao()
    {
        DataDevolucao = DateTime.Now;
        return "devolvido com sucesso"; 
    }
}