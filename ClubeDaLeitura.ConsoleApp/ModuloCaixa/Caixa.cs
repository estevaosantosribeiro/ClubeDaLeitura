namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class Caixa
{
    public int Id;
    public string Etiqueta;
    public string Cor;
    public int DiasEmprestimo;

    public Caixa(string etiqueta, string cor, int diasEmprestimo)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasEmprestimo = diasEmprestimo;
    }
}
