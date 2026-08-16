
class Aluno{
private string? _nome;
public string? Nome
    {
        get{return _nome;}
        set{_nome = value;}
    }
private decimal _nota1;
public decimal Nota1
    {
        get{return _nota1;}
        set{_nota1 = value;}
    }
private decimal _nota2;
    public decimal Nota2
    {
        get{return _nota2;}
        set{_nota2 = value;}
    }
    private decimal _nota3;
    public decimal Nota3
    {
        get{return _nota3;}
        set{_nota3 = value;}
    }
    
    public void ExibirAluno()
    {
        Console.WriteLine("==============");
            Console.WriteLine(Nome);
            Console.WriteLine(Nota1);
            Console.WriteLine(Nota2);
            Console.WriteLine(Nota3);
        Console.WriteLine("===============");
    }
    public decimal CalculaMedia()
    {
        return (Nota1 + Nota2 + Nota3) / 3;
    }
    public string Situacao()
    {
        if(CalculaMedia() >= 6)
        {
            return "Aprovado";
        }
        else
        {
            return "Reprovado";
        }
    }
    public void MostraBoletim()
    {
        Console.WriteLine("==============================");
        Console.WriteLine($"Aluno : {Nome}");
        Console.WriteLine($"Media : {CalculaMedia()}");
        Console.WriteLine($"Situação : {Situacao()}");
    }
    public void VerificaNota()
    {
        if(Nota1 < 0 || Nota1 > 10)
        {
            return;
        }
        else if(Nota2 < 0 || Nota2 > 10)
        {
            return;
        }
        else if(Nota3 < 0 || Nota3 > 10)
        {
            return;
        }
    }
}