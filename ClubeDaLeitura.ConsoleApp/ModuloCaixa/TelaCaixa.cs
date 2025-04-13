using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class TelaCaixa
{
    public RepositorioCaixa repositorioCaixa;

    public TelaCaixa(RepositorioCaixa repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }
    
    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Controle de Caixa");
        Console.WriteLine("----------------------------------------");
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("1 - Cadastrar Caixa");
        Console.WriteLine("2 - Editar Caixa");
        Console.WriteLine("4 - Visualizar Caixas");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Convert.ToChar(Console.ReadLine()!);

        return opcaoEscolhida;
    }

    public void Cadastrar()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Cadastrando Caixa...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Caixa novaCaixa = ObterDados();

        repositorioCaixa.Cadastrar(novaCaixa);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }

    public void Editar()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Caixa...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        VisualizarTodos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine()!);

        Console.WriteLine();

        Caixa caixaEditada = ObterDados();

        bool conseguiuEditar = repositorioCaixa.Editar(idCaixa, caixaEditada);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição do registro", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
    }

    public void VisualizarTodos(bool exibirTitulo)
    {
        if (exibirTitulo) ExibirCabecalho();

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

        if (exibirTitulo)
            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.Yellow);
    }

    public Caixa ObterDados()
    {
        Console.Write("Digite a etiqueta da caixa: ");
        string etiqueta = Console.ReadLine()!;

        Console.Write("Digite a cor da caixa: ");
        string cor = Console.ReadLine()!;

        Console.Write("Digite a quantidade de dias de empréstimo: ");
        int diasEmprestimo = Convert.ToInt32(Console.ReadLine()!);

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasEmprestimo);

        return novaCaixa;
    }
}
