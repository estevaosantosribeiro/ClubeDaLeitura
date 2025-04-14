using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class Emprestimo
{
    public int Id;
    public Amigo Amigo;
    public Revista Revista;
    public DateTime DataEmprestimo;
    public DateTime DataDevolucao;
    public string Situacao;

    public Emprestimo(
        Amigo amigo, 
        Revista revista, 
        DateTime dataEmprestimo, 
        DateTime dataDevolucao,
        string situacao
    )
    {
        Amigo = amigo;
        Revista = revista;
        DataEmprestimo = dataEmprestimo;
        DataDevolucao = dataDevolucao;
        Situacao = situacao;
    }
}
