using System.Dynamic;

class Retangulos
{
    public double Altura;
    public double Base;


    public double CalcularArea(){
        return Altura * Base;
    }
    public double CalcularPerimetro()
    {
        return 2*(Altura + Base);
    }
    public void MostrarDados()
    {
        Console.WriteLine($"Altura é {Altura}");
        Console.WriteLine($"Base é {Base}");
    }
}