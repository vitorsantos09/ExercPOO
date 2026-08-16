    string op;
    Aluno al = new();
    Console.WriteLine("Bem vindo a SED 2.0");
do
{
    Console.WriteLine("Digite o nome do Aluno: ");
        al.Nome = Console.ReadLine();
       
    Console.WriteLine("Digite a primeira nota do Aluno: ");
        al.Nota1 = Convert.ToDecimal(Console.ReadLine());
         al.VerificaNota();
    Console.WriteLine("Digite a segunda nota do Aluno: ");
        al.Nota2 = Convert.ToDecimal(Console.ReadLine());
         al.VerificaNota();
    Console.WriteLine("Digite a terceira nota do Aluno: ");
        al.Nota3 = Convert.ToDecimal(Console.ReadLine());
         al.VerificaNota();
        Console.Clear();

        al.ExibirAluno();
        decimal Media = al.CalculaMedia();
        al.MostraBoletim();
            Console.WriteLine("Deseja cadastrar mais algum aluno? [S/N]");
            op = Console.ReadLine()!.ToUpper();
}while(op == "S");