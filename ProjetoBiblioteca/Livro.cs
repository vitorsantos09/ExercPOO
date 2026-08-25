enum GeneroLivro
{
    Aventura,
    FiccaoCientifica,
    Acao,
    SuperHeroi,
    Suspense,
    Terror,
    Manga,
    HQ,
    Romance,
    Biografia
}
enum ClassificacaoIndicativa
{
    Livre,
    DezAnos,
    DozeAnos,
    QuatorzeAnos,
    DezesseisAnos,
    DezoitoAnos
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