using System.Dynamic;

class Funcionario
{
    
    public string? Nome {get; set;} // propriedades 
    
     public string? Cpf {get; set;}
    
     public string? Cargo {get; set;}

     public double Salario {get; set;}
  

    public Funcionario(string? nome, string? cpf, string? cargo, double salario) //inicializando os valores do objeto da propria classe
    {
        this.Nome = nome;
        this.Cpf = cpf;
        this.Cargo = cargo;
        this.Salario = salario;
    }

    public Funcionario()
    {
    }

    public virtual double CalcularDesconto(double salario) // Retorna o valor do desconto sobre o salario bruto
    {
       return salario * 0.06;

    }
}