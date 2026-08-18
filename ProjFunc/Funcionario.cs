using System.Dynamic;

class Funcionario
{
    
    public string? Nome {get; set;} // propriedades 
    public string? Cpf {get; set;}
    public string? Cargo {get; set;}
    public double SalarioBruto {get; set;}
    public double SalarioLiquido {get; set;}
  

    public Funcionario(string? nome, string? cpf, string? cargo, double salarioBruto) //inicializando os valores do objeto da propria classe
    {
        this.Nome = nome;
        this.Cpf = cpf;
        this.Cargo = cargo;
        this.SalarioBruto = salarioBruto;
    }

    public virtual double CalcularDesconto(double salarioBruto) // Retorna o valor do desconto sobre o salario bruto
    {
       return salarioBruto * 0.06; //Retorna o valor do desconto, ex: 1066 * 6% = 63,96

    }
    public virtual double CalcularSalario(double salarioBruto)
    {
        double salarioLiquido = salarioBruto - CalcularDesconto(salarioBruto);
        return salarioLiquido;
    }
    
}