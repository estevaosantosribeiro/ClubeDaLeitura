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
            if (caixas[i] == null) continue;

            if (caixas[i].Id == idCaixa)
            {
                caixas[i].Etiqueta = novaCaixa.Etiqueta;
                caixas[i].Cor = novaCaixa.Cor;
                caixas[i].DiasEmprestimo = novaCaixa.DiasEmprestimo;

                return true;
            }
        }

        return false;
    }

    public bool Excluir(int idCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null) continue;

            if (caixas[i].Id == idCaixa)
            {
                caixas[i] = null!;

                return true;
            }
        }

        return false;
    }

    public Caixa[] SelecionarTodos()
    {
        return caixas;
    }

    public Caixa SelecionarPorId(int idCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null) continue;

            if (caixas[i].Id == idCaixa)
            {
                return caixas[i];
            }
        }

        return null!;
    }

    public bool EtiquetaEmUso(Caixa novaCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null) continue;

            if (caixas[i].Etiqueta == novaCaixa.Etiqueta)
            {
                return true;
            }
        }

        return false;
    }
}
