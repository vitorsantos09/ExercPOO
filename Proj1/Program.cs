// instancia do obj e criaçaõ do vetor da classe
    Retangulos retangulo = new();
    double Area = 0;
    double Perimetro = 0;
    
        Console.WriteLine("Digite a Altura do retangulo");
            retangulo.Altura = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Digite a Base do retangulo");
            retangulo.Base = double.Parse(Console.ReadLine()!);
             Area = retangulo.CalcularArea();
             Perimetro = retangulo.CalcularPerimetro();
    
    Console.WriteLine("========================================");

    retangulo.MostrarDados();
    Console.WriteLine($"A area do retângulo é = {Area} e seu Perimetro = {Perimetro}");
    