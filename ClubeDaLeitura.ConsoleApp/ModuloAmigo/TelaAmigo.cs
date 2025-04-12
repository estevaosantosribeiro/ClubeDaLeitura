

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

        Console.WriteLine("Cadastrando Amigo...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Amigo novoAmigo = ObterDados();

        repositorioAmigo.Inserir(novoAmigo);

        Console.WriteLine("O registro foi concluído com sucesso!");
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
