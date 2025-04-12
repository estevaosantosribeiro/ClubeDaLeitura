using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

        TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);

        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            char opcaoPrincipal = telaPrincipal.ApresentarMenuPrincipal();

            if (opcaoPrincipal == '1')
            {
                char opcaoEscolhida = telaAmigo.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaAmigo.Inserir(); break;

                    case '2': telaAmigo.Editar(); break;

                    case '4': telaAmigo.VisualizarTodos(true); break;

                    default: break;
                }
            }
        }
    }
}
