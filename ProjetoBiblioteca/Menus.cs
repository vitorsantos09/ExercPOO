class Menus // Controle de interação 
{
    public static void MenuAdmin(){}
    public static void MenuUser(){}
    public static void MenuBibliotecario(){}
    public static void Cadastrar(string nome, string cpf, string email, string telefone){
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
    public static void CadFrontLivro(out string nomeLivro, out ClassificacaoIndicativa classificacao, out GeneroLivro genero)
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
}