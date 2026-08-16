class ContaBancaria{
    private string? _titularConta;
    public string? Titular
    {
        get{return _titularConta;}
        set{_titularConta = value;}
    }
    private int _numeroConta;
    public int NumeroConta
    {
        get{return _numeroConta;}
        set{_numeroConta = value;}
    }

    private decimal _saldo = 0;
    public decimal Saldo
    {
        get{return _saldo;}
        set{_saldo = value;}
    }

    public decimal Depositar(decimal valorDep)
    {
            if(valorDep <= 0 )
        {
            Console.WriteLine("Valor de deposito insuficiente!");
            return valorDep-=valorDep;
        }
        else{
        Console.WriteLine($"Você depositou {valorDep} R$, Saldo {Saldo+valorDep}R$");
                return Saldo+=valorDep;
        }
    }
    public decimal Sacar(decimal valorSaque)
    {
            if(valorSaque <= 0 || valorSaque > Saldo)
        {
            Console.WriteLine("Valor de saque insuficiente");
                return valorSaque-=valorSaque;
        }
        else{
        Console.WriteLine($"Voce sacou {valorSaque} R$, Saldo {Saldo-valorSaque}R$");
             return Saldo-=valorSaque;
        }
    }
    
    public void MostrarDados()
    {
        Console.WriteLine("==================================");
        Console.WriteLine($"Titular {Titular}");
        Console.WriteLine($"Numero da conta: {NumeroConta}");
        Console.WriteLine($"Saldo atual : {Saldo}R$");
    }
    
}