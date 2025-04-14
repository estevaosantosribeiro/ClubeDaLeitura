using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaRevista
{
    public RepositorioRevista repositorioRevista;
    public RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Controle de Revistas");
        Console.WriteLine("----------------------------------------");
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("1 - Inserir Revista");
        Console.WriteLine("2 - Editar Revista");
        Console.WriteLine("3 - Excluir Revista");
        Console.WriteLine("4 - Visualizar Revista");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine()![0];

        return opcaoEscolhida;
    }

    public void Inserir()
    {
        ExibirCabecalho();

        Console.WriteLine("Inserindo Revista...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Revista novaRevista = ObterDados();

        repositorioRevista.Inserir(novaRevista);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }

    public void Editar()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Revista...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        VisualizarTodos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idRevista = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Revista revistaEditada = ObterDados();

        bool conseguiuEditar = repositorioRevista.Editar(idRevista, revistaEditada);

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

        Console.WriteLine("Excluindo Revista...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        VisualizarTodos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idRevista = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioRevista.Excluir(idRevista);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão do registro...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
    }

    public void VisualizarCaixas()
    {
        Console.WriteLine();

        Console.WriteLine("Visualizando Caixas...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -10} | {3, -6}",
            "Id", "Etiqueta", "Cor", "Dias de Empréstimo"
        );

        Caixa[] caixasCadastradas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixasCadastradas.Length; i++)
        {
            Caixa c = caixasCadastradas[i];

            if (c == null) continue;

            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -10} | {3, -6}",
                c.Id, c.Etiqueta, c.Cor, c.DiasEmprestimo
            );
        }

        Console.WriteLine();
    }

    public void VisualizarTodos(bool exibirTitulo)
    {
        if (exibirTitulo) ExibirCabecalho();

        Console.WriteLine("Visualizando Revistas...");
        Console.WriteLine("--------------------------------------------");

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

        if (exibirTitulo)
            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.Yellow);
    }

    public Revista ObterDados()
    {
        Console.Write("Digite o título da revista: ");
        string titulo = Console.ReadLine()!;

        Console.Write("Digite o número da edição: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine()!);

        Console.Write("Digite a data de publicação: ");
        DateTime dataPublicacao = Convert.ToDateTime(Console.ReadLine()!);

        VisualizarCaixas();

        Console.Write("Digite o ID da caixa que deseja selecionar para a revista: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        Caixa caixaSelecionada = repositorioCaixa.SelecionarPorId(idCaixa);

        Revista novaRevista = new Revista(titulo, numeroEdicao, dataPublicacao, caixaSelecionada);

        return novaRevista;
    }
}
