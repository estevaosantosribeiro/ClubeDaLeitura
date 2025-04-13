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

        Console.WriteLine("1 - Cadastro de Revista");

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
