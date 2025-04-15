using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class Revista
{
    public int Id;
    public string Titulo;
    public int NumeroEdicao;
    public DateTime DataPublicacao;
    public string Status;
    public Caixa Caixa;

    public Revista(string titulo, int numeroEdicao, DateTime dataPublicacao, string status, Caixa caixa)
    {
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        DataPublicacao = dataPublicacao;
        Status = status;
        Caixa = caixa;
    }

    public string Validar()
    {
        string erros = "";

        if (string.IsNullOrEmpty(Titulo))
            erros += "O campo 'Titulo' é obrigatório";
        if (Titulo.Length > 100 || Titulo.Length < 2)
            erros += "O campo 'Titulo' precisa conter entre 2 a 100 caracteres";
        if (NumeroEdicao < 0)
            erros += "O campo 'Número de Edição' não pode ser um número negativo";

        return erros;
    }

    public bool Emprestar()
    {
        if (Status == "Disponível")
        {
            Status = "Emprestada";

            return true;
        }
        else
        {
            return false;
        }
    }

    public void Devolver()
    {
        Status = "Disponível";
    }

    public bool Reservar()
    {
        if (Status == "Disponível")
        {
            Status = "Reservada";

            return true;
        }
        else
        {
            return false;
        }
    }
}
