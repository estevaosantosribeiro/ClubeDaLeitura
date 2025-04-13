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

    public bool Editar(int idRevista, Revista novaRevista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] == null) continue;

            if (revistas[i].Id == idRevista)
            {
                revistas[i].Titulo = novaRevista.Titulo;
                revistas[i].NumeroEdicao = novaRevista.NumeroEdicao;
                revistas[i].DataPublicacao = novaRevista.DataPublicacao;

                return true;
            }
        }

        return false;
    }

    public bool Excluir(int idRevista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] == null) continue;

            if (revistas[i].Id == idRevista)
            {
                revistas[i] = null!;

                return true;
            }
        }

        return false;
    }

    public Revista[] SelecionarTodos()
    {
        return revistas;
    }
}
