class FuncionarioCLT : Funcionario
{
    public double INSS; 
     public FuncionarioCLT(double salario): base() // constroe 
    {
        INSS = salario * 0.075;
    }

    public override double CalcularDesconto(double salario)
    {
        double desconto = base.CalcularDesconto(salario);
        return salario - INSS - desconto;
    }
    
}