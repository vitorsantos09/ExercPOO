Sistema sistemabi = new();
sistemabi.CadastrarAdministrador("ADMIN", "admin@email.com", "11999999999", "00000000000", "ADM001"); //Cadastra um administrador padrão, apenas para teste

    Console.WriteLine("==================================");
    Console.WriteLine("     Sistema de biblioteca      ");
    Console.WriteLine("==================================");
    Console.WriteLine("Digite seu cpf: ");
        string cpf = Console.ReadLine()!;
    Pessoa? pessoaLogada = sistemabi.BuscarPes(cpf);
    if (pessoaLogada != null)
    {
        switch (pessoaLogada)
        {
            case Administrador admin:
                Console.WriteLine(" Login do administrador realizado com sucesso!");
                Menus.MenuAdmin(sistemabi, admin); //Chama o metodo da classe menus, tendo em vista que o metodo é static, então não precisa instanciar a classe menus, apenas chamar o metodo diretamente
                break;
            case Bibliotecario bibliotecario:
                Console.WriteLine(" Login do bibliotecario realizado com sucesso!");
                Menus.MenuBibliotecario(sistemabi, bibliotecario);
                break;
            case Usuario usuario:
                Console.WriteLine(" Login do usuario realizado com sucesso!");
                Menus.MenuUser(sistemabi, usuario);
                break;
        }

    }
    else
    {
        Console.WriteLine("Não existe pessoa cadastrada com esse cpf");

    }
