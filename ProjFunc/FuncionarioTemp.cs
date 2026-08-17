class FuncionarioTemp : Funcionario
{
    public double ValorHora = 7.37;
    public double HorasTrabalhadas {get;set;}
    public FuncionarioTemp(string nome,string cpf,string cargo,double salarioBruto, double horastrabalhadas) : base(nome,cpf,cargo,salarioBruto)
    {
        this.HorasTrabalhadas = horastrabalhadas;
    }

    public double CalcularDescontoTemp(double salarioBruto, double valorhora, double horastrabalhadas)
    {
        double desconto = base.CalcularDesconto(salarioBruto);
        return desconto + (horastrabalhadas * valorhora);
    }
}