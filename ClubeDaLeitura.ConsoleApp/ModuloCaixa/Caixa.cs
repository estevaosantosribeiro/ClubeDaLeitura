using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class Caixa
{
    public int Id;
    public string Etiqueta;
    public string Cor;
    public int DiasEmprestimo;
    public Revista[] Revistas;

    public Caixa(string etiqueta, string cor, int diasEmprestimo)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasEmprestimo = diasEmprestimo;
        Revistas = new Revista[100];
    }

    public string Validar()
    {
        string erros = "";

        if (string.IsNullOrEmpty(Etiqueta))
            erros += "O campo 'Etiqueta' é obrigatório.\n";
        if (Etiqueta.Length > 50)
            erros += "O campo 'Nome' deve conter no máximo 50 caracteres.\n";
        if (DiasEmprestimo < 0)
            erros += "O campo 'Dias de Empréstimo' não pode ser negativo.\n";

        return erros;
    }

    public void AdicionarRevista(Revista revista)
    {
        for (int i = 0; i < Revistas.Length; i++)
        {
            if (Revistas[i] == null)
            {
                Revistas[i] = revista;
                return;
            }
        }
    }

    public void RemoverRevista(Revista revista)
    {
        for (int i = 0; i < Revistas.Length; i++)
        {
            if (Revistas[i] == null) continue;

            else if (Revistas[i] == revista)
            {
                Revistas[i] = null!;

                return;
            }
        }
    }

    public int ObterQuantidadeRevistas()
    {
        int contador = 0;

        for (int i = 0; i < Revistas.Length; i++)
        {
            if (Revistas[i] != null)
            {
                contador++;
            }
        }

        return contador;
    }
}
