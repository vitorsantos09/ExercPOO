class FuncionarioTemp : Funcionario
{
    public double HorasTrabalhadas {get;set;}
    public FuncionarioTemp(string nome,string cpf,string cargo,double salarioBruto, double horastrabalhadas) : base(nome,cpf,cargo,salarioBruto)
    {
        this.HorasTrabalhadas = horastrabalhadas;
    }

    public double CalcularDesconto(double salarioBruto, double horastrabalhadas)
    {
        double desconto = base.CalcularDesconto(salarioBruto);
        return desconto - (horastrabalhadas * 7.37);
    }
    public override double CalcularSalario(double salarioBruto)
    {
         double desconto = CalcularDesconto(salarioBruto);
         return salarioBruto-desconto;
    }
}