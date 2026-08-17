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
                double salarioLiquido = func.CalcularSalario(salarioBruto);
                funcionarios[quant] = func;
                quant++;
            }
            else if (opcad == 2)
            {
               Estagiario estagiario = new(nome,cargo,cpf,salarioBruto);
               
            }
            else if (opcad == 3)
            {
                
                FuncionarioTemp funcTemp = new(nome,cargo,cpf,salarioBruto,horastrabalhadas);
            }
            else
            {
                Console.WriteLine("Opção errada pai");
            }
        }
    }
}