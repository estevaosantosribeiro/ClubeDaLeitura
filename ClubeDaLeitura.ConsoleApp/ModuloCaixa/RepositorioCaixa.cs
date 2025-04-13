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

    public bool Editar(int idCaixa, Caixa novaCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa c = caixas[i];

            if (c == null) continue;

            if (c.Id == idCaixa)
            {
                c.Etiqueta = novaCaixa.Etiqueta;
                c.Cor = novaCaixa.Cor;
                c.DiasEmprestimo = novaCaixa.DiasEmprestimo;

                return true;
            }
        }

        return false;
    }

    public Caixa[] SelecionarTodos()
    {
        return caixas;
    }
}
