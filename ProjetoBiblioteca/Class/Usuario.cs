class Usuario : Pessoa
{
    public int Idade{get; set;}
    
    public Usuario(string nome, string email, string telefone,string cpf, int idade) : base(nome, email, telefone, cpf)
    {
        this.Idade = idade;
    }
}