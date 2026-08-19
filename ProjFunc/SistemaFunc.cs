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

                double salarioLiquido = func.CalcularSalario(salarioBruto); //linha deve ser colocada no metodo de calculo de salario aqui dessa classe, pois ela pertence ao case 3

                funcionarios[quant] = func; // o vetor funcionarios na posição quantidade, ex: posição 1 recebe o objeto funcionarioCLT
                quant++;
            }
            else if (opcad == 2)
            {
               Estagiario estagiario = new(nome,cargo,cpf,salarioBruto);

               double Bolsa = estagiario.CalcularSalario(salarioBruto);//linha deve ser colocada no metodo de calculo de salario aqui dessa classe, pois ela pertence ao case 3

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
        FuncionarioTemp funcTemp = new(nome,cargo,cpf,salarioBruto,horastrabalhadas);

        funcTemp.CalcularDescontoTemp(salarioBruto,horastrabalhadas);//linha deve ser colocada no metodo de calculo de salario aqui dessa classe, pois ela pertence ao case 3
        double salarioLiquido = funcTemp.CalcularSalario(salarioBruto);//linha deve ser colocada no metodo de calculo de salario aqui dessa classe, pois ela pertence ao case 3

        funcionarios[quant] = funcTemp;
        quant++;
    }
    public void ListarFunc()
    {
        for(int i = 0; i < funcionarios.Length; i++)
        {
            Console.WriteLine(funcionarios[i]);
        }
    }
   /* public double CalcularSalarios()
    {
        return; //metodos aqui, valor a ser exibido pelo return
    }*/
}