# Clube Da Leitura

## Controle de Amigos e Caixas

![](https://i.imgur.com/AHewMs5.gif)

## Controle de Revistas e Empr�stimos

![](https://i.imgur.com/DxbQzHa.gif)

## Sobre o Projeto

O projeto "Clube da Leitura 2025" consiste em um sistema de gerenciamento de empr�stimos de revistas entre amigos. Ele possui m�dulos para cadastro e controle de amigos, caixas, revistas e empr�stimos, com regras espec�ficas de neg�cio e estrutura orientada a objetos. O sistema foi desenvolvido utilizando boas pr�ticas de programa��o e organizado em tr�s camadas.

## Funcionalidades

### M�dulo de Amigos
- Inserir novos amigos
- Editar amigos cadastrados
- Excluir amigos (somente se n�o houver empr�stimos vinculados)
- Visualizar amigos
- Visualizar empr�stimos de um amigo

> **Regras de Neg�cio:**
> - Nome, nome do respons�vel e telefone s�o obrigat�rios
> - N�o pode haver amigos com mesmo nome e telefone
> - Telefone deve seguir o formato v�lido

---

### M�dulo de Caixas
- Cadastrar novas caixas
- Editar caixas existentes
- Excluir caixas (somente se n�o houver revistas vinculadas)
- Visualizar todas as caixas

> **Regras de Neg�cio:**
> - Etiqueta �nica (at� 50 caracteres), cor e dias de empr�stimo s�o obrigat�rios
> - Cada caixa define o prazo de empr�stimo das revistas que cont�m

---

### M�dulo de Revistas
- Cadastrar novas revistas
- Editar revistas
- Excluir revistas
- Visualizar revistas
- Ver status atual da revista (Dispon�vel, Emprestada ou Reservada)

> **Regras de Neg�cio:**
> - T�tulo, n�mero da edi��o, ano de publica��o e caixa s�o obrigat�rios
> - N�o pode haver duplica��o de t�tulo e edi��o
> - Status padr�o ao cadastrar: Dispon�vel

---

### M�dulo de Empr�stimos
- Registrar novos empr�stimos
- Registrar devolu��es
- Visualizar empr�stimos (abertos e fechados)

> **Regras de Neg�cio:**
> - Um amigo s� pode ter um empr�stimo ativo por vez
> - Data de devolu��o � calculada com base nos dias definidos pela caixa
> - Empr�stimos atrasados devem ser destacados



## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.

## Como usar

1. Clone o reposit�rio:

```sh
git clone https://github.com/estevaosantosribeiro/GestaoDeEquipamentos.git
```

2. Navegue at� a pasta raiz do projeto:

```sh
cd GestaoDeEquipamentos
```

3. Restaure as depend�ncias:

```sh
dotnet restore
```

4. Compile o projeto:

```sh
dotnet build
```

5. Execute o programa:

```sh
dotnet run
```