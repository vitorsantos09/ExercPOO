class Alunos
{
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
    
    
    public decimal CalcularMedia()
    {
        decimal Media = 0;
        Media = (Nota1 + Nota2 + Nota3) / 3;

        return Media;
    }
    public string Situacao()
    {
        
        if(CalcularMedia() >= 6)
        {
            return "Aprovado";
        }
        else
        {
            return "Reprovado";
        }
    }
    public void Listagem(int quant, Alunos[] vetalunos)
    {
        for(int i = 0; i < quant; i++) //Lista os alunos começando do indice 0 e varre até o numero de alunos em quantidade
            {
                Console.WriteLine($"Aluno {i + 1}. {vetalunos[i].Nome}");
                Console.WriteLine($"Media {vetalunos[i].CalcularMedia()}");
                Console.WriteLine($"Situação {vetalunos[i].Situacao()}");
                Console.WriteLine("==================================");
            } 
    }
}