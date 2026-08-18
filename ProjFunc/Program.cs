
using System.Collections;

class Program
{   
    static void Main(){
     SistemaFunc sistema = new();

    int op = 0;

    Console.WriteLine("Bem vindo ao sistema de cadastros de Funcionarios!!");
    do{
        
        Console.WriteLine("1. Cadastrar Funcionarios");
        Console.WriteLine("2. Listar Funcionarios");
        Console.WriteLine("3. Calcular Salario");
        Console.WriteLine("4. Sair");
            op = int.Parse(Console.ReadLine()!);

            switch (op){
            case 1:
                    Console.WriteLine("Que tipo de Funcionario voce quer cadastrar? ");
                    Console.WriteLine("1. Funcionario Efetivo");
                    Console.WriteLine("2. Estagiario");
                    Console.WriteLine("3. Funcionario Temporario");
                        int opCad = int.Parse(Console.ReadLine()!);
                        CadastroPad(out string nome, out string cpf, out string cargo, out double salarioBruto,opCad); //Declara as variaveis e faz a chamada no out para serem preenchidas no Metodo e retornarem para essa chamada
                        if(opCad == 3){
                            double horastrabalhadas = LeHoras(nome);
                            sistema.CadastrarFuncTemp(nome,cpf,cargo,salarioBruto,horastrabalhadas);
                            break;
                    }
                    sistema.CadastrarFunc(nome, cpf, cargo, salarioBruto,opCad); // passa os valores preenchidos no out e manda para o metodo de cadastro do sistema
                            break;
            case 2:
                sistema.ListarFunc();
                    break;

            case 3: 
                sistema.CalcularSalarios();
                    break;
                }
                
    }while(op != 4);
    }
    static void CadastroPad(out string nome,out string cpf,out string cargo, out double salarioBruto, int opCad )
{
    Console.WriteLine("Digite o nome do Funcionario");
        nome = Console.ReadLine()!.ToUpper();
    Console.WriteLine("Digite o cpf do Funcionario");
        cpf = Console.ReadLine()!.ToUpper();
    Console.WriteLine("Digite o cargo do Funcionario");
        cargo = Console.ReadLine()!.ToUpper();
    Console.WriteLine("Digite o salario bruto do Funcionario");
        salarioBruto = double.Parse(Console.ReadLine()!);
}
static double LeHoras(string nome)
    {
        Console.WriteLine($"Quantas horas o Funcionario {nome} trabalhou?");
            double horastrabalhadas = double.Parse(Console.ReadLine()!);
            return horastrabalhadas;
    }
}