﻿using Loja.Shared.Contexts;
using static System.Console;

namespace Projeto_POO.Helpers;

internal class MenuHelper
{
    public static void CriarLinha()
    {
        WriteLine("--------------------------------------------------------------");
    }

    public static void CriarCabecalho(string titulo)
    {
        ForegroundColor = ConsoleColor.White;
        Clear();
        CriarLinha();
        ForegroundColor = ConsoleColor.Red;
        WriteLine($" {titulo.ToUpper()}");
        ForegroundColor = ConsoleColor.White;
        CriarLinha();
    }

    public static void MenuPrincipal()
    {
        CriarCabecalho("Loja Mavi");
        WriteLine(" [1] Vendas");
        WriteLine(" [2] Clientes");
        WriteLine(" [3] Vendedores");
        WriteLine(" [4] Produtos");
        WriteLine("\n [9] Sair");
        CriarLinha();
        Write(" Escolha uma opção: ");
        var opcao = ReadLine();
        switch (opcao)
        {
            case "1": break; // Futuro: MenuVendas();
            case "2": MenuCliente(); break;
            case "3": break; // Futuro: MenuVendedores();
            case "4": MenuProduto(); break;
            case "9":
                LojaContext.Finalizar();
                CriarCabecalho("Obrigado por usar nosso sistema");
                ReadKey();
                Environment.Exit(0); break;
        }
        MenuPrincipal();
    }

    public static void MenuProduto()
    {
        CriarCabecalho("Loja Mavi- Produtos");
        WriteLine(" [1] Cadastrar");
        WriteLine(" [2] Listar");
        WriteLine(" [3] Editar");
        WriteLine(" [4] Excluir");
        WriteLine("\n [Enter] Menu Principal");
        CriarLinha();
        Write(" Escolha uma opção: ");
        var opcao = ReadLine();
        switch (opcao)
        {
            case "1": ProdutoHelper.Cadastrar(); break;
            case "2": ProdutoHelper.Listar(); break;
            case "3": ProdutoHelper.Editar(); break;
            case "4": ProdutoHelper.Excluir(); break;
        }
        MenuPrincipal();
    }

    public static void MenuCliente()
    {
        CriarCabecalho("Loja Mavi- Clientes");
        WriteLine(" [1] Cadastrar");
        WriteLine(" [2] Listar");
        WriteLine(" [3] Editar");
        WriteLine(" [4] Excluir");
        WriteLine("\n [Enter] Menu Principal");
        CriarLinha();
        Write(" Escolha uma opção: ");
        var opcao = ReadLine();
        switch (opcao)
        {
            case "1": ClienteHelper.Cadastrar(); break;
            case "2": ClienteHelper.Listar(); break;
            case "3": ClienteHelper.Editar(); break;
            case "4": ClienteHelper.Excluir(); break;
        }
        MenuPrincipal();
    }
}