using ProjetoBiblioteca.Abstract;
using ProjetoBiblioteca.Class; //Referencia a pasta que eu botei as classes 
using ProjetoBiblioteca.Enums; //Referencia a pasta que eu botei as enums
using System;
using System.Collections.Generic;
using System.Text;
class Sistema
{
    List<Pessoa> listPessoas = new(); //List cresce e diminui dinamicamente.
    List<Livro> listLivros = new();
    List<Emprestimo> listEmprestimos = new();
    List<SolicitaEmprestimo> listSolicita = new();

    public void CadastrarUsuario(string nome, string email, string telefone, string cpf, DateTime datanasc)
    {
        Usuario usuario = new(nome, email, telefone, cpf, datanasc);
        listPessoas.Add(usuario);
    }
    public void CadastrarBibliotecario(string nome, string email, string telefone, string cpf, int matricula)
    {
        Bibliotecario bibliotecario = new(nome, email, telefone, cpf, matricula);
        listPessoas.Add(bibliotecario);
    }
    public void CadastrarAdministrador(string nome, string email, string telefone, string cpf, int matriculaAdmin)
    {
        Administrador admin = new(nome, email, telefone, cpf, matriculaAdmin);
        listPessoas.Add(admin);
    }

    public void CadastrarLivro(string nome, ClassificacaoIndicativa classificacao, GeneroLivro generoLivro)
    {
        Livro livro = new(nome, classificacao, generoLivro);
        listLivros.Add(livro);
    }

    public Livro? BuscarLivro(string buscaLivro) //Esse método pode retornar um objeto Livro ou null.
    {
        foreach (Livro livro in listLivros)//Para cada Livro chamado livro dentro de listLivros, compare o buscalivro com o nome do livro, se achar, retorne o objeto.
        //foreach varre todas os objetos da lista
        {
            if (buscaLivro == livro.Nome)
            {
                return livro;
            }
        }
        return null;

    }

    public int ContEmprestimos(Usuario user)
    {
        int count = 0;
        foreach (Emprestimo empUser in listEmprestimos)
        {
            if (empUser.User == user && empUser.DataDevolucao == null)
            {
                count++;
            }
        }
        return count;
    }
    public string RealizarEmprestimo(Usuario user, string solicitaLivro)
    {
        Livro? livroBuscado = BuscarLivro(solicitaLivro);
        Emprestimo? emp = BuscaEmprestimoAtivo(solicitaLivro);
        int count = ContEmprestimos(user);

        if (livroBuscado != null && emp == null)
        {
            if (count < 3)
            {
                int idadeMin = (int)livroBuscado.Classificacao; // Compara com o valor int do enum
                if (user.DataNasc <= DateTime.Now.AddYears(-idadeMin)) // Verifica se a idade do usuário é maior ou igual à classificação indicativa do livro
                {

                    emp = new(user, livroBuscado);
                    listEmprestimos.Add(emp);
                    return "Livro emprestado!";
                }
                else
                {
                    return "Idade não condiz com a classificação indicativa do livro";
                }
            }
            else
            {
                return "Usuario já tem 3 Emprestimos Ativos";
            }
        }
        else if (livroBuscado != null && emp != null)
        {
            return "Livro indisponível";
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
            Console.WriteLine("");
            Console.WriteLine("==================================");
            Console.WriteLine($"Nome: {pessoa.Nome}");
            Console.WriteLine($"Cpf: {pessoa.Cpf}");
            Console.WriteLine($"Email: {pessoa.Email}");
            Console.WriteLine($"Telefone: {pessoa.Telefone}");
            Console.WriteLine("==================================");
            if (pessoa is Usuario user)
            {
                Console.WriteLine($"Data de Nascimento: {user.DataNasc}");
                Console.WriteLine("");

            }
            else if (pessoa is Funcionario func)
            {
                Console.WriteLine($"Matricula do Funcionario: {func.Matricula}");
                Console.WriteLine("");

            }
        }
    }
    public void ListarLivros()
    {
        foreach (Livro livros in listLivros)
        {
            Console.WriteLine("");
            Console.WriteLine("==================================");
            Console.WriteLine($"Nome do Livro: {livros.Nome}");
            Console.WriteLine($"Classificação Indicativa do Livro: {livros.Classificacao}");
            Console.WriteLine($"Genero do Livro: {livros.Genero}");
            Console.WriteLine("");
        }
    }

