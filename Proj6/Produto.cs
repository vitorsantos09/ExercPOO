class Produto
{
    private string? _nome;
    public string? Nome
    {
        get{return _nome;}
        set{_nome = value;
        }
    }
    private int _quantidadeesto;
    public int QuantidadeEstoq
    {
        get{return _quantidadeesto;}
        set{_quantidadeesto = value;}
    }
    private decimal _precounit;
    public decimal PrecoUnit
    {
        get{return _precounit;}
        set{_precounit = value;}
    }

    public void ExibirProduto()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Preço: {PrecoUnit} R$");
        Console.WriteLine($"Quantidade em estoque: {QuantidadeEstoq}");
    }

    public void AdicionarEstoque(int quanti)
    {
        Console.WriteLine($"Estoque atual: {QuantidadeEstoq}");
            if(quanti <= 0)
        {
            Console.WriteLine("Valor Invalido");
            return;
        }
        QuantidadeEstoq += quanti;
        Console.WriteLine($"Novo estoque: {QuantidadeEstoq}");
    }
    public void RetirarEstoque(int quant)
    {
        Console.WriteLine($"Estoque atual: {QuantidadeEstoq}"); 
            if(quant > QuantidadeEstoq || quant <= 0)
        {
            Console.WriteLine("Quantidade indisponivel");
            return;
        }
        QuantidadeEstoq -= quant;
        Console.WriteLine($"Estoque atual: {QuantidadeEstoq}");
    }
}