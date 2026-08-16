Alunos[] alunosvet = new Alunos[10];
Alunos aux = new();
int quantidade = 0; // controlador da quantidade de alunos cadastrados
string Busca;
int op;
do
{
   
    Console.WriteLine("==================================");
    Console.WriteLine("Bem vindo ao cadastro de Alunos!!");
    Console.WriteLine("1. Cadastrar Aluno");
    Console.WriteLine("2. Listar Alunos");
    Console.WriteLine("3. Buscar Aluno");
    Console.WriteLine("4. Media da turma");
    Console.WriteLine("5. Sair");
    
        op = Convert.ToInt16(Console.ReadLine()!);
    switch (op)
    {
        case 1: 
         if(quantidade >= 10)
            {
                Console.WriteLine("Turma Lotada pai");
            }
            else
            {
        Alunos aluno = new Alunos();
            Console.WriteLine("Digite o nome do aluno: ");
                aluno.Nome = Console.ReadLine()!.ToUpper();
            Console.WriteLine("Digite a primeira nota do aluno: ");
                aluno.Nota1 = decimal.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite a segunda nota do aluno: ");
                aluno.Nota2 = decimal.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite a terceira nota do aluno: ");
                aluno.Nota3 = decimal.Parse(Console.ReadLine()!);
                Console.WriteLine("==================================");
                alunosvet[quantidade] = aluno; // Vetor referencia ao objeto, quantidade armazena o valor de aluno cadastrado, não deixando apontar para a mesma posição do vetor
                    quantidade++;
            }
        break;
        case 2:
            aux.Listagem(quantidade,alunosvet); // variavel auxiliar chama a classe Alunos, tendo acesso ao metodo Listagem
        break;
        case 3: 
        bool find = false; // inicializa a variavel booleana de procurar em false, pois não encntrou nada ainda, após o metodo ser chamado novamente, vira false denovo para começar uma nova busca
        Console.WriteLine("Qual aluno deseja buscar? ");
            Busca = Console.ReadLine()!;
            for(int i = 0; i < quantidade; i++)
            {
                if(Busca == alunosvet[i].Nome)
                {
                    Console.WriteLine("Aluno encontrado");
                Console.WriteLine($"Aluno {i + 1}. {alunosvet[i].Nome}");
                Console.WriteLine($"Media {alunosvet[i].CalcularMedia()}");
                Console.WriteLine($"Situação {alunosvet[i].Situacao()}");
                Console.WriteLine("==================================");
                    find = true; // Se procurou e encontrou, então find vira true e a iteraçaõ para
                    break;
                }
            }
                if(!find){
                Console.WriteLine("Aluno não cadastrado");
                }
            break;

    
        case 4:
        decimal SomaMed = 0;
        if(quantidade == 0)
            {
                Console.WriteLine("Não há alunos cadastrados");
            }
            else{
    for(int i = 0; i < quantidade; i++){
        SomaMed += alunosvet[i].CalcularMedia();
        }
        decimal MedTurma = SomaMed / quantidade;
            Console.WriteLine($"Media da turma : {MedTurma}");
            }
        break;
    }
    } while(op != 5);
    Console.WriteLine("Obrigado por usar o programa");
    Console.ReadKey();
