﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo
{
    public RepositorioAmigo repositorioAmigo;

    public TelaAmigo(RepositorioAmigo repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Controle de Amigos");
        Console.WriteLine("--------------------------------------------");
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("1 - Inserção de Amigo");
        Console.WriteLine("2 - Edição de Amigo");
        Console.WriteLine("3 - Exclusão de Amigo");
        Console.WriteLine("4 - Visualizar Amigos");

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

        Console.WriteLine("Inserindo Amigo...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Amigo novoAmigo;

        do
        {
            novoAmigo = ObterDados();

            bool nomeEmUso = repositorioAmigo.NomeEmUso(novoAmigo.Nome);
            bool telefoneEmUso = repositorioAmigo.TelefoneEmUso(novoAmigo.Telefone);

            if (nomeEmUso && telefoneEmUso)
            {
                Notificador.ExibirMensagem("Este nome e telefone já estão cadastrados, por favor informe os dados novamente", ConsoleColor.Yellow);
                continue;
            }

            string erros = novoAmigo.Validar();

            if (erros.Length > 0)
            {
                Notificador.ExibirMensagem(erros, ConsoleColor.Red);
            }
            else
            {
                break;
            }

        } while (true);

        repositorioAmigo.Inserir(novoAmigo);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }

    public void Editar()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Amigo...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        VisualizarTodos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Amigo amigoEditado = ObterDados();

        string erros = amigoEditado.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            return;
        }

        bool conseguiuEditar = repositorioAmigo.Editar(idAmigo, amigoEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição do registro...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
    }

    public void Excluir()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Amigo...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        VisualizarTodos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine()!);

        Console.WriteLine();

        int quantidadeEmprestimos = repositorioAmigo.SelecionarPorId(idAmigo).ObterQuantidadeEmprestimos();

        if (quantidadeEmprestimos > 0)
        {
            Notificador.ExibirMensagem("Não é possível excluir o amigo pois ele ainda possui empréstimos ativos...", ConsoleColor.Red);

            return;
        }

        bool conseguiuExcluir = repositorioAmigo.Excluir(idAmigo);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão do registro...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi excluído com sucesso", ConsoleColor.Green);
    }

    public void VisualizarTodos(bool exibirTitulo)
    {
        if (exibirTitulo) ExibirCabecalho();

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
                a.Id, a.Nome, a.NomeResponsavel, a.Telefone, a.ObterQuantidadeEmprestimos()
            );
        }

        Console.WriteLine();

        if (exibirTitulo)
            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.Yellow);
    }

    public void VisualizarEmprestimos()
    {
        VisualizarTodos(true);

        Console.Write("Digite o ID do amigo que deseja ver os empréstimos: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Console.WriteLine("Visualizando Empréstimos...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -18} | {4, -18} | {5, -10}",
            "Id", "Revista", "Data de Empréstimo", "Data de Devolução", "Situação"
        );

        Emprestimo[] emprestimos = repositorioAmigo.SelecionarEmprestimos(idAmigo);

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = emprestimos[i];

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

    public Amigo ObterDados()
    {
        Console.Write("Digite o nome do amigo: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o nome do responsável do amigo: ");
        string nomeResponsavel = Console.ReadLine()!;

        Console.Write("Digite o telefone do amigo: ");
        string telefone = Console.ReadLine()!;

        Amigo amigo = new Amigo(nome, nomeResponsavel, telefone);

        return amigo;

    }
}