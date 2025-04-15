# Clube Da Leitura

## Controle de Amigos e Caixas

![](https://i.imgur.com/AHewMs5.gif)

## Controle de Revistas e Empréstimos

![](https://i.imgur.com/DxbQzHa.gif)

## Sobre o Projeto

O projeto "Clube da Leitura 2025" consiste em um sistema de gerenciamento de empréstimos de revistas entre amigos. Ele possui módulos para cadastro e controle de amigos, caixas, revistas e empréstimos, com regras específicas de negócio e estrutura orientada a objetos. O sistema foi desenvolvido utilizando boas práticas de programação e organizado em três camadas.

## Funcionalidades

### Módulo de Amigos
- Inserir novos amigos
- Editar amigos cadastrados
- Excluir amigos (somente se não houver empréstimos vinculados)
- Visualizar amigos
- Visualizar empréstimos de um amigo

> **Regras de Negócio:**
> - Nome, nome do responsável e telefone são obrigatórios
> - Não pode haver amigos com mesmo nome e telefone
> - Telefone deve seguir o formato válido

---

### Módulo de Caixas
- Cadastrar novas caixas
- Editar caixas existentes
- Excluir caixas (somente se não houver revistas vinculadas)
- Visualizar todas as caixas

> **Regras de Negócio:**
> - Etiqueta única (até 50 caracteres), cor e dias de empréstimo são obrigatórios
> - Cada caixa define o prazo de empréstimo das revistas que contém

---

### Módulo de Revistas
- Cadastrar novas revistas
- Editar revistas
- Excluir revistas
- Visualizar revistas
- Ver status atual da revista (Disponível, Emprestada ou Reservada)

> **Regras de Negócio:**
> - Título, número da edição, ano de publicação e caixa são obrigatórios
> - Não pode haver duplicação de título e edição
> - Status padrão ao cadastrar: Disponível

---

### Módulo de Empréstimos
- Registrar novos empréstimos
- Registrar devoluções
- Visualizar empréstimos (abertos e fechados)

> **Regras de Negócio:**
> - Um amigo só pode ter um empréstimo ativo por vez
> - Data de devolução é calculada com base nos dias definidos pela caixa
> - Empréstimos atrasados devem ser destacados



## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

## Como usar

1. Clone o repositório:

```sh
git clone https://github.com/estevaosantosribeiro/GestaoDeEquipamentos.git
```

2. Navegue até a pasta raiz do projeto:

```sh
cd GestaoDeEquipamentos
```

3. Restaure as dependências:

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