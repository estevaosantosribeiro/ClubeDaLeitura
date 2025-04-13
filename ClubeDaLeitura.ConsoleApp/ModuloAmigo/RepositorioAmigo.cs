using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class RepositorioAmigo
{
    public Amigo[] amigos = new Amigo[100];
    public int contadorAmigos = 0;

    public void Inserir(Amigo novoAmigo)
    {
        novoAmigo.Id = GeradorIds.GerarIdAmigo();

        amigos[contadorAmigos++] = novoAmigo;
    }

    public bool Editar(int idAmigo, Amigo amigoEditado)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo a = amigos[i];

            if (a == null) continue;

            if (a.Id == idAmigo)
            {
                a.Nome = amigoEditado.Nome;
                a.NomeResponsavel = amigoEditado.NomeResponsavel;
                a.Telefone = amigoEditado.Telefone;

                return true;
            }
        }

        return false;
    }

    public bool Excluir(int idAmigo)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;

            if (amigos[i].Id == idAmigo)
            {
                amigos[i] = null!;
                return true;
            }
        }

        return false;
    }

    public Amigo[] SelecionarTodos()
    {
        return amigos;
    }
}
