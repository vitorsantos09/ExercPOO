class Estagiario : Funcionario
{
    public double Bolsa;
    public Estagiario(string nome,string cpf,string cargo, double salarioBruto): base(nome,cpf, cargo, salarioBruto) // constroe 
    {
        Bolsa = salarioBruto;
    }
    public override double CalcularDesconto(double bolsa)
    {
        return base.CalcularDesconto(bolsa);
    }
}