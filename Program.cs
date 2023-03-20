using System;
using System.Collections.Generic;

class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
}

class Program
{
    static List<Pessoa> pessoas = new List<Pessoa>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("*------------MENU-----------*");
            Console.WriteLine("[1] Cadastrar pessoa");
            Console.WriteLine("[2] Listar pessoas");
            Console.WriteLine("[3] Atualizar pessoa");
            Console.WriteLine("[3] Excluir pessoa");
            Console.WriteLine("[99] Sair");
            Console.WriteLine("*------------MENU-----------*");

            Console.Write("\nDigite a opção desejada: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarPessoa();
                    break;
                case "2":
                    ListarPessoas();
                    break;
                case "3":
                    AtualizarPessoa();
                    break;
                case "4":
                    ExcluirPessoa();
                    break;
                case "99":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nOpção inválida\n");
                    break;
            }
        }
    }

    static void CadastrarPessoa()
    {
        Console.WriteLine("\nCadastro de pessoa:");

        Pessoa pessoa = new Pessoa();

        Console.Write("Nome: ");
        pessoa.Nome = Console.ReadLine();

        Console.Write("Telefone: ");
        pessoa.Telefone = Console.ReadLine();

        pessoa.Id = pessoas.Count + 1;

        pessoas.Add(pessoa);

        Console.Clear();
        Console.WriteLine("\nPessoa cadastrada com sucesso!\n");
    }

    static void ListarPessoas()
    {
        if (pessoas.Count == 0)
        {
            Console.WriteLine("Não há pessoas cadastradas.");
            return;
        }

        Console.WriteLine("\nLista de pessoas cadastradas:");
        foreach (Pessoa pessoa in pessoas)
        {
            Console.WriteLine($"ID: {pessoa.Id}, Nome: {pessoa.Nome}, Telefone: {pessoa.Telefone}");
        }
    }

    static void AtualizarPessoa()
    {
        Console.WriteLine("Digite o ID da pessoa que deseja atualizar:");
        int id = int.Parse(Console.ReadLine());

        Pessoa pessoa = BuscarPessoaID(id);

        if (pessoa == null)
        {
            Console.WriteLine("Pessoa não encontrada.");
        }
        else
        {
            Console.WriteLine("Digite o novo nome da pessoa:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o novo número de telefone da pessoa:");
            string telefone = Console.ReadLine();

            pessoa.Nome = nome;
            pessoa.Telefone = telefone;

            Console.Clear();
            Console.WriteLine("Dados atualizados com sucesso!");
        }
    }

    static void ExcluirPessoa()
    {
        Console.WriteLine("Digite o ID da pessoa que deseja excluir:");
        int id = int.Parse(Console.ReadLine());

        Pessoa pessoa = BuscarPessoaID(id);

        if (pessoa == null)
        {
            Console.WriteLine("Pessoa não encontrada.");
        }
        else
        {
            pessoas.Remove(pessoa);
            Console.Clear();
            Console.WriteLine("Pessoa excluída com sucesso!");
        }
    }

    static Pessoa BuscarPessoaID(int id)
    {
        foreach (Pessoa pessoa in pessoas)
        {
            if (pessoa.Id == id)
            {
                return pessoa;
            }
        }
        return null;
    }
}
