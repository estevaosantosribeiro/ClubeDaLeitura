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
