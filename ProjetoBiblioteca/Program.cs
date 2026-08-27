Sistema sistemabi = new();
int op;
string? buscaLivro;
string? BuscaCPF;

do
{
    Console.WriteLine("==================================");
    Console.WriteLine("     Sistema de biblioteca      ");
    Console.WriteLine("==================================");
    Console.WriteLine("1. Cadastrar tipo de Pessoa");
    Console.WriteLine("2. Cadastrar Livros");
    Console.WriteLine("3. Buscar Livro");
    Console.WriteLine("4. Realizar Emprestimo");
    Console.WriteLine("5. Realizar Devolução");
    Console.WriteLine("0. Sair");
    if (int.TryParse(Console.ReadLine(), out op))
    {
        switch (op)
        {
            case 1:

                Console.WriteLine("==================================");
                Console.WriteLine("1. Cadastrar Usuario");
                Console.WriteLine("2. Cadastrar Bibliotecario[a]");
                Console.WriteLine("3. Cadastrar Administrador[a]");
                if (int.TryParse(Console.ReadLine(), out int opCad))
                {
                    Cadastrar(out string nome, out string email, out string telefone, out string cpf);
                    switch (opCad)
                    {
                        case 1:
                            Console.WriteLine($"Digite a idade do {nome}: ");
                                int idade = int.Parse(Console.ReadLine()!);
                            sistemabi.CadastrarUsuario(nome, email, telefone, cpf, idade);
                            break;
                        case 2:
                            Console.WriteLine("Digite a matricula do bibliotecario: ");
                                string matricula = Console.ReadLine()!;
                            sistemabi.CadastrarBibliotecario(nome, email, telefone, cpf, matricula);
                            break;
                        case 3:
                            Console.WriteLine("Digite a matricula do Administrador: ");
                                string matriculaAdmin = Console.ReadLine()!;
                            sistemabi.CadastrarAdministrador(nome, email, telefone, cpf, matriculaAdmin);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um valor valido");
                }
                break;
            case 2:
                CadFrontLivro(out string nomeLivro, out ClassificacaoIndicativa classificacao, out GeneroLivro genero); //Declara as variaveis e faz a chamada no out para serem preenchidas no Metodo e retornarem para essa chamada
                    sistemabi.CadastrarLivro(nomeLivro, classificacao, genero);
                Console.WriteLine("Livro Cadastrado com sucesso!");
                break;

            case 3:
                Console.WriteLine("Digite o nome do livro que deseja buscar: ");
                    buscaLivro = Console.ReadLine()!.ToUpper();
                Livro? encontrado = sistemabi.BuscarLivro(buscaLivro);
                if (encontrado != null)
                {
                    Console.WriteLine(encontrado.Nome);
                    Console.WriteLine(encontrado.Genero);
                    Console.WriteLine(encontrado.Classificacao);
                    Console.WriteLine(encontrado.Disponivel);
                }
                else
                {
                    Console.WriteLine("Livro não encontrado");
                }
                break;

            case 4:
                Console.WriteLine("Qual o cpf do usuario que deseja realizar o emprestimo: ");
                    BuscaCPF = Console.ReadLine()!;
                Usuario? user = sistemabi.BuscarUsuario(BuscaCPF);
                Console.WriteLine("Qual o nome do livro que deseja pegar emprestado: ");
                    buscaLivro = Console.ReadLine()!.ToUpper();
                if (user != null)
                {
                    sistemabi.RealizarEmprestimo(user, buscaLivro);
                }
                else
                {
                    Console.WriteLine("não encontrado");
                }
                break;
            case 5:
                Console.WriteLine("Qual o cpf do usuario que deseja efetuar a devolução: ");
                    BuscaCPF = Console.ReadLine()!;
                Console.WriteLine("Qual o nome do livro que deseja devolver: ");
                    buscaLivro = Console.ReadLine()!.ToUpper();
                string situacao = sistemabi.RealizarDevolução(BuscaCPF,buscaLivro);
                Console.WriteLine($"o livro {buscaLivro} {situacao}");
            break;
        }
    }
    else
    {
        Console.WriteLine("Digite um valor valido");

    }
} while (op != 0);

static void Cadastrar(out string nome, out string email, out string telefone, out string cpf)
{
    Console.WriteLine("===============================");
    Console.WriteLine("Digite o nome do individuo: ");
        nome = Console.ReadLine()!.ToUpper();
    Console.WriteLine($"Digite o Cpf do {nome}: ");
        cpf = Console.ReadLine()!.ToUpper();
    Console.WriteLine($"Digite o email do {nome}: ");
        email = Console.ReadLine()!.ToLower();
    Console.WriteLine($"Digite o telefone do {nome}: ");
        telefone = Console.ReadLine()!;
}

static void CadFrontLivro(out string nomeLivro, out ClassificacaoIndicativa classificacao, out GeneroLivro genero) // Cadastra o livro, mostra os enumeradores e o usuario escolhe qual ele quer em relação aos valores de enumeradores ja definidos
{
    bool sucessoGen;
    bool sucessoClass;

    Console.WriteLine("===============================");
    Console.WriteLine("Digite o nome do Livro: ");
        nomeLivro = Console.ReadLine()!.ToUpper();
    Console.WriteLine($"Digite a classificação indicativa do {nomeLivro}: ");
    foreach (ClassificacaoIndicativa classi in Enum.GetValues<ClassificacaoIndicativa>()) //Percorre todos o valores do enumeradores, primeiro converte os valores para inteiro, depois mostra as opções 
    {
        Console.WriteLine($"{(int)classi} - {classi}");
    }

    //Verificação e converter a escolha do usuario para opção valida do enum
    do
    {
        sucessoClass = (Enum.TryParse(Console.ReadLine()!, ignoreCase: true, out classificacao) && Enum.IsDefined(typeof(ClassificacaoIndicativa), classificacao));
        if (!sucessoClass)
        {
            Console.WriteLine("Valor inválido ou não definido.");
        }
        else
        {
            Console.WriteLine($"Sucesso: {classificacao}");
        }
    } while (!sucessoClass);

    Console.WriteLine($"Digite o genero do {nomeLivro}: ");
    foreach (GeneroLivro generoL in Enum.GetValues<GeneroLivro>())
    {
        Console.WriteLine($"{(int)generoL} - {generoL}");
    }

    //Verificação e converter a escolha do usuario para opção valida do enum
    do
    {
        sucessoGen = (Enum.TryParse(Console.ReadLine()!, ignoreCase: true, out genero) && Enum.IsDefined(typeof(GeneroLivro), genero));
        if (!sucessoGen)
        {
            Console.WriteLine("Valor inválido ou não definido.");
        }
        else
        {
            Console.WriteLine($"Sucesso: {genero}");
        }
    } while (!sucessoGen);
}

