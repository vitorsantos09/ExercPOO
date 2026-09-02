class Bibliotecario : Pessoa//Bibliotecario vai implementar todos os metodos que a interface fornecer
{
    public string? Matricula{get; private set;} //Ninguem fora de pessoa consegue alterar
    public Bibliotecario(string nome, string email, string telefone, string cpf, string matricula) : base(nome, email, telefone, cpf)
    {
        this.Matricula = matricula;
    }
}