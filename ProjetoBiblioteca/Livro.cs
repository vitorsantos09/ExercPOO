enum GeneroLivro
{
    Aventura = 1,
    FiccaoCientifica = 2,
    Acao = 3,
    SuperHeroi = 4,
    Suspense = 5,
    Terror = 6,
    Manga = 7,
    HQ = 8,
    Romance = 9,
    Biografia = 10
}
enum ClassificacaoIndicativa
{
    Livre = 0,
    DezAnos = 10,
    DozeAnos = 12,
    QuatorzeAnos = 14,
    DezesseisAnos = 16,
    DezoitoAnos = 18
}
class Livro
{
    public string? Nome{get; private set;}

    public ClassificacaoIndicativa Classificacao{get;set;} // Declara o enumerador como propriedade da classe Livro
    public GeneroLivro Genero{get;set;}
    public bool Disponivel{get;private set;} = true; //inicia o estado do livro como disponivel

    public Livro(string nome, ClassificacaoIndicativa classificacao, GeneroLivro genero)
    {
        this.Nome = nome;
        this.Classificacao = classificacao;
        this.Genero = genero;
    }
    public void Emprestar()
    {
        if(!Disponivel)
        {
            return;
        }
        else
        {
            Disponivel = false;
        }
    }
    public void Devolver()
    {
        if(Disponivel)
        {
            return;
        }
        else
        {
            Disponivel = true;
        }
    }
}