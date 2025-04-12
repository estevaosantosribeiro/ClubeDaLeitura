

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

        Amigo novoAmigo = ObterDados();

        repositorioAmigo.Inserir(novoAmigo);

        Console.WriteLine("O registro foi concluído com sucesso!");
    }

    public void Editar()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Amigo...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        VisualizarTodos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine()!);

        Console.WriteLine();

        Amigo amigoEditado = ObterDados();

        bool conseguiuEditar = repositorioAmigo.Editar(idAmigo, amigoEditado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição do registro...");

            return;
        }

        Console.WriteLine("O registro foi editado com sucesso!");
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
            a.Id, a.Nome, a.NomeResponsavel, a.Telefone, 0
            );
        }

        Console.WriteLine();

        if (exibirTitulo)
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
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
