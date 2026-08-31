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
    public string RealizarEmprestimo(Usuario user, string buscaLivro)
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
                return "Livro emprestado!";
            }
            else
            {
                return "Idade não condiz com a classificação indicativa do livro";
            }
        }
        else
        {
            return "Livro inexistente";
        }
    }
    public void ListarPessoas()
    {
        foreach (Pessoa pessoa in listPessoas)
        {
            Console.WriteLine(pessoa.Nome);
            Console.WriteLine(pessoa.Cpf);
            Console.WriteLine(pessoa.Email);
            Console.WriteLine(pessoa.Telefone);
            if(pessoa is Usuario)
            {
                foreach(Usuario user in listPessoas)
                {
                    Console.WriteLine(user.Idade);
                }
                
            }
            else if (pessoa is Bibliotecario)
            {
                foreach(Bibliotecario bilio in listPessoas)
                {
                    Console.WriteLine(bilio.Matricula);
                }
            }
            else
            {
                foreach(Administrador admin in listPessoas)
                {
                    Console.WriteLine(admin.Matricula_admin);
                }
            }
        }
    }
    public void ListarLivros()
    {
        foreach(Livro livros in listLivros)
        {
            Console.WriteLine(livros.Nome);
            Console.WriteLine(livros.Classificacao);
            Console.WriteLine(livros.Genero);
        }
    }

    public void ListarDisponiveis()
    {
        foreach(Livro livrosDisp in listLivros)
        {
            if (livrosDisp.Disponivel == true)
            {
            Console.WriteLine(livrosDisp.Nome);
            Console.WriteLine(livrosDisp.Classificacao);
            Console.WriteLine(livrosDisp.Genero);
            }
        }
    }
    public void ListarEmp()
    {
        foreach(Emprestimo empAtivo in listEmprestimos)
        {
            if(empAtivo.DataDevolucao == null)
            {
                Console.WriteLine(empAtivo.User.Nome);
                Console.WriteLine(empAtivo.User.Cpf);
                Console.WriteLine(empAtivo.Book.Nome);
                Console.WriteLine(empAtivo.DataEmprestimo);
            }
        }
    }
    public void ListHistorico()
    {
        foreach(Emprestimo empHist in listEmprestimos)
        {
            
                Console.WriteLine($"Usuario: {empHist.User.Nome}");
                Console.WriteLine($"Livro: {empHist.Book.Nome}");
                Console.WriteLine($"Data do emprestimo: {empHist.DataEmprestimo}");
                if(empHist.DataDevolucao == null)
            {
                Console.WriteLine("Ainda não devolvido");
            }
            else
            {
                Console.WriteLine(empHist.DataDevolucao);

            }
        }
    }
    public Usuario? BuscarUsuario(string buscqCPF) //Retorna um objeto user, metodo verifica se existe um usuario
    {
        foreach(Pessoa pessoa in listPessoas)
        {
            if(pessoa is Usuario user) //Verifica o tipo pessoa é Usuario?
            {
                if(user.Cpf == buscqCPF)
                {
                    return user;
                }
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