class Sistema
{
    List<Pessoa> listPessoas = new(); //List cresce e diminui dinamicamente.
    List<Livro> listLivros = new();
    List<Emprestimo> listEmprestimos = new();
    
    public void CadastrarUsuario(string nome, string email, string telefone, string cpf, int idade)
    {
            Usuario usuario = new(nome,email,telefone,cpf,idade);
            listPessoas.Add(usuario);
    }
    public void CadastrarBibliotecario(string nome, string email, string telefone, string cpf, string matricula)
    {
            Bibliotecario bibliotecario = new(nome,email,telefone,cpf,matricula);
            listPessoas.Add(bibliotecario);
    }
    public void CadastrarAdministrador(string nome, string email, string telefone, string cpf, string matriculaAdmin)
    {
            Administrador admin = new(nome,email,telefone,cpf,matriculaAdmin);
            listPessoas.Add(admin);
    }

    public void CadastrarLivro(string nome, ClassificacaoIndicativa classificacao, GeneroLivro generoLivro)
    {
        Livro livro = new(nome,classificacao,generoLivro);
        listLivros.Add(livro);
    }

    public Livro? BuscarLivro(string buscaLivro) //Esse método pode retornar um objeto Livro ou null.
    {
        foreach(Livro livro in listLivros)//Para cada Livro chamado livro dentro de listLivros, compare o buscalivro com o nome do livro, se achar, retorne o objeto.
        //foreach varre todas os objetos da lista
        {
            if(buscaLivro == livro.Nome)
            {
                return livro;
            }
        }
        return null;
        
    }
    public void RealizarEmprestimo(Usuario user, string buscaLivro)
    {
       Livro? livroBuscado = BuscarLivro(buscaLivro);
       
        if(livroBuscado != null && livroBuscado.Disponivel)
        {
            int idadeMin = (int)livroBuscado.Classificacao;
            if(user.Idade >= idadeMin)
            {
                Emprestimo emp = new(user,livroBuscado);
                listEmprestimos.Add(emp);
                livroBuscado.Emprestar();
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
    public void ListarUsuarios()
    {
        foreach (Pessoa usuarios in listPessoas)
        {
            Console.WriteLine(usuarios.Nome);
            Console.WriteLine(usuarios.Cpf);
            Console.WriteLine(usuarios.Email);
            Console.WriteLine(usuarios.Telefone);
        }
    }
    public Usuario? BuscarUsuario(string buscqCPF) //Retorna um objeto user, metodo verifica se existe um usuario
    {
        foreach(Pessoa user in listPessoas)
        {
            if(user.Cpf == buscqCPF)
            {
                return user;
            }
        }
        return null;
        
    }
    public Emprestimo? BuscaEmprestimo(string cpf, string buscaNlivro)
    {
        foreach(Emprestimo emprestimoAtivo in listEmprestimos)
        {
            if(emprestimoAtivo.User.Cpf == cpf && emprestimoAtivo.Book.Nome == buscaNlivro && emprestimoAtivo.DataDevolucao == null)
            {
                return emprestimoAtivo;
            }
        }
        return null;
    }
    public string RealizarDevolução(string cpf, string buscaLivro)
    {
        Emprestimo? emprestimo = BuscaEmprestimo(cpf,buscaLivro);
            if(emprestimo != null)
        {
            string situacao = emprestimo.RegistrarDevolucao();
            emprestimo.Book.Devolver();
                return situacao;
        }
        else
        {
            return "Não foi possivel efetuar a devolução";
        }
            

    }
}