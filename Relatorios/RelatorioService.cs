using ProjetoForm.Models;
using ProjetoForm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoForm.Relatorios;

public class RelatorioService
{
    public async Task<List<Cadastro>> ConsultarAsync(FiltroRelatorio filtro, IEnumerable<string> cargosSelecionados)
    {
        var repositorio = new CadastroRepository();

        List<string> cargos = cargosSelecionados.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();

        if (cargos.Count == 0)
        {
            return await repositorio.ListarParaRelatorioAsync(filtro);
        }

        List<Cadastro> registros = new List<Cadastro>();

        // Guarda o valor original para restaurá-lo mesmo se a consulta falhar.
        string? cargoOriginal = filtro.Cargo;

        try
        {
            foreach (string cargo in cargos)
            {
                filtro.Cargo = cargo;

                registros.AddRange(await repositorio.ListarParaRelatorioAsync(filtro));
            }
        }
        finally
        {
            filtro.Cargo = cargoOriginal;
        }

        return registros
            .GroupBy(cadastro => cadastro.Id)
            .Select(grupo => grupo.First())
            .OrderBy(cadastro => cadastro.Id)
            .ToList();
    }

    public List<Cadastro> Ordenar(List<Cadastro> registros,OrdenacaoRelatorio ordenacao)
    {
        switch (ordenacao)
        {
            case OrdenacaoRelatorio.Nome:
                return registros.OrderBy(cadastro => cadastro.Nome,StringComparer.CurrentCultureIgnoreCase)
                    .ThenBy(cadastro => cadastro.Id)
                    .ToList();

            case OrdenacaoRelatorio.Nascimento:
                return registros
                    .OrderBy(cadastro => cadastro.DataNascimento)
                    .ThenBy(cadastro => cadastro.Id)
                    .ToList();

            case OrdenacaoRelatorio.Salario:
                return registros
                    .OrderByDescending(cadastro => cadastro.Salario)
                    .ThenBy(cadastro => cadastro.Id)
                    .ToList();

            default:
                return registros.OrderBy(cadastro => cadastro.Id).ToList();
        }
    }

}
