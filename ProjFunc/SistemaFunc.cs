class SistemaFunc
{
    Funcionario[] funcionarios = new Funcionario[10];
    int quant;

    public void CadastrarFunc(string nome, string cargo, string cpf, double salarioBruto, int opcad)
    {
        if (quant >= 10)
        {
            Console.WriteLine("Empresa ta cheia pai");
        }
        else
        {
            if (opcad == 1)
            {
                FuncionarioCLT func = new(nome, cargo, cpf, salarioBruto);
                funcionarios[quant] = func; // o vetor funcionarios na posição quantidade, ex: posição 1 recebe o objeto funcionarioCLT
                quant++;
            }
            else if (opcad == 2)
            {
               Estagiario estagiario = new(nome, cargo, cpf, salarioBruto);
               funcionarios[quant] = estagiario;
               quant++;
                                                            
            }
            else
            {
                Console.WriteLine("Opção errada pai");
            }
        }
    }
    public void CadastrarFuncTemp(string nome, string cargo, string cpf, double salarioBruto, double horastrabalhadas)
    {
        FuncionarioTemp funcTemp = new(nome, cargo, cpf, salarioBruto, horastrabalhadas);
        funcionarios[quant] = funcTemp;
        quant++;
    }
    public void ListarFunc()
    {
        for(int i = 0; i < quant; i++)
        {
            Console.WriteLine("==========================");
            Console.WriteLine(funcionarios[i].Nome);
            Console.WriteLine(funcionarios[i].GetType().Name.ToUpper()); // Mostra o tipo exato do Objeto, ou seja mostra o nome exato do objeto, só funciona porconta que, ex: FuncionarioCLT tem Herança com o Funcionario
            Console.WriteLine(funcionarios[i].Cpf);
            Console.WriteLine(funcionarios[i].Cargo);
            Console.WriteLine(funcionarios[i].SalarioBruto);
            Console.WriteLine("==========================");


        }
    }
   public void CalcularSalarios()
    {
        for (int i = 0; i < quant; i++)
        {
            Console.WriteLine("================================================");
            double salarioLiquido = funcionarios[i].CalcularSalario(funcionarios[i].SalarioBruto);
            Console.WriteLine(funcionarios[i].Nome);
            Console.WriteLine(funcionarios[i].Cargo);
            Console.WriteLine(salarioLiquido);
        }

    }
}