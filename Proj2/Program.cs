    int op =0;
    decimal valor =0;
    ContaBancaria conta = new();

    Console.WriteLine("Digite o nome do titular da conta: ");
        conta.Titular = Console.ReadLine()!;
    Console.WriteLine("Digite o Numero da conta: ");
        conta.NumeroConta = int.Parse(Console.ReadLine()!);
do
{
    Console.WriteLine("============================================");
    Console.WriteLine($"Bem vindo ao Caixa LeLé Sr. {conta.Titular}");
    Console.WriteLine("1. Depositar");
    Console.WriteLine("2. Sacar");
    Console.WriteLine("3. Mostrar Saldo");
    Console.WriteLine("4. Sair");
     Console.WriteLine("============================================");
       op = int.Parse(Console.ReadLine()!);
        Console.WriteLine("");

    switch (op)
    {
        case 1:
         Console.WriteLine("Deseja depositar quanto: ");
             valor = decimal.Parse(Console.ReadLine()!);
                conta.Depositar(valor);
            break;
        case 2:
        Console.WriteLine("Quanto deseja sacar: ");
            valor = decimal.Parse(Console.ReadLine()!);
            conta.Sacar(valor);
            break;
        case 3:
            conta.MostrarDados();
            break;
        case 4:
            Console.WriteLine("Obrigado por usar o Caixa LeLé");
            break;
    }
}while(op != 4);