using System.Collections;

Livros[] vetlivros = new Livros[10];
int op;
int quantidade = 0;
string BuscaLivro;

do
{
    Console.WriteLine("==================================");
    Console.WriteLine("     Sistema de biblioteca      ");
    Console.WriteLine("==================================");
    Console.WriteLine("1. Cadastrar Livro");
    Console.WriteLine("2. Listar livros");
    Console.WriteLine("3. Buscar livros");
    Console.WriteLine("4. Pegar livro emprestado");
    Console.WriteLine("5. Devolver Livro");
    Console.WriteLine("6. Sair da biblioteca");
        op = Convert.ToInt16(Console.ReadLine()!);

    switch (op)
    {
        case 1: //Cadastro
        if(quantidade < 10){
        Livros livro = new();
            Console.WriteLine("Digite o titulo do livro");
                livro.Titulo = Console.ReadLine()!.ToUpper();
            Console.WriteLine("Digite o nome do autor do livro");
                livro.Autor = Console.ReadLine()!.ToUpper();
                livro.Disponibilidade = true; // inicializa a disponibilidade em true
            vetlivros[quantidade] = livro;
            quantidade++;
        }
            else
            {
                Console.WriteLine("Biblioteca cheia");
            }
        break;


        case 2: //Listagem
        for(int i = 0; i < quantidade; i++)
            {
                vetlivros[i].ExibeLivro();
            }
            break;


        case 3: //Busca de Livro
        
        Console.WriteLine("Qual o titulo do livro que deseja buscar: ");
            BuscaLivro = Console.ReadLine()!.ToUpper(); // Variavek busca livro guarda o input para ser comparada dentro do metodo buscarLivro
         Livros? livroEncontrado = BuscarLivro(quantidade,vetlivros,BuscaLivro); // Variavel livroEncontrado recebe o objeto de retorno do metodo BuscarLivro, passando o vetor, controler e input como parametro 
            if(livroEncontrado != null){ // Se o retorno do metodo não for nulo, ou seja, se o metodo encontrar, chama o metodo exibe livro 
                    livroEncontrado.ExibeLivro(); //variavel que recebeu o objeto do metodo BuscarLivro, referencia o metodo ExibeLivro 
                    break;
            }
            else{            
             Console.WriteLine("Livro não encontrado");
             break;
            }
            
        case 4:
        Console.WriteLine("Qual o titulo do livro que deseja pegar emprestado: ");
            BuscaLivro = Console.ReadLine()!.ToUpper();
            Livros? livroEncontradoEmp = BuscarLivro(quantidade, vetlivros,BuscaLivro);
             if(livroEncontradoEmp != null){
                    livroEncontradoEmp.Emprestimo();
                    break;
             }
            else
            {
                Console.WriteLine("não realizado");
                break;
            }
        case 5:
         Console.WriteLine("Qual o titulo do livro que deseja devolver: ");
            BuscaLivro = Console.ReadLine()!.ToUpper();
            Livros? livroEncontradoDev = BuscarLivro(quantidade, vetlivros,BuscaLivro);
             if(livroEncontradoDev != null){
                    livroEncontradoDev.Devolver();
                    break;
             }
            else
            {
                Console.WriteLine("não realizado");
                break;
            }
            case 6: 
            Console.WriteLine("Obrigado por usar a biblioteca");
            break;
    }
    
}while(op != 6);


    static Livros? BuscarLivro(int quanti, Livros[] vetorlivros,string buscandolivro)
{
    
            for(int i = 0; i < quanti; i++)
            {
                if(vetorlivros[i].Titulo == buscandolivro)
                {
                return vetorlivros[i]; // percorre as posições do vetor até a quantidade e se o titulo for o mesmo do titulo user, retorna a posição do vetor
                }
            }
            return null; //Se o livro não for encontrado, a variavel boolena continua em false;
}