class FuncionarioTemp : Funcionario
{
    public double DescontoTemp;
    public FuncionarioTemp(string nome, string cpf, string cargo, float salario ) : base(nome, cpf, cargo, salario)
    {
        DescontoTemp *= 0.3;
    }
}