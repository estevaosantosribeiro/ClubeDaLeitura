using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class RepositorioRevista
{
    public Revista[] revistas = new Revista[100];
    public int contadorRevistas = 0;

    public void Inserir(Revista novaRevista)
    {
        novaRevista.Id = GeradorIds.GerarIdRevista();

        revistas[contadorRevistas++] = novaRevista;
    }

    public Revista[] SelecionarTodos()
    {
        return revistas;
    }
}
