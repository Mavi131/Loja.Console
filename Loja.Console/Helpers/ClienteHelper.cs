using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;

namespace Projeto_POO.Helpers;

internal static class ClienteHelper
{
    public static void Cadastrar()
    {
        var cliente = new Cliente();
        MenuHelper.CriarCabecalho("CADASTRO DE CLIENTES");
        Write(" Código:     ");
        cliente.Id = Convert.ToInt32(ReadLine());
        Write(" Nome:       ");
        cliente.Nome = ReadLine();
        Write(" CPF:        ");
        cliente.Cpf = ReadLine();
        Write(" Celular:    ");
        cliente.Celular = ReadLine();
        Write(" Email:      ");
        cliente.Email = ReadLine();
        MenuHelper.CriarLinha();
        LojaContext.Clientes.Add(cliente);
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuCliente();
    }

    public static void Listar()
    {
        MenuHelper.CriarCabecalho("LISTA DE CLIENTES");
        if (LojaContext.Clientes.Count == 0)
        {
            WriteLine(" Nenhum cliente cadastrado.");
        }
        else
        {
            foreach (var cliente in LojaContext.Clientes)
            {
                WriteLine(" " + cliente);
            }
        }
        MenuHelper.CriarLinha();
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuCliente();
    }

    public static void Editar()
    {
        MenuHelper.CriarCabecalho("EDITAR CLIENTE");
        Write(" Informe o código do cliente: ");
        int codigo = Convert.ToInt32(ReadLine());
        var cliente = LojaContext.Clientes.FirstOrDefault(c => c.Id == codigo);

        if (cliente == null)
        {
            WriteLine(" Cliente não encontrado.");
        }
        else
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Nome Atual: {cliente.Nome}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo Nome:     ");
            var nome = ReadLine();
            if (!string.IsNullOrEmpty(nome))
                cliente.Nome = nome;

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n CPF Atual: {cliente.Cpf}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo CPF:      ");
            var cpf = ReadLine();
            if (!string.IsNullOrEmpty(cpf))
                cliente.Cpf = cpf;

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Celular Atual: {cliente.Celular}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo Celular:  ");
            var celular = ReadLine();
            if (!string.IsNullOrEmpty(celular))
                cliente.Celular = celular;

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Email Atual: {cliente.Email}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo Email:    ");
            var email = ReadLine();
            if (!string.IsNullOrEmpty(email))
                cliente.Email = email;

            WriteLine("\n Cliente atualizado com sucesso.");
        }
        MenuHelper.CriarLinha();
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuCliente();
    }

    public static void Excluir()
    {
        MenuHelper.CriarCabecalho("EXCLUIR CLIENTE");
        Write(" Informe o código do cliente: ");
        int codigo = Convert.ToInt32(ReadLine());
        var cliente = LojaContext.Clientes.FirstOrDefault(c => c.Id == codigo);

        if (cliente == null)
        {
            WriteLine(" Cliente não encontrado.");
        }
        else
        {
            WriteLine(" \n Deseja realmente excluir");
            WriteLine(" " + cliente);
            Write(" [S] Sim / [N] Não: ");
            var opcao = ReadLine()?.ToUpper();
            if (opcao == "S")
            {
                LojaContext.Clientes.Remove(cliente);
                WriteLine(" Cliente excluído com sucesso.");
            }
        }
        MenuHelper.CriarLinha();
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuCliente();
    }
}