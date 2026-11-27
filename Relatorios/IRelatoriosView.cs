using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using ProjetoForm.Models;

namespace ProjetoForm.Relatorios;


public interface IRelatoriosView
{
    bool TentarObterFiltros(out FiltroRelatorio filtro);

    List<string> ObterCargosSelecionados();

    OrdenacaoRelatorio ObterOrdenacaoSelecionada();
    void DefinirCarregamento(bool carregando);

    void MostrarAviso(string mensagem);
    void MostrarErro(string mensagem);

    void ExibirPrevia(List<Cadastro> registros, FiltroRelatorio filtro, List<string> cargosSelecionados);
}
