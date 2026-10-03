using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBiblioteca.Class;
using ProjetoBiblioteca.Enums;
using ProjetoBiblioteca.Abstract;
using ProjetoBiblioteca;

namespace ProjetoBiblioteca
{
    class Menus // Controle de interação 
    {
        // Metodos staticos, pois a classe não possui atributos (apenas o opcao), apenas métodos de interação com o usuário.
        public static void MenuAdmin(Sistema sistemabi, Administrador admin)
        {
            bool logado = true;
            string buscaLivro;
            string BuscaCPF;
            int opcao;
            do
            {
                Console.WriteLine("==================================");
                Console.WriteLine($"Ola Administrador! {admin.Nome}");
                Console.WriteLine("");
                Console.WriteLine("Digite a opção desejada: ");
                Console.WriteLine("1. Cadastrar tipo de Pessoa");
                Console.WriteLine("2. Cadastrar Livros");
                Console.WriteLine("3. Listagem");
                Console.WriteLine("4. Buscar Livro");
                Console.WriteLine("5. Realizar Emprestimo");
                Console.WriteLine("6. Realizar Devolução");
                Console.WriteLine("7. Listar Historicos de Emprestimos");
                Console.WriteLine("8. Logout");
                Console.WriteLine("0. Sair");
                Console.WriteLine("==================================");
                if (int.TryParse(Console.ReadLine(), out opcao))
                     
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("");
                            Console.WriteLine("==================================");
                            Console.WriteLine("1. Cadastrar Usuario");
                            Console.WriteLine("2. Cadastrar Bibliotecario[a]");
                            Console.WriteLine("3. Cadastrar Administrador[a]");
                            Console.WriteLine("==================================");
                            if (int.TryParse(Console.ReadLine(), out int opCad))
                            {
                                Cadastrar(out string nome, out string cpf, out string email, out string telefone); // Passa o objeto do sistema bi para o menu, para quando o menu precisar dele, o proprio menu pode fazer o processo

                                if (sistemabi.VerificarCpf(cpf))
                                {
                                    Console.WriteLine("Cpf ja cadastrado, tente novamente");
                                    break;
                                }
                                else
                                {

                                    switch (opCad)
                                    {

                                        case 1:
                                            Console.WriteLine($"Digite a data de nascimento do {nome}: ");
                                            DateTime datanasc = DateTime.Parse(Console.ReadLine()!);
                                            sistemabi.CadastrarUsuario(nome, email, telefone, cpf, datanasc);
                                            Console.WriteLine("Pessoa Cadastrada! ");
                                            break;
                                        case 2:
                                            Console.WriteLine("Digite a matricula do bibliotecario: ");
                                            int matricula = int.Parse(Console.ReadLine()!);
                                            sistemabi.CadastrarBibliotecario(nome, email, telefone, cpf, matricula);
                                            Console.WriteLine("Pessoa Cadastrada! ");
                                            break;
                                        case 3:
                                            Console.WriteLine("Digite a matricula do Administrador: ");
                                            int matriculaAdmin = int.Parse(Console.ReadLine()!);
                                            sistemabi.CadastrarAdministrador(nome, email, telefone, cpf, matriculaAdmin);
                                            Console.WriteLine("Pessoa Cadastrada! ");
                                            break;

                                        default:
                                            Console.WriteLine("Digite um valor valido");
                                            break;
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("Digite um valor valido");
                            }
                            Console.Clear();
                            break;
                        case 2:
                            CadFrontLivro(out string nomeLivro, out ClassificacaoIndicativa classificacao, out GeneroLivro genero); //Declara as variaveis e faz a chamada no out para serem preenchidas no Metodo e retornarem para essa chamada
                            sistemabi.CadastrarLivro(nomeLivro, classificacao, genero);
                            Console.WriteLine("Livro Cadastrado com sucesso!");
                            Console.WriteLine("");
                            break;
                        case 3:
                            Console.WriteLine("");
                            Console.WriteLine("1. Listar pessoas");
                            Console.WriteLine("2. Listar livros");
                            Console.WriteLine("3. Listar livros Disponiveis");
                            Console.WriteLine("4. Listar emprestimos ativos");
                            if (int.TryParse(Console.ReadLine(), out int opList))
                            {
                                switch (opList)
                                {
                                    case 1:
                                        sistemabi.ListarPessoas();
                                        break;
                                    case 2:
                                        sistemabi.ListarLivros();
                                        break;
                                    case 3:
                                        sistemabi.ListarDisponiveis();
                                        break;
                                    case 4:
                                        sistemabi.ListarEmpAtivos();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Digite um valor valido");
                            }
                            break;
                        case 4:
                            Console.WriteLine("==========================================");
                            Console.WriteLine("Digite o nome do livro que deseja buscar: ");
                            buscaLivro = Console.ReadLine()!.ToUpper();
                            Livro? encontrado = sistemabi.BuscarLivro(buscaLivro);
                            if (encontrado != null)
                            {
                                Console.WriteLine("");
                                Console.WriteLine(encontrado.Nome);
                                Console.WriteLine(encontrado.Genero);
                                Console.WriteLine(encontrado.Classificacao);
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("Livro não encontrado");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Qual o cpf do usuario que deseja realizar o emprestimo: ");
                            BuscaCPF = Console.ReadLine()!;
                            Usuario? user = sistemabi.BuscarUsuario(BuscaCPF);
                            Console.WriteLine("Qual o nome do livro que deseja pegar emprestado: ");
                            buscaLivro = Console.ReadLine()!.ToUpper();
                            if (user != null)
                            {
                                string resultado = sistemabi.RealizarEmprestimo(user, buscaLivro);
                                Console.WriteLine(resultado);
                            }
                            else
                            {
                                Console.WriteLine("Usuário não encontrado");
                            }
                            break;
                        case 6:
                            Console.WriteLine("Qual o cpf do usuario que deseja efetuar a devolução: ");
                            BuscaCPF = Console.ReadLine()!;
                            Console.WriteLine("Qual o nome do livro que deseja devolver: ");
                            buscaLivro = Console.ReadLine()!.ToUpper();
                            string situacao = sistemabi.RealizarDevolução(BuscaCPF, buscaLivro);
                            Console.WriteLine($"o livro {buscaLivro} {situacao}");
                            break;
                        case 7:
                            sistemabi.ListHistorico();
                            break;
                        case 8:
                            Console.WriteLine("Você deseja dar logout da conta? [sim/nao]");
                            string resposta = Console.ReadLine()!.ToUpper();
                            if (resposta == "SIM")
                            {
                                logado = false;
                                Console.WriteLine(" Logout Realizado ");
                            }
                            break;
                    }


                }
                else
                {
                    Console.WriteLine("Digite um valor valido");
                }

            } while (opcao != 0 && logado);
        }


        public static void MenuUser(Sistema sistemabi, Usuario user)
        {
            bool logado = true;
            int opcao;
            string buscaLivro;
            do
            {
                Console.WriteLine("==================================");
                Console.WriteLine($"Ola Usuario! {user!.Nome}");
                Console.WriteLine("1. Listagem");
                Console.WriteLine("2. Buscar Livro");
                Console.WriteLine("3. Solicitar Emprestimo");
                Console.WriteLine("4. Realizar Devolução");
                Console.WriteLine("5. Logout");
                Console.WriteLine("0. Sair");
                Console.WriteLine("==================================");
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("");
                            Console.WriteLine("1. Listar livros");
                            Console.WriteLine("2. Listar livros Disponiveis");
                            Console.WriteLine("");
                            if (int.TryParse(Console.ReadLine(), out int opList))
                            {
                                switch (opList)
                                {
                                    case 1:
                                        sistemabi.ListarLivros();
                                        break;
                                    case 2:
                                        sistemabi.ListarDisponiveis();
                                        break;
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Digite o nome do livro que deseja buscar: ");
                            buscaLivro = Console.ReadLine()!.ToUpper();
                            Livro? encontrado = sistemabi.BuscarLivro(buscaLivro);

                            if (encontrado != null)
                            {

                                Console.WriteLine(encontrado.Nome);
                                Console.WriteLine(encontrado.Genero);
                                Console.WriteLine(encontrado.Classificacao);
                            }
                            else
                            {
                                Console.WriteLine("Livro não encontrado");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Qual o nome do livro que deseja solicitar emprestimo: ");
                            string solicitaLivro = Console.ReadLine()!.ToUpper();
                            Console.WriteLine("");
                            if (user != null)
                            {
                                sistemabi.SolicitarEmprestimo(user, solicitaLivro);
                            }
                            else
                            {
                                Console.WriteLine("não encontrado");
                            }
                            break;
                        case 4:
                            string BuscaCPF = user.Cpf!;
                            Console.WriteLine("Qual o nome do livro que deseja devolver: ");
                            buscaLivro = Console.ReadLine()!.ToUpper();
                            string situacao = sistemabi.RealizarDevolução(BuscaCPF, buscaLivro);
                            Console.WriteLine($"o livro {buscaLivro} {situacao}");
                            break;
                        case 5:
                            Console.WriteLine("Você deseja dar logout da conta? [sim/nao]");
                            string resposta = Console.ReadLine()!.ToUpper();
                            if (resposta == "SIM")
                            {
                                logado = false;
                                Console.WriteLine("");
                                Console.WriteLine(" Logout Realizado ");
                            }
                            break;
                    }
                }
            } while (opcao != 0 && logado);
        }
        public static void MenuBibliotecario(Sistema sistemabi, Bibliotecario bibliotecario)
        {
            bool logado = true;
            int opcao;
            string buscaLivro;
            do
            {
                Console.WriteLine("==================================");
                Console.WriteLine($"Ola Bibliotecario! {bibliotecario.Nome}");
                Console.WriteLine("Digite a opção desejada: ");
                Console.WriteLine("1. Cadastrar Livros");
                Console.WriteLine("2. Tipos de listagem");
                Console.WriteLine("3. Buscar Livro");
                Console.WriteLine("4. Analisar pedidos de emprestimo");
                Console.WriteLine("5. Logout");
                Console.WriteLine("0. Sair");
                Console.WriteLine("==================================");
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Digite um valor valido");
                }
                else
                {
                    switch (opcao)
                    {
                        case 1:
                            CadFrontLivro(out string nomeLivro, out ClassificacaoIndicativa classificacao, out GeneroLivro genero); //Declara as variaveis e faz a chamada no out para serem preenchidas no Metodo e retornarem para essa chamada
                            sistemabi.CadastrarLivro(nomeLivro, classificacao, genero);
                            Console.WriteLine("Livro Cadastrado com sucesso!");
                            break;
                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("1. Listar livros");
                            Console.WriteLine("2. Listar livros Disponiveis");
                            Console.WriteLine("3. Listar emprestimos ativos");
                            Console.WriteLine("");
                            if (int.TryParse(Console.ReadLine(), out int opList))
                            {
                                switch (opList)
                                {
                                    case 1:
                                        sistemabi.ListarLivros();
                                        break;
                                    case 2:
                                        sistemabi.ListarDisponiveis();
                                        break;
                                    case 3:
                                        sistemabi.ListarEmpAtivos();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Digite um valor valido");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Digite o nome do livro que deseja buscar: ");
                            buscaLivro = Console.ReadLine()!.ToUpper();
                            Livro? encontrado = sistemabi.BuscarLivro(buscaLivro);
                            if (encontrado != null)
                            {
                                Console.WriteLine(encontrado.Nome);
                                Console.WriteLine(encontrado.Genero);
                                Console.WriteLine(encontrado.Classificacao);
                            }
                            else
                            {
                                Console.WriteLine("Livro não encontrado");
                            }
                            break;
                        case 4:
                            Console.WriteLine("");
                            Console.WriteLine("1. Listar pedidos pendentes");
                            Console.WriteLine("2. Aprovar solicitação");
                            Console.WriteLine("3. Reprovar solicitação");
                            Console.WriteLine("");
                            if (!int.TryParse(Console.ReadLine(), out int opSolicitacao))
                            {
                                Console.WriteLine("Digite um valor valido");
                            }
                            else
                            {
                                switch (opSolicitacao)
                                {
                                    case 1:
                                        sistemabi.ListarSolicitacoes();
                                        break;
                                    case 2:
                                        Console.WriteLine("Digite o cpf do usuario que deseja aprovar a solicitação: ");
                                        string cpfAprovar = Console.ReadLine()!;
                                        Console.WriteLine("Digite o nome do livro que deseja aprovar a solicitação: ");
                                        string livroAprovar = Console.ReadLine()!.ToUpper();
                                        sistemabi.AprovarSolicitacao(cpfAprovar, livroAprovar);
                                        break;
                                    case 3:
                                        Console.WriteLine("Digite o cpf do usuario que deseja reprovar a solicitação: ");
                                        string cpfReprovar = Console.ReadLine()!;
                                        Console.WriteLine("Digite o nome do livro que deseja reprovar a solicitação: ");
                                        string livroReprovar = Console.ReadLine()!.ToUpper();
                                        sistemabi.ReprovarSolicitacao(cpfReprovar, livroReprovar);
                                        break;
                                }
                            }
                            break;
                        case 5:
                            Console.WriteLine("Você deseja dar logout da conta? [sim/nao]");
                            string resposta = Console.ReadLine()!.ToUpper();
                            if (resposta == "SIM")
                            {
                                logado = false;
                                Console.WriteLine(" Logout Realizado ");
                            }
                            break;
                    }
                }
            } while (opcao != 0 && logado);
        }

        public static void Cadastrar(out string nome, out string cpf, out string email, out string telefone)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Digite o nome do individuo: ");
            nome = Console.ReadLine()!.ToUpper();
            Console.WriteLine($"Digite o Cpf do/a {nome}: ");
            cpf = Console.ReadLine()!.ToUpper();
            Console.WriteLine($"Digite o email do/a {nome}: ");
            email = Console.ReadLine()!.ToLower();
            Console.WriteLine($"Digite o telefone do/a {nome}: ");
            telefone = Console.ReadLine()!;
        }
        public static void CadFrontLivro(out string nomeLivro, out ClassificacaoIndicativa classificacao, out GeneroLivro genero)
        {
            bool sucessoGen;
            bool sucessoClass;

            Console.WriteLine("===============================");
            Console.WriteLine("Digite o nome do Livro: ");
            nomeLivro = Console.ReadLine()!.ToUpper();
            Console.WriteLine($"Digite a classificação indicativa do livro: {nomeLivro}: ");
            foreach (ClassificacaoIndicativa classi in Enum.GetValues<ClassificacaoIndicativa>()) //Percorre todos o valores do enumeradores, primeiro converte os valores para inteiro, depois mostra as opções 
            {
                Console.WriteLine($"{(int)classi} - {classi}");
            }
            Console.WriteLine("");

            do //Verificação e converter a escolha do usuario para opção valida do enum
            {
                sucessoClass = (Enum.TryParse(Console.ReadLine()!, ignoreCase: true, out classificacao) && Enum.IsDefined(typeof(ClassificacaoIndicativa), classificacao));
                if (!sucessoClass)
                {
                    Console.WriteLine("Valor inválido ou não definido.");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Sucesso: {classificacao}");

                }
            } while (!sucessoClass);

            Console.WriteLine("");
            Console.WriteLine($"Digite o genero do {nomeLivro}: ");
            foreach (GeneroLivro generoL in Enum.GetValues<GeneroLivro>())
            {
                Console.WriteLine($"{(int)generoL} - {generoL}");
            }


            do //Verificação e converter a escolha do usuario para opção valida do enum
            {
                sucessoGen = (Enum.TryParse(Console.ReadLine()!, ignoreCase: true, out genero) && Enum.IsDefined(typeof(GeneroLivro), genero));
                if (!sucessoGen)
                {
                    Console.WriteLine("Valor inválido ou não definido.");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Sucesso: {genero}");
                }
            } while (!sucessoGen);
        }
    }
}