    public void ListarDisponiveis()
    {

        foreach (Livro livroDisp in listLivros)
        {
            Emprestimo? emp = BuscaEmprestimoAtivo(livroDisp.Nome!);
            if (emp == null)
            {
                Console.WriteLine("");
                Console.WriteLine("==================================");
                Console.WriteLine(livroDisp.Nome);
                Console.WriteLine(livroDisp.Classificacao);
                Console.WriteLine(livroDisp.Genero);
                Console.WriteLine("");

            }
        }
    }
    public void ListarEmp()
    {
        foreach (Emprestimo empAtivo in listEmprestimos)
        {
            if (empAtivo.DataDevolucao == null)
            {
                Console.WriteLine("");
                Console.WriteLine(empAtivo.User.Nome);
                Console.WriteLine(empAtivo.User.Cpf);
                Console.WriteLine(empAtivo.Book.Nome);
                Console.WriteLine(empAtivo.DataEmprestimo);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Não há livros com emprestimo ativo");
            }
        }
    }
    public void ListHistorico()
    {
        foreach (Emprestimo empHist in listEmprestimos)
        {
            Console.WriteLine("");
            Console.WriteLine($"Usuario: {empHist.User.Nome}");
            Console.WriteLine($"Livro: {empHist.Book.Nome}");
            Console.WriteLine($"Data do emprestimo: {empHist.DataEmprestimo}");
            Console.WriteLine("");
            if (empHist.DataDevolucao == null)
            {
                Console.WriteLine("Ainda não devolvido");
            }
            else
            {
                Console.WriteLine(empHist.DataDevolucao);
                Console.WriteLine("================================");

            }
        }
    }
    public Usuario? BuscarUsuario(string buscqCPF) //Retorna um objeto user, metodo verifica se existe um usuario
    {
        foreach (Pessoa pessoa in listPessoas)
        {
            if (pessoa is Usuario user) //Verifica o tipo pessoa é Usuario? Pattern Matching
            {
                if (user.Cpf == buscqCPF)
                {
                    return user;
                }
            }
        }
        return null;

    }
    public Emprestimo? BuscaEmprestimoAtivo(string buscaNlivro)
    {
        foreach (Emprestimo emprestimoAtivo in listEmprestimos)
        {
            if (emprestimoAtivo.Book.Nome == buscaNlivro && emprestimoAtivo.DataDevolucao == null)
            {
                return emprestimoAtivo;
            }
        }
        return null;
    }
    public string RealizarDevolução(string cpf, string buscaLivro)
    {
        Emprestimo? emprestimo = BuscaEmprestimoAtivo(buscaLivro);
        if (emprestimo != null && emprestimo.User.Cpf == cpf)
        {
            string situacao = emprestimo.RegistrarDevolucao();
            return situacao;
        }
        else
        {
            return "Não foi possivel efetuar a devolução";
        }
    }

    public Pessoa? BuscarPes(string cpf)
    {
        foreach (Pessoa pessoaBusc in listPessoas)
        {
            if (cpf == pessoaBusc.Cpf)
            {
                return pessoaBusc;
            }
        }
        return null;
    }
    public bool VerificarCpf(string cpf) //Verifica se o cpf já está cadastrado, retorna true se estiver, false se não estiver
    {
        foreach (Pessoa pessoa in listPessoas)
        {
            if (pessoa.Cpf == cpf)
            {
                return true;
            }
        }
        return false;
    }

    public void SolicitarEmprestimo(Usuario user, string nomeLivro)
    {
        int count = ContEmprestimos(user);
        Livro? livroEx = BuscarLivro(nomeLivro);
        if (livroEx != null)
        {
            foreach (SolicitaEmprestimo solicitacaoEx in listSolicita) //Verifica se o usuário já solicitou o livro e se a solicitação está pendente
            {
                if (solicitacaoEx.User == user && solicitacaoEx.Book == livroEx && solicitacaoEx.Status == StatusSolicita.Pendente)
                {
                    Console.WriteLine("Você já solicitou este livro.");
                    return;
                }
            }
            if (count < 3)
            {
                SolicitaEmprestimo solicitacao = new(user, livroEx);
                listSolicita.Add(solicitacao);
                Console.WriteLine("Solicitação enviada, aguardando aprovacao");
            }
            else
            {
                Console.WriteLine("Usuario ja possui 3 emprestimos ativos");
            }
        }
        else
        {
            Console.WriteLine("Livro Inexistente");
        }

    }

    public SolicitaEmprestimo? BuscarSolicitacoes(string nomeLivro, string cpf)
    {
        foreach (SolicitaEmprestimo solicitacoes in listSolicita)
        {
            if (nomeLivro == solicitacoes.Book.Nome && cpf == solicitacoes.User.Cpf && solicitacoes.Status == StatusSolicita.Pendente)
            {
                return solicitacoes;
            }
        }
        return null;
    }

    public void ListarSolicitacoes()
    {
        foreach (SolicitaEmprestimo solicitacao in listSolicita)
        {
            if (solicitacao.Status == StatusSolicita.Pendente)
            {
                Console.WriteLine($"Usuário: {solicitacao.User.Nome}");
                Console.WriteLine($"CPF: {solicitacao.User.Cpf}");
                Console.WriteLine($"Livro: {solicitacao.Book.Nome}");
                Console.WriteLine($"Data da Solicitação: {solicitacao.DataSolicitacao}");
                Console.WriteLine($"Status: {solicitacao.Status}");
                Console.WriteLine("-----------------------------");
            }
        }
    }
    public void AprovarSolicitacao(string cpf, string nomeLivro)
    {
        SolicitaEmprestimo? solicitacao = BuscarSolicitacoes(nomeLivro, cpf);
        if (solicitacao != null)
        {
            string resultado = RealizarEmprestimo(solicitacao.User, nomeLivro);
            if (resultado == "Livro emprestado!")
            {
                solicitacao.Aprovar();
                Console.WriteLine("Solicitação aprovada e empréstimo realizado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Não foi possível aprovar a solicitação: {resultado}");
                return;
            }
        }
        else
        {
            Console.WriteLine("Solicitação não encontrada ou já processada.");
        }
    }
    public void ReprovarSolicitacao(string cpf, string nomeLivro)
    {
        SolicitaEmprestimo? solicitacao = BuscarSolicitacoes(nomeLivro, cpf);
        if (solicitacao != null)
        {
            solicitacao.Reprovar();
            Console.WriteLine("Solicitação reprovada com sucesso.");
        }
        else
        {
            Console.WriteLine("Solicitação não encontrada ou já processada.");
        }
    }
}
