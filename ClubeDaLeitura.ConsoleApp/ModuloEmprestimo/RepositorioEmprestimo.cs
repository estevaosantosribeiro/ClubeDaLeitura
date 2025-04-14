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

    public bool Editar(int idEmprestimo, Emprestimo emprestimoEditado)
    {
        for (int i = 0; i < emprestimos.Length; i++)
        {
            if (emprestimos[i] == null) continue;

            if (emprestimos[i].Id == idEmprestimo)
            {
                emprestimos[i].Amigo = emprestimoEditado.Amigo;
                emprestimos[i].Revista = emprestimoEditado.Revista;
                emprestimos[i].DataEmprestimo = emprestimoEditado.DataEmprestimo;
                emprestimos[i].DataDevolucao = emprestimoEditado.DataDevolucao;
                emprestimos[i].Situacao = emprestimoEditado.Situacao;

                return true;
            }
        }

        return false;
    }

    public bool Excluir(int idEmprestimo)
    {
        for (int i = 0; i < emprestimos.Length; i++)
        {
            if (emprestimos[i] == null) continue;

            if (emprestimos[i].Id == idEmprestimo)
            {
                emprestimos[i] = null!;

                return true;
            }
        }

        return false;
    }

    internal Emprestimo[] SelecionarTodos()
    {
        return emprestimos;
    }
}
