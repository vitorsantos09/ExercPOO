class Administrador : Pessoa
{
    public string? Matricula_admin{get; private set;}
    public Administrador(string nome, string email, string telefone, string cpf, string matriculaAdmin) : base(nome, email, telefone, cpf)
    {
        this.Matricula_admin = matriculaAdmin;
    }
}