using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class RepositorioCaixa
{
    public Caixa[] caixas = new Caixa[100];
    public int contadorCaixas = 0;

    public void Cadastrar(Caixa novaCaixa)
    {
        novaCaixa.Id = GeradorIds.GerarIdCaixa();

        caixas[contadorCaixas++] = novaCaixa;
    }

    public Caixa[] SelecionarTodos()
    {
        return caixas;
    }
}
