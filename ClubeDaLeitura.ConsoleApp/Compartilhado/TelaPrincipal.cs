namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    public char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("|             Clube de Leitura             |");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Amigos");
        Console.WriteLine("2 - Controle de Caixas");
        Console.WriteLine("3 - Controle de Revistas");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char opcaoEscolhida = Console.ReadLine()![0];

        return opcaoEscolhida;
    }
}
