class Livros
{
    private string? _titulo;
    private bool _disponibilidade; //campo privado para guardar o estado de disponibilidade
    public bool Disponibilidade //propriedade public para acesso de valor
    {
        get{return _disponibilidade;}
        set{_disponibilidade = value;}
    }
    public string? Titulo
    {
        get{return _titulo;}
        set{_titulo = value;}
    }
    private string? _autor; 
    public string? Autor
    {
        get{return _autor;}
        set{_autor = value;}
    }

    public void ExibeLivro()
    {
        Console.WriteLine("==================================");
            Console.WriteLine($"Titulo: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
             if(Disponibilidade == true)
        {
            Console.WriteLine($"Situação: Disponivel bb");
             Console.WriteLine("==================================");
        }
        else{
            Console.WriteLine($"Situação: indisponivel infelizmente");
             Console.WriteLine("==================================");
        }
       
    }   
    public void Emprestimo() //Metodo altera o estado do proprio objeto
    {
        if (Disponibilidade)
        {
            Disponibilidade = false;
            Console.WriteLine("Emprestimo realizado");
        }
        else
        {
            Console.WriteLine("Emprestimo não realizado");
        }
    }
    public void Devolver(){
        if(!Disponibilidade)
        {
            Disponibilidade = true;
            Console.WriteLine("Livro devolvido");
        }
        else
        {
            Console.WriteLine("Livro ja está disponivel");
        }

    }
}