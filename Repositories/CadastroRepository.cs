using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using ProjetoForm.Models;
using ProjetoForm.Data;
using Dapper;
using System.Linq;

namespace ProjetoForm.Repositories;

internal class CadastroRepository
{

    // Método para listar todos os cadastros do banco de dados.
    public async Task<List<Cadastro>> ListarAsync()
    {
        using var conexao = ConexaoBanco.CriarConexao();

        await conexao.OpenAsync();

        var registros = await conexao.QueryAsync<Cadastro>(
            "dbo.ListarCadastros",
            commandType: CommandType.StoredProcedure
            );

        return registros.ToList();
    }

    // Repositório responsável por operações de CRUD na tabela de Cadastros.
    public async Task<int> InserirAsync(Cadastro cadastro)
    {
        using var conexao = ConexaoBanco.CriarConexao();

        var parametros = new DynamicParameters();

        parametros.Add(
            "Nome",
            cadastro.Nome,
            DbType.String,
            size: 150
        );

        parametros.Add(
            "DataNascimento",
            cadastro.DataNascimento.Date,
            DbType.Date
        );


        parametros.Add(
            "Salario",
            cadastro.Salario,
            DbType.Decimal,
            precision: 9,
            scale: 2
        );

        parametros.Add(
            "Cargo",
            cadastro.Cargo,
            DbType.String,
            size: 100
        );

        parametros.Add(
            "Sexo",
            cadastro.Sexo,
            DbType.String,
            size: 10
        );

        parametros.Add(
            "ValeTransporte",
            cadastro.ValeTransporte,
            DbType.Boolean
        );

        parametros.Add(
           "ValeAlimentacao",
           cadastro.ValeAlimentacao,
           DbType.Boolean
       );

        parametros.Add(
           "PlanoSaude",
           cadastro.PlanoSaude,
           DbType.Boolean
       );

        await conexao.OpenAsync();

        int? id = await conexao.QuerySingleAsync<int?>(
            "dbo.InserirCadastro",
            parametros,
            commandType: CommandType.StoredProcedure
        );

        if (!id.HasValue)
        {
            throw new InvalidOperationException(
                "A procedure de inclusão de itens não retornou o ID do cadastro."
            );
        }

        return id.Value;
    }


    // Método para atualizar um cadastro existente no banco de dados.
    public async Task<bool> AtualizarAsync(Cadastro cadastro)
    {
        using var conexao = ConexaoBanco.CriarConexao();

        var parametros = new DynamicParameters();

        parametros.Add("Id", cadastro.Id, DbType.Int32);

        parametros.Add(
            "Nome",
            cadastro.Nome,
            DbType.String,
            size: 150
        );

        parametros.Add(
            "DataNascimento",
            cadastro.DataNascimento.Date,
            DbType.Date
        );


        parametros.Add(
            "Salario",
            cadastro.Salario,
            DbType.Decimal,
            precision: 9,
            scale: 2
        );

        parametros.Add(
            "Cargo",
            cadastro.Cargo,
            DbType.String,
            size: 100
        );

        parametros.Add(
            "Sexo",
            cadastro.Sexo,
            DbType.String,
            size: 10
        );

        parametros.Add(
            "ValeTransporte",
            cadastro.ValeTransporte,
            DbType.Boolean
        );

        parametros.Add(
           "ValeAlimentacao",
           cadastro.ValeAlimentacao,
           DbType.Boolean
       );

        parametros.Add(
           "PlanoSaude",
           cadastro.PlanoSaude,
           DbType.Boolean
       );

        await conexao.OpenAsync();

        bool? atualizado = await conexao.QuerySingleAsync<bool?>(
            "dbo.AtualizarCadastro",
            parametros,
            commandType: CommandType.StoredProcedure
        );

        if (!atualizado.HasValue)
        {
            throw new InvalidOperationException(
                "A procedure não retornou a confirmação da atualização."
            );
        }

        return atualizado.Value;
    }

    // Método para remover um cadastro do banco de dados pelo Id.
    public async Task<bool> RemoverAsync(int id)
    {

        using var conexao = ConexaoBanco.CriarConexao();

        var parametros = new DynamicParameters();

        parametros.Add("Id", id, DbType.Int32);

        await conexao.OpenAsync();

        bool? removido = await conexao.QuerySingleAsync<bool?>(
            "dbo.RemoverCadastro",
            parametros,
            commandType: CommandType.StoredProcedure
        );

        if (!removido.HasValue)
        {
            throw new InvalidOperationException(
                "A procedure não retornou a confirmação da Remoção."
            );
        }

        return removido.Value;
    }

    // Método responsavel por gerar o relatório com base nos filtros
    public async Task<List<Cadastro>> ListarParaRelatorioAsync(FiltroRelatorio filtro)
    {

        using var conexao = ConexaoBanco.CriarConexao();

        var parametros = new DynamicParameters();

        parametros.Add("IdInicial", filtro.IdInicial, DbType.Int32);
        parametros.Add("IdFinal", filtro.IdFinal, DbType.Int32);

        parametros.Add(
            "Nome",
            filtro.Nome,
            DbType.String,
            size: 150
        );

        parametros.Add(
            "NascimentoInicial",
            filtro.NascimentoInicial?.Date,
            DbType.Date
        );

        parametros.Add(
            "NascimentoFinal",
            filtro.NascimentoFinal?.Date,
            DbType.Date
        );


        parametros.Add(
            "SalarioMinimo",
            filtro.SalarioMinimo,
            DbType.Decimal,
            precision: 9,
            scale: 2
        );

        parametros.Add(
            "SalarioMaximo",
            filtro.SalarioMaximo,
            DbType.Decimal,
            precision: 9,
            scale: 2
        );

        parametros.Add(
            "Cargo",
            filtro.Cargo,
            DbType.String,
            size: 100
        );

        parametros.Add(
            "Sexo",
            filtro.Sexo,
            DbType.String,
            size: 10
        );

        parametros.Add(
            "ValeTransporte",
            filtro.ValeTransporte,
            DbType.Boolean
        );

        parametros.Add(
           "ValeAlimentacao",
           filtro.ValeAlimentacao,
           DbType.Boolean
       );

        parametros.Add(
           "PlanoSaude",
           filtro.PlanoSaude,
           DbType.Boolean
       );

        await conexao.OpenAsync();

        var registros = await conexao.QueryAsync<Cadastro>(
            "dbo.ListarCadastrosRelatorio",
            parametros,
            commandType : CommandType.StoredProcedure
        );

        return registros.ToList();
    }
}