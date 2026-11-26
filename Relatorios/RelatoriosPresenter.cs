using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjetoForm.Models;

namespace ProjetoForm.Relatorios;

public class RelatoriosPresenter
{
    private readonly IRelatoriosView view;
    private readonly RelatorioService servico;
    private bool gerando;

    public RelatoriosPresenter(IRelatoriosView view,RelatorioService servico)
    {
        this.view = view;
        this.servico = servico;
    }

    public async Task GerarRelatorioAsync()
    {
        if (gerando)
            return;

        gerando = true;

        try
        {
            if (!view.TentarObterFiltros(out FiltroRelatorio filtro)) return;

            var cargos = view.ObterCargosSelecionados();
            var ordenacao = view.ObterOrdenacaoSelecionada();

            view.DefinirCarregamento(true);

            var registros = await servico.ConsultarAsync(filtro,cargos);

            if (registros.Count == 0)
            {
                view.MostrarAviso("Nenhum cadastro encontrado para os filtros informados.");

                return;
            }

            registros = servico.Ordenar(registros, ordenacao);

            view.ExibirPrevia(registros, filtro, cargos);
        }
        catch (SqlException ex)
        {
            view.MostrarErro("Não foi possível consultar os dados do relatório.\n\n" + ex.Message);
        }
        finally
        {
            view.DefinirCarregamento(false);
            gerando = false;
        }
    }
}