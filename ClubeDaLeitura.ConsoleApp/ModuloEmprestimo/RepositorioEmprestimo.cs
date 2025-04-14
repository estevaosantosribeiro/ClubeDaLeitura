using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class RepositorioEmprestimo
{
    public Emprestimo[] emprestimos = new Emprestimo[100];
    public int contadorEmprestimos = 0;

    public void Inserir(Emprestimo novoEmprestimo)
    {
        novoEmprestimo.Id = GeradorIds.GerarIdEmprestimo();

        emprestimos[contadorEmprestimos++] = novoEmprestimo;
    }

    internal Emprestimo[] SelecionarTodos()
    {
        return emprestimos;
    }
}
