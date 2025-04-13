using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaRevista
{
    public RepositorioRevista repositorioRevista;

    public TelaRevista(RepositorioRevista repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
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
        Console.WriteLine("4 - Visualizar Revista");

        Console.WriteLine("S - Voltar");

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

    public void VisualizarTodos(bool exibirTitulo)
    {
        ExibirCabecalho();

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

        Revista novaRevista = new Revista(titulo, numeroEdicao, dataPublicacao);

        return novaRevista;
    }
}
