class Estagiario : Funcionario
{
    public double Bolsa;
    public Estagiario(string nome,string cpf,string cargo, double salarioBruto): base(nome,cpf, cargo, salarioBruto)
    {
        Bolsa = salarioBruto;
    } // constroe 
    public override double CalcularDesconto(double bolsa)
    {
        double desconto = base.CalcularDesconto(bolsa);
        return desconto;
    }
    public override double CalcularSalario(double salarioBruto)
    {
        Bolsa = Bolsa -CalcularDesconto(salarioBruto);
        return Bolsa;
    }
}