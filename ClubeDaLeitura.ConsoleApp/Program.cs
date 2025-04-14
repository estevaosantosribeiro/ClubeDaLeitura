﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
        RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        RepositorioRevista repositorioRevista = new RepositorioRevista();
        RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

        TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
        TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
        TelaRevista telaRevista = new TelaRevista(repositorioRevista);
        TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            char opcaoPrincipal = telaPrincipal.ApresentarMenuPrincipal();

            if (opcaoPrincipal == '1')
            {
                char opcaoEscolhida = telaAmigo.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaAmigo.Inserir(); break;

                    case '2': telaAmigo.Editar(); break;

                    case '3': telaAmigo.Excluir(); break;

                    case '4': telaAmigo.VisualizarTodos(true); break;

                    default: break;
                }
            }
            else if (opcaoPrincipal == '2')
            {
                char opcaoEscolhida = telaCaixa.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaCaixa.Cadastrar(); break;

                    case '2': telaCaixa.Editar(); break;

                    case '3': telaCaixa.Excluir(); break;

                    case '4': telaCaixa.VisualizarTodos(true); break;

                    default: break;
                }
            }
            else if (opcaoPrincipal == '3')
            {
                char opcaoEscolhida = telaRevista.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaRevista.Inserir(); break;

                    case '2': telaRevista.Editar(); break;

                    case '3': telaRevista.Excluir(); break;

                    case '4': telaRevista.VisualizarTodos(true); break;

                    default: break;
                }
            }
            else if (opcaoPrincipal == '4')
            {
                char opcaoEscolhida = telaEmprestimo.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaEmprestimo.Inserir(); break;

                    case '2': telaEmprestimo.Editar(); break;

                    case '3': telaEmprestimo.Excluir(); break;

                    case '4': telaEmprestimo.VisualizarTodos(true); break;

                    default: break;
                }
            }
        }
    }
}
