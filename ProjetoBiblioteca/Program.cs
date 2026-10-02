using ProjetoBiblioteca.Class;
using ProjetoBiblioteca.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {

            Sistema sistemabi = new();
            sistemabi.CadastrarAdministrador("ADMIN", "admin@email.com", "11999999999", "00000000000", 00001); //Cadastra um administrador padrão, apenas para teste
            bool execute = true;

            do
            {

                Console.WriteLine("==================================");
                Console.WriteLine("     Sistema de biblioteca      ");
                Console.WriteLine("==================================");
                Console.WriteLine("Digite seu cpf ou 0 para sair: ");
                string cpf = Console.ReadLine()!;
                if (cpf == "0")
                {
                    execute = false;
                    break;
                }
                Pessoa? pessoaLogada = sistemabi.BuscarPes(cpf);
                if (pessoaLogada != null)
                {
                    switch (pessoaLogada)
                    {
                        case Administrador admin:
                            Console.WriteLine("");
                            Console.WriteLine(" Login do administrador realizado com sucesso!");
                            Menus.MenuAdmin(sistemabi, admin); //Chama o metodo da classe menus, tendo em vista que o metodo é static, então não precisa instanciar a classe menus, apenas chamar o metodo diretamente
                            break;
                        case Bibliotecario bibliotecario:
                            Console.WriteLine("");
                            Console.WriteLine(" Login do bibliotecario realizado com sucesso!");
                            Menus.MenuBibliotecario(sistemabi, bibliotecario);
                            break;
                        case Usuario usuario:
                            Console.WriteLine("");
                            Console.WriteLine(" Login do usuario realizado com sucesso!");
                            Menus.MenuUser(sistemabi, usuario);
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Não existe pessoa cadastrada com esse cpf");

                }
            } while (execute);
        }
    }
}
