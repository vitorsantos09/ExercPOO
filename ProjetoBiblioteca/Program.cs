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
    
    op = int.Parse(Console.ReadLine()!);
}while(op == 4);
