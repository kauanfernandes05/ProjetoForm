<div align="center">

# 📝 Sistema de Cadastros

### C# · Windows Forms · .NET 8 · SQL Server

Aplicação desktop para cadastrar, consultar, editar e excluir registros, com persistência no SQL Server.

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![.NET 8](https://img.shields.io/badge/.NET_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D4?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge)

</div>

## 💡 Sobre o projeto

Este projeto foi desenvolvido como um desafio prático durante meu estágio em desenvolvimento. A proposta começou com um formulário simples e evoluiu para uma aplicação com duas telas, validações, pesquisa e integração com banco de dados.

Durante o desenvolvimento, implementei melhorias a partir de testes e apresentações do sistema, trabalhando tanto o funcionamento das operações quanto a usabilidade da interface.

## 🖥️ Como funciona

A aplicação possui duas telas principais:

### Menu

Centraliza a visualização e a pesquisa dos cadastros.

- Lista os registros em um DataGridView.
- Filtra os cadastros conforme o nome digitado.
- Permite iniciar um novo cadastro.
- Abre o registro selecionado para edição.
- Permite excluir um cadastro mediante confirmação.

### Cadastro

Reúne os campos para inclusão e edição dos dados.

- Nome ou razão social.
- Data de nascimento.
- Salário.
- Cargo, com pesquisa na lista de opções.
- Sexo.
- Benefícios opcionais: vale-transporte, vale-alimentação e plano de saúde.

Na inclusão, o botão apresenta o texto **Salvar**. Durante a edição, passa a exibir **Alterar**.

## ⚙️ Funcionalidades

- [x] Cadastro de novos registros.
- [x] Carregamento dos dados ao abrir o sistema.
- [x] Edição com preservação do ID.
- [x] Exclusão com confirmação.
- [x] Pesquisa por nome no menu.
- [x] Pesquisa de cargos durante a digitação.
- [x] Navegação entre os campos com Enter.
- [x] Formatação monetária do salário.
- [x] Seleção de benefícios por CheckBox.
- [x] Mensagens de confirmação e resultado das operações.
- [x] Opção de cadastrar outra pessoa após uma inclusão.
- [x] Operações de banco com métodos assíncronos.

## ✅ Validações

| Campo | Regra |
|---|---|
| Nome ou razão social | Obrigatório, com até 150 caracteres; permite letras, números, espaços e pontos |
| Data de nascimento | Idade mínima de 18 anos e limite de 120 anos |
| Salário | Entre R$ 800,00 e R$ 9.999.999,99 |
| Cargo | Deve corresponder a uma opção da lista de cargos |
| Sexo | Exatamente uma opção deve estar marcada |
| Benefícios | Opcionais; quando nenhum é selecionado, a tabela apresenta “Nenhum” |

A aplicação também verifica cadastros com todos os dados iguais na lista carregada, desconsiderando o próprio registro durante a edição.

## 🗄️ Integração com o banco

O acesso ao SQL Server utiliza **Microsoft.Data.SqlClient**, com autenticação do Windows.

| Operação | Método |
|---|---|
| Inserir | `InserirAsync` |
| Consultar | `ListarAsync` |
| Atualizar | `AtualizarAsync` |
| Excluir | `RemoverAsync` |

Os comandos SQL utilizam parâmetros para enviar os valores dos campos.

O ID é gerado pelo SQL Server por meio de `IDENTITY`. Ele permanece fixo durante a edição e não é renumerado após uma exclusão.

## 🧩 Organização do código

| Arquivo | Responsabilidade |
|---|---|
| `Program.cs` | Inicialização da aplicação |
| `FormMenu.cs` | Listagem, pesquisa e acesso às operações |
| `FormPrincipal.cs` | Preenchimento, validação e salvamento dos dados |
| `Cadastro.cs` | Representação dos dados de um cadastro |
| `CadastroRepository.cs` | Consultas e comandos de persistência |
| `ConexaoBanco.cs` | Criação da conexão com o SQL Server |

As telas compartilham uma `BindingList<Cadastro>`, recebida pelo construtor da tela de cadastro. Isso permite refletir as inclusões e alterações no menu.

## 🚀 Como executar

### Pré-requisitos

- Windows.
- Visual Studio 2022 com suporte ao .NET 8 e a desenvolvimento desktop com .NET.
- SQL Server.
- Uma ferramenta para executar os scripts SQL, como o SQL Server Management Studio.

### 1. Obter o projeto

Clone este repositório e abra o arquivo de solução no Visual Studio.

### 2. Criar o banco e a tabela

Execute o script abaixo uma vez no SQL Server:

```sql
CREATE DATABASE CadastroDB;
GO

USE CadastroDB;
GO

CREATE TABLE dbo.Cadastros
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(150) NOT NULL,
    DataNascimento DATE NOT NULL,
    Salario DECIMAL(9,2) NOT NULL,
    Cargo NVARCHAR(100) NOT NULL,
    Sexo NVARCHAR(10) NOT NULL,

    ValeTransporte BIT NOT NULL DEFAULT 0,
    ValeAlimentacao BIT NOT NULL DEFAULT 0,
    PlanoSaude BIT NOT NULL DEFAULT 0,

    CONSTRAINT CK_Cadastros_Salario
        CHECK (Salario BETWEEN 800.00 AND 9999999.99),

    CONSTRAINT CK_Cadastros_Sexo
        CHECK (Sexo IN (N'Masculino', N'Feminino'))
);
GO
```

### 3. Configurar a conexão

No arquivo `ConexaoBanco.cs`, substitua `SEU_SERVIDOR` pelo nome da sua instância:

```csharp
private static readonly string stringConexao =
    @"Server=SEU_SERVIDOR;Database=CadastroDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
```

A autenticação utiliza o usuário do Windows que executa a aplicação. Esse usuário precisa ter acesso ao banco.

A opção `TrustServerCertificate=True` é utilizada neste exemplo para desenvolvimento local.

### 4. Restaurar as dependências

Na pasta do projeto, execute:

```bash
dotnet restore
```

O projeto utiliza o pacote:

```text
Microsoft.Data.SqlClient
```

### 5. Executar

No Visual Studio, pressione **F5**.

Os registros salvos no banco serão carregados na tela de menu.

## 📚 Aprendizados

Neste projeto, pratiquei:

- Construção de interfaces com Windows Forms.
- Manipulação de eventos de teclado e controles.
- Comunicação entre formulários por construtores.
- Vinculação de dados com `BindingList`.
- Validação e formatação de entradas.
- Operações CRUD no SQL Server.
- Consultas SQL parametrizadas.
- Uso de `async` e `await` no acesso ao banco.
- Tratamento de falhas nas operações de persistência.
- Separação do acesso aos dados em uma classe de repositório.
- Melhoria da interface a partir de testes e feedback.

## 👨‍💻 Autor

**Kauan Fernandes**

Estudante de Engenharia de Software e estagiário em desenvolvimento.

[GitHub](https://github.com/kauanfernandes05) · [LinkedIn](https://www.linkedin.com/in/kauan-fernandes05/)
