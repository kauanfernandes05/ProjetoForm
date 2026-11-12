using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ProjetoForm;

internal class CadastroRepository
{
    // Repositório responsável por operações de CRUD na tabela de Cadastros.
    public async Task<int> InserirAsync(Cadastro cadastro)
    {
        const string sql = """
            INSERT INTO dbo.Cadastros
            (
                Nome,
                DataNascimento,
                Salario,
                Cargo,
                Sexo,
                ValeTransporte,
                ValeAlimentacao,
                PlanoSaude
            )
            OUTPUT INSERTED.Id
            VALUES
            (
                @Nome,
                @DataNascimento,
                @Salario,
                @Cargo,
                @Sexo,
                @ValeTransporte,
                @ValeAlimentacao,
                @PlanoSaude
            );
            """;

        using var conexao = ConexaoBanco.CriarConexao();
        using var comando = new SqlCommand(sql, conexao);

        comando.Parameters.Add(
            "@Nome", SqlDbType.NVarChar, 150
        ).Value = cadastro.Nome;

        comando.Parameters.Add(
            "@DataNascimento", SqlDbType.Date
        ).Value = cadastro.DataNascimento.Date;

        SqlParameter parametroSalario =
            comando.Parameters.Add("@Salario", SqlDbType.Decimal);

        parametroSalario.Precision = 9;
        parametroSalario.Scale = 2;
        parametroSalario.Value = cadastro.Salario;

        comando.Parameters.Add(
            "@Cargo", SqlDbType.NVarChar, 100
        ).Value = cadastro.Cargo;

        comando.Parameters.Add(
            "@Sexo", SqlDbType.NVarChar, 10
        ).Value = cadastro.Sexo;

        comando.Parameters.Add(
            "@ValeTransporte", SqlDbType.Bit
        ).Value = cadastro.ValeTransporte;

        comando.Parameters.Add(
            "@ValeAlimentacao", SqlDbType.Bit
        ).Value = cadastro.ValeAlimentacao;

        comando.Parameters.Add(
            "@PlanoSaude", SqlDbType.Bit
        ).Value = cadastro.PlanoSaude;

        await conexao.OpenAsync();

        object resultado = await comando.ExecuteScalarAsync();

        return Convert.ToInt32(resultado);

    }

    // Método para listar todos os cadastros do banco de dados.
    public async Task<List<Cadastro>> ListarAsync()
    {
        const string sql = """
        SELECT
            Id,
            Nome,
            DataNascimento,
            Salario,
            Cargo,
            Sexo,
            ValeTransporte,
            ValeAlimentacao,
            PlanoSaude
        FROM dbo.Cadastros
        ORDER BY Id;
        """;

        List<Cadastro> registros = new List<Cadastro>();

        using var conexao = ConexaoBanco.CriarConexao();
        using var comando = new Microsoft.Data.SqlClient.SqlCommand(
            sql,
            conexao
        );

        await conexao.OpenAsync();

        using var leitor = await comando.ExecuteReaderAsync();

        while (await leitor.ReadAsync())
        {
            Cadastro cadastro = new Cadastro
            {
                Id = leitor.GetInt32(0),
                Nome = leitor.GetString(1),
                DataNascimento = leitor.GetDateTime(2),
                Salario = leitor.GetDecimal(3),
                Cargo = leitor.GetString(4),
                Sexo = leitor.GetString(5),
                ValeTransporte = leitor.GetBoolean(6),
                ValeAlimentacao = leitor.GetBoolean(7),
                PlanoSaude = leitor.GetBoolean(8)
            };

            registros.Add(cadastro);
        }

        return registros;
    }

    // Método para atualizar um cadastro existente no banco de dados.
    public async Task<bool> AtualizarAsync(Cadastro cadastro)
    {
        const string sql = """
        UPDATE dbo.Cadastros
        SET
            Nome = @Nome,
            DataNascimento = @DataNascimento,
            Salario = @Salario,
            Cargo = @Cargo,
            Sexo = @Sexo,
            ValeTransporte = @ValeTransporte,
            ValeAlimentacao = @ValeAlimentacao,
            PlanoSaude = @PlanoSaude
        WHERE Id = @Id;
        """;

        using var conexao = ConexaoBanco.CriarConexao();
        using var comando = new SqlCommand(sql, conexao);

        comando.Parameters.Add("@Id", SqlDbType.Int).Value =
            cadastro.Id;

        comando.Parameters.Add("@Nome", SqlDbType.NVarChar, 150).Value =
            cadastro.Nome;

        comando.Parameters.Add("@DataNascimento", SqlDbType.Date).Value =
            cadastro.DataNascimento.Date;

        SqlParameter parametroSalario =
            comando.Parameters.Add("@Salario", SqlDbType.Decimal);

        parametroSalario.Precision = 9;
        parametroSalario.Scale = 2;
        parametroSalario.Value = cadastro.Salario;

        comando.Parameters.Add("@Cargo", SqlDbType.NVarChar, 100).Value =
            cadastro.Cargo;

        comando.Parameters.Add("@Sexo", SqlDbType.NVarChar, 10).Value =
            cadastro.Sexo;

        comando.Parameters.Add("@ValeTransporte", SqlDbType.Bit).Value =
            cadastro.ValeTransporte;

        comando.Parameters.Add("@ValeAlimentacao", SqlDbType.Bit).Value =
            cadastro.ValeAlimentacao;

        comando.Parameters.Add("@PlanoSaude", SqlDbType.Bit).Value =
            cadastro.PlanoSaude;

        await conexao.OpenAsync();

        int linhasAfetadas = await comando.ExecuteNonQueryAsync();

        return linhasAfetadas > 0;
    }

    // Método para remover um cadastro do banco de dados pelo Id.
    public async Task<bool> RemoverAsync(int id)
    {
        const string sql = """
        DELETE FROM dbo.Cadastros
        WHERE Id = @Id;
        """;

        using var conexao = ConexaoBanco.CriarConexao();
        using var comando = new SqlCommand(sql, conexao);

        comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;

        await conexao.OpenAsync();

        int linhasAfetadas = await comando.ExecuteNonQueryAsync();

        return linhasAfetadas > 0;
    }
}