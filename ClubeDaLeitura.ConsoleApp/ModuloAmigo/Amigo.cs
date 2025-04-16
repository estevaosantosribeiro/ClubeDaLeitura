

using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class Amigo
{
    public int Id;
    public string Nome;
    public string NomeResponsavel;
    public string Telefone;
    public bool temEmprestimo;

    public Amigo(string nome,
                 string nomeResponsavel,
                 string telefone)
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
        if (string.IsNullOrEmpty(NomeResponsavel))
            erros += "O campo 'Responsável' é obrigatório.\n";
        if (NomeResponsavel.Length < 3 || NomeResponsavel.Length > 100)
            erros += "O campo 'Responsável' precisa conter entre 3 - 100 caracteres.\n";
        if (string.IsNullOrEmpty(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";
        if (ValidarTelefone(Telefone))
            erros += "O campo 'Telefone' deve seguir o formato: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX).\n";

        return erros;
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

    public void AdicionarEmprestimo()
    {
        temEmprestimo = true;
    }

    public void RemoverEmprestimo()
    {
        temEmprestimo = false;
    }
}
