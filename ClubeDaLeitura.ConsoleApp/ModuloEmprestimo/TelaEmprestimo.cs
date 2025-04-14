﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo
{
    public RepositorioEmprestimo repositorioEmprestimo;
    public RepositorioAmigo repositorioAmigo;
    public RepositorioRevista repositorioRevista;

    public TelaEmprestimo(
        RepositorioEmprestimo repositorioEmprestimo, 
        RepositorioAmigo repositorioAmigo, 
        RepositorioRevista repositorioRevista
    )
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Controle de Empréstimos");
        Console.WriteLine("----------------------------------------");
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("1 - Cadastrar Empréstimo");
        Console.WriteLine("4 - Visualizar Empréstimos");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine()![0];

        return opcaoEscolhida;
    }

    public void Inserir()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Registrando Empréstimo...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Emprestimo novoEmprestimo = ObterDados();

        repositorioEmprestimo.Inserir(novoEmprestimo);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }

    public void VisualizarTodos(bool exibirTitulo)
    {
        if (exibirTitulo) ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Visualizando Empréstimos...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -18} | {4, -18} | {5, -10}",
            "Id", "Amigo", "Revista", "Data de Empréstimo", "Data de Devolução", "Situação"
        );

        Emprestimo[] emprestimosCadastrados = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimosCadastrados.Length; i++)
        {
            Emprestimo e = emprestimosCadastrados[i];

            if (e == null) continue;

            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -18} | {4, -18} | {5, -10}",
                e.Id,
                e.Amigo.Nome,
                e.Revista.Titulo,
                e.DataEmprestimo.ToShortDateString(),
                e.DataDevolucao.ToShortDateString(),
                e.Situacao
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.Yellow);
    }

    public void VisualizarAmigos()
    {
        Console.WriteLine();

        Console.WriteLine("Visualizando Amigos...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -15} | {4, -20}",
            "Id", "Nome", "Responsável", "Telefone", "Empréstimos"
        );

        Amigo[] amigosCadastrados = repositorioAmigo.SelecionarTodos();

        for (int i = 0; i < amigosCadastrados.Length; i++)
        {
            Amigo a = amigosCadastrados[i];

            if (a == null) continue;

            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -15} | {4, -20}",
                a.Id, a.Nome, a.NomeResponsavel, a.Telefone, 0
            );
        }

        Console.WriteLine();
    }

    public void VisualizarRevistas()
    {
        Console.WriteLine();

        Console.WriteLine("Visualizando Revistas...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -30} | {2, -15} | {3, -18} | {4, -10}",
            "Id", "Título", "Num. da edição", "Data de publicação", "Caixa"
        );

        Revista[] revistasCadastradas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistasCadastradas.Length; i++)
        {
            Revista r = revistasCadastradas[i];

            if (r == null) continue;

            Console.WriteLine(
                "{0, -6} | {1, -30} | {2, -15} | {3, -18} | {4, -10}",
                r.Id, r.Titulo, r.NumeroEdicao, r.DataPublicacao.ToShortDateString(), "Caixa 1"
            );
        }

        Console.WriteLine();
    }

    public Emprestimo ObterDados()
    {
        VisualizarAmigos();

        Console.Write("Digite o ID do amigo que deseja selecionar: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine());

        Amigo amigoSelecionado = repositorioAmigo.SelecionarPorId(idAmigo);

        VisualizarRevistas();

        Console.Write("Digite o ID da revista que deseja selecionar: ");
        int idRevista = Convert.ToInt32(Console.ReadLine());

        Revista revistaSelecionada = repositorioRevista.SelecionarPorId(idRevista);

        Console.Write("Digite a data do empréstimo (dd/MM/yyyy) ");
        DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Digite a data da devolução (dd/MM/yyyy) ");
        DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());

        string situacao = "Aberto";

        Emprestimo novoEmprestimo = new Emprestimo(
            amigoSelecionado,
            revistaSelecionada,
            dataEmprestimo,
            dataDevolucao,
            situacao
        );

        return novoEmprestimo;
    }
}
