class FuncionarioCLT : Funcionario
{
    public double INSS;

    public FuncionarioCLT(string nome,string cpf,string cargo, double salarioBruto)//recebe os valores da herança
    : base(nome,cpf, cargo, salarioBruto) // envia os dados para o construtor da classe Funcionario
    {
        INSS = salarioBruto * 0.075;
    }

    public override double CalcularDesconto(double salarioBruto) // O FuncionarioCLT está sobrescrevendo o método CalcularDesconto() da classe Funcionario. Ele recebe o salário bruto e retorna um double representando um desconto.
    {
        double desconto = base.CalcularDesconto(salarioBruto); //chama o método da classe pai (Funcionario).
        return INSS + desconto;
    }
    public override double CalcularSalario(double salarioBruto)
    {
        double descontos = CalcularDesconto(salarioBruto);
        return descontos - salarioBruto;
        ;
    }
    
}