
namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public static class GeradorIds
{
    public static int IdAmigos = 0;
    public static int IdCaixas = 0;
    public static int IdRevistas = 0;
    public static int IdEmprestimos = 0;

    public static int GerarIdAmigo()
    {
        IdAmigos++;

        return IdAmigos;
    }

    public static int GerarIdCaixa()
    {
        IdCaixas++;

        return IdCaixas;
    }

    public static int GerarIdRevista()
    {
        IdRevistas++;

        return IdRevistas;
    }

    public static int GerarIdEmprestimo()
    {
        IdEmprestimos++;

        return IdEmprestimos;
    }
}
