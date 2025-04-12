﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class RepositorioAmigo
{
    public Amigo[] amigos = new Amigo[100];
    public int contadorAmigos = 0;

    public void Inserir(Amigo novoAmigo)
    {
        novoAmigo.Id = GeradorIds.GerarIdAmigo();

        amigos[contadorAmigos++] = novoAmigo;
    }


    public Amigo[] SelecionarTodos()
    {
        return amigos;
    }
}
