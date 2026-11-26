using ProjetoForm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoForm.Forms;

public interface ICadastroView
{
    bool TentarObterCadastro(out Cadastro cadastro);

    Cadastro? OnbterCadastroEmEdicao();

    bool ConfirmarSalvamento(string nome, bool editando);

    void DefinirSalvamento(bool salvando);

    void MostrarAviso(string mensagem);

    void MostrarErro(String mensagem);

    void ConcluirSalvamento(Cadastro cadastro, Cadastro? cadastroOriginal);
}
