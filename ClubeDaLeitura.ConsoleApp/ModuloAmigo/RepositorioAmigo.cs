﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

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

    public bool Editar(int idAmigo, Amigo amigoEditado)
    {
        for (int i = 0; i < amigos.Length; i++)
        {

            if (amigos[i] == null) continue;

            if (amigos[i].Id == idAmigo)
            {
                amigos[i].Nome = amigoEditado.Nome;
                amigos[i].NomeResponsavel = amigoEditado.NomeResponsavel;
                amigos[i].Telefone = amigoEditado.Telefone;

                return true;
            }
        }

        return false;
    }

    public bool Excluir(int idAmigo)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;

            if (amigos[i].Id == idAmigo)
            {
                amigos[i] = null!;
                return true;
            }
        }

        return false;
    }

    public Amigo[] SelecionarTodos()
    {
        return amigos;
    }
    public Amigo SelecionarPorId(int idAmigo)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;

            if (amigos[i].Id == idAmigo)
            {
                return amigos[i];
            }
        }

        return null!;
    }

    public bool NomeEmUso(string nome)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;

            if (amigos[i].Nome == nome)
            {
                return true;
            }
        }

        return false;
    }

    public bool TelefoneEmUso(string telefone)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;

            if (amigos[i].Telefone == telefone)
            {
                return true;
            }
        }

        return false;
    }
}
