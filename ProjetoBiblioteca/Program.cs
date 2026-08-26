Sistema sistemabi = new();
int op;
string? buscaLivro;

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
                    Cadastrar(out string nome, out string email, out string cpf, out string telefone);
                    switch (opCad)
                    {
                        case 1:
                            Console.WriteLine($"Digite a idade do {nome}: ");
                                int idade = int.Parse(Console.ReadLine()!);
                            sistemabi.CadastrarUsuario(nome, email, cpf, telefone, idade);
                            break;
                        case 2: 
                            Console.WriteLine("Digite a matricula do bibliotecario: ");
                                string matricula = Console.ReadLine()!;
                            sistemabi.CadastrarBibliotecario(nome,email,cpf,telefone,matricula);
                            break;
                        case 3: 
                            Console.WriteLine("Digite a matricula do Administrador: ");
                                string matriculaAdmin = Console.ReadLine()!;
                            sistemabi.CadastrarAdministrador(nome,email,cpf,telefone,matriculaAdmin);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um valor valido");
                }
                break;
            case 2: 
            CadFrontLivro(out string nomeLivro, out ClassificacaoIndicativa classificacao, out GeneroLivro genero);
            sistemabi.CadastrarLivro(nomeLivro,classificacao,genero);
            Console.WriteLine("Livro Cadastrado com sucesso!");
            break;
        }

    }
    else
    {
        Console.WriteLine("Digite um valor valido");
        
    }
} while (op != 0);

static void Cadastrar(out string nome, out string email, out string cpf, out string telefone)
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
    nomeLivro = Console.ReadLine()!;
    Console.WriteLine($"Digite a classificação indicativa do {nomeLivro}: ");
    foreach (ClassificacaoIndicativa classi in Enum.GetValues<ClassificacaoIndicativa>()) //Percorre todos o valores do enumeradores, primeiro converte os valores para inteiro, depois mostra as opções 
    {
        Console.WriteLine($"{(int)classi} - {classi}");
    }

    //Verificação e converter a escolha do usuario para opção valida do enum
    do{
        sucessoClass = (Enum.TryParse(Console.ReadLine()!, ignoreCase: true, out classificacao) && Enum.IsDefined(typeof(ClassificacaoIndicativa),classificacao));
        if(!sucessoClass){
            Console.WriteLine("Valor inválido ou não definido.");
        }
         else
        {
            Console.WriteLine($"Sucesso: {classificacao}");
        }
    }while(!sucessoClass);

    Console.WriteLine($"Digite o genero do {nomeLivro}: ");
    foreach (GeneroLivro generoL in Enum.GetValues<GeneroLivro>())
    {
        Console.WriteLine($"{(int)generoL} - {generoL}");
    }

    //Verificação e converter a escolha do usuario para opção valida do enum
    do{
     sucessoGen = (Enum.TryParse(Console.ReadLine()!, ignoreCase: true, out genero) && Enum.IsDefined(typeof(GeneroLivro),genero));
        if (!sucessoGen)
        {
            Console.WriteLine("Valor inválido ou não definido.");
        }
         else
        {
            Console.WriteLine($"Sucesso: {genero}");
        }
        }while(!sucessoGen);
}

