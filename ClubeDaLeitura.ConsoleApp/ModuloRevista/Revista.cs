using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class Revista
{
    public int Id;
    public string Titulo;
    public int NumeroEdicao;
    public DateTime DataPublicacao;
    public Caixa Caixa;

    public Revista(string titulo, int numeroEdicao, DateTime dataPublicacao)
    {
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        DataPublicacao = dataPublicacao;
    }
}
