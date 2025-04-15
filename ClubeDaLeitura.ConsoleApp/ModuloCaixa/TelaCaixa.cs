using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

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
        Console.WriteLine("3 - Excluir Caixa");
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

        Caixa novaCaixa;

        do
        {
            novaCaixa = ObterDados();

            bool etiquetaEmUso = repositorioCaixa.EtiquetaEmUso(novaCaixa);

            if (etiquetaEmUso)
            {
                Notificador.ExibirMensagem("Etiqueta já está em uso, por favor informe os dados novamente", ConsoleColor.Yellow);
                continue;
            }

            string erros = novaCaixa.Validar();

            if (erros.Length > 0)
            {
                Notificador.ExibirMensagem(erros, ConsoleColor.Red);
            }
            else
            {
                break;
            }
        } while (true);

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

    public void Excluir()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Caixa...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        VisualizarTodos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine()!);

        Console.WriteLine();

        int quantidadeRevistas = repositorioCaixa.SelecionarPorId(idCaixa).ObterQuantidadeRevistas();

        if (quantidadeRevistas > 0)
        {
            Notificador.ExibirMensagem("Não é possível excluir a caixa pois ela ainda possui revistas...", ConsoleColor.Red);

            return;
        }

        bool conseguiuExcluir = repositorioCaixa.Excluir(idCaixa);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão do registro", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
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

        string cor = SelecionarCor();

        Console.Write("Digite a quantidade de dias de empréstimo: ");
        int diasEmprestimo = Convert.ToInt32(Console.ReadLine()!);

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasEmprestimo);

        return novaCaixa;
    }

    public string SelecionarCor()
    {
        Console.WriteLine("Cores disponíveis");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine("1 - Verde (#00ff00)");
        Console.WriteLine("2 - Amarelo (#ffff00)");
        Console.WriteLine("3 - Azul (#0000ff)");
        Console.WriteLine("5 - Vermelho (#ff0000)");
        Console.WriteLine("6 - Laranja (#ffa500)");
        Console.WriteLine("7 - Roxo (#800080)");
        Console.WriteLine("8 - Preto (#000000)");

        Console.WriteLine();

        Console.Write("Selecione a cor que deseja: ");
        char opcaoEscolhida = Console.ReadLine()![0];

        string cor = "#ffffff";

        switch (opcaoEscolhida)
        {
            case '1':
                cor = "#00ff00";
                break;
            case '2':
                cor = "#ffff00";
                break;
            case '3':
                cor = "#0000ff";
                break;
            case '5':
                cor = "#ff0000";
                break;
            case '6':
                cor = "#ffa500";
                break;
            case '7':
                cor = "#800080";
                break;
            case '8':
                cor = "#000000";
                break;
            default:
                break;
        }

        return cor;
    }
}
