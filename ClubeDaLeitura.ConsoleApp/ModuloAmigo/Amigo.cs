

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class Amigo
{
    public int Id;
    public string Nome;
    public string NomeResponsavel;
    public string Telefone;

    public Amigo(string nome, string nomeResponsavel, string telefone)
    {
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
    }

    public string Validar()
    {
        string erros = "";

        if (string.IsNullOrEmpty(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";
        if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo 'Nome' precisa conter entre 3 - 100 caracteres.\n";
        if (NomeResponsavel.Length < 3 || NomeResponsavel.Length > 100)
            erros += "O campo 'Nome do Reponsável' precisa conter entre 3 - 100 caracteres.\n";
        if (ValidarTelefone(Telefone))
            erros += "O campo 'Telefone' deve seguir o formato: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX).\n"
    }

    private bool ValidarTelefone(string telefone)
    {
        if (telefone[0] == '(' && 
            telefone[3] == ')' && 
            (telefone[10] == '-' || telefone[11] == '-'))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
