using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoForm
{
    public partial class FrmMenu : Form
    {
        // Impede que o Tab seja usado para navegar entre os controles do formulário.
        protected override bool ProcessCmdKey(
           ref Message msg,
           Keys keyData)
        {
            if ((keyData & Keys.KeyCode) == Keys.Tab)
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Lista de cadastros.
        private readonly System.ComponentModel.BindingList<Cadastro> cadastros =
        new System.ComponentModel.BindingList<Cadastro>();
        public FrmMenu()
        {
            InitializeComponent();
            ConfigurarTabela();

            dgvCadastrados.CellFormatting -= dgvCadastrados_CellFormatting;
            dgvCadastrados.CellFormatting += dgvCadastrados_CellFormatting;

            txtFiltroNome.TextChanged -= txtFiltroNome_TextChanged;
            txtFiltroNome.TextChanged += txtFiltroNome_TextChanged;

            Shown -= TestarConexao;
            Shown += TestarConexao;

            Shown -= FormMenu_Shown;
            Shown += FormMenu_Shown;

            // Atualiza o filtro ao adicionar, editar ou remover.
            cadastros.ListChanged += (s, e) => AplicarFiltro();

            AplicarFiltro();
        }

        // Configurações do DataGridView.
        private void ConfigurarTabela()
        {
            dgvCadastrados.AutoGenerateColumns = false;
            dgvCadastrados.Columns.Clear();

            dgvCadastrados.Columns.Add(
            new DataGridViewTextBoxColumn
            {
                Name = "clnNumero",
                HeaderText = "Nº",
                Width = 50,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            }
            );
            dgvCadastrados.Columns["clnNumero"]
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            dgvCadastrados.Columns.Add("clnId", "ID NO BANCO");
            dgvCadastrados.Columns.Add("clnNome", "Nome");
            dgvCadastrados.Columns.Add("clnDataNsc", "Data de Nascimento");
            dgvCadastrados.Columns.Add("clnSalario", "Salário");
            dgvCadastrados.Columns.Add("clnCargo", "Cargo");
            dgvCadastrados.Columns.Add("clnSexo", "Sexo");
            dgvCadastrados.Columns.Add("clnBeneficios", "Benefícios");

            // Liga cada coluna à propriedade da classe Cadastro.
            dgvCadastrados.Columns["clnId"].DataPropertyName =
                nameof(Cadastro.Id);

            dgvCadastrados.Columns["clnNome"].DataPropertyName =
                nameof(Cadastro.Nome);

            dgvCadastrados.Columns["clnDataNsc"].DataPropertyName =
                nameof(Cadastro.DataNascimento);

            dgvCadastrados.Columns["clnSalario"].DataPropertyName =
                nameof(Cadastro.Salario);

            dgvCadastrados.Columns["clnCargo"].DataPropertyName =
                nameof(Cadastro.Cargo);

            dgvCadastrados.Columns["clnSexo"].DataPropertyName =
                nameof(Cadastro.Sexo);

            dgvCadastrados.Columns["clnBeneficios"].DataPropertyName =
                nameof(Cadastro.Beneficios);

            dgvCadastrados.ReadOnly = true;
            dgvCadastrados.AllowUserToAddRows = false;
            dgvCadastrados.AllowUserToDeleteRows = false;

            dgvCadastrados.MultiSelect = false;
            dgvCadastrados.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCadastrados.RowHeadersVisible = false;
            dgvCadastrados.ColumnHeadersVisible = true;
            dgvCadastrados.CellBorderStyle =
                DataGridViewCellBorderStyle.Single;

            dgvCadastrados.AllowUserToResizeColumns = true;
            dgvCadastrados.AllowUserToResizeRows = false;
            dgvCadastrados.AllowUserToOrderColumns = true;

            dgvCadastrados.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgvCadastrados.ScrollBars = ScrollBars.Both;

            // Larguras iniciais.
            dgvCadastrados.Columns["clnId"].Width = 60;
            dgvCadastrados.Columns["clnNome"].Width = 200;
            dgvCadastrados.Columns["clnDataNsc"].Width = 110;
            dgvCadastrados.Columns["clnSalario"].Width = 120;
            dgvCadastrados.Columns["clnCargo"].Width = 170;
            dgvCadastrados.Columns["clnSexo"].Width = 100;
            dgvCadastrados.Columns["clnBeneficios"].Width = 280;

            // Formatação.
            dgvCadastrados.Columns["clnId"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvCadastrados.Columns["clnDataNsc"].DefaultCellStyle.Format =
                "dd/MM/yyyy";

            dgvCadastrados.Columns["clnDataNsc"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCadastrados.Columns["clnSalario"].DefaultCellStyle.Format =
                "C2";

            dgvCadastrados.Columns["clnSalario"].DefaultCellStyle.FormatProvider =
                CultureInfo.GetCultureInfo("pt-BR");

            dgvCadastrados.Columns["clnSalario"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvCadastrados.Columns["clnNumero"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvCadastrados.DataSource = cadastros;
        }

        // Botões do menu.
        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (FormPrincipal formulario = new FormPrincipal(cadastros))
            {
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.ShowDialog(this);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCadastrados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione o cadastro que deseja editar.");
                return;
            }

            Cadastro cadastroSelecionado =
                dgvCadastrados.SelectedRows[0].DataBoundItem as Cadastro;

            if (cadastroSelecionado == null)
                return;

            using (FormPrincipal formulario =
                new FormPrincipal(cadastros, cadastroSelecionado))
            {
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.ShowDialog(this);
            }
        }
        private async void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvCadastrados.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    this,
                    "Selecione o cadastro que deseja remover.",
                    "Selecione um cadastro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            Cadastro cadastroSelecionado =
                dgvCadastrados.SelectedRows[0].DataBoundItem as Cadastro;

            if (cadastroSelecionado == null)
                return;

            DialogResult resposta = MessageBox.Show(
                this,
                $"Deseja remover o usuário \"{cadastroSelecionado.Nome}\"?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (resposta != DialogResult.Yes)
                return;

            btnRemover.Enabled = false;
            btnEditar.Enabled = false;
            btnNovo.Enabled = false;

            try
            {
                CadastroRepository repositorio = new CadastroRepository();

                bool removido =
                    await repositorio.RemoverAsync(cadastroSelecionado.Id);

                if (!removido)
                {
                    MessageBox.Show(
                        this,
                        "O cadastro não foi encontrado no banco de dados.",
                        "Cadastro não encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Só remove da lista após excluir no banco.
                cadastros.Remove(cadastroSelecionado);

                AplicarFiltro();
                dgvCadastrados.ClearSelection();

                MessageBox.Show(
                    this,
                    $"Usuário \"{cadastroSelecionado.Nome}\" removido com sucesso!",
                    "Exclusão concluída",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(
                    this,
                    "Não foi possível remover o cadastro do banco.\n\n" +
                    ex.Message,
                    "Erro ao remover",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnRemover.Enabled = true;
                btnEditar.Enabled = true;
                btnNovo.Enabled = true;
            }
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                this,
                "Deseja realmente fechar o programa?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Aplica o filtro de pesquisa no DataGridView.
        private void AplicarFiltro()
        {
            string pesquisa = txtFiltroNome.Text.Trim();

            if (string.IsNullOrEmpty(pesquisa))
            {
                dgvCadastrados.DataSource = cadastros;
            }
            else
            {
                dgvCadastrados.DataSource = cadastros
                    .Where(cadastro =>
                        cadastro.Nome.IndexOf(
                            pesquisa,
                            StringComparison.CurrentCultureIgnoreCase
                        ) >= 0)
                    .ToList();
            }

            dgvCadastrados.ClearSelection();
        }
        private void txtFiltroNome_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // Evento de duplo clique na linha para edição do item selecionado.
        private void dgvCadastrados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           var cadastroSelecionado = dgvCadastrados.SelectedRows[0].DataBoundItem as Cadastro;
            if (cadastroSelecionado == null)
                return;

            using (FormPrincipal formulario =
                new FormPrincipal(cadastros, cadastroSelecionado))
            {
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.ShowDialog(this);
            }
        }


        // testa conexão com o banco de dados
        private async void TestarConexao(object sender, EventArgs e)
        {
            try
            {
                using var conexao = ConexaoBanco.CriarConexao();

                await conexao.OpenAsync();

                MessageBox.Show(
                    "Conexão com o banco realizada com sucesso!"
                );
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Não foi possível conectar ao banco:\n" + erro.Message
                );
            }
        }

        // Carrega os registros do banco de dados ao abrir o formulário.
        private async void FormMenu_Shown(object sender, EventArgs e)
        {
            try
            {
                // Bloqueia as ações enquanto carrega os registros.
                btnNovo.Enabled = false;
                btnEditar.Enabled = false;
                btnRemover.Enabled = false;

                CadastroRepository repositorio = new CadastroRepository();

                var registros = await repositorio.ListarAsync();

                // Mantém a mesma lista compartilhada com a tela de cadastro.
                cadastros.RaiseListChangedEvents = false;

                try
                {
                    cadastros.Clear();

                    foreach (Cadastro cadastro in registros)
                    {
                        cadastros.Add(cadastro);
                    }
                }
                finally
                {
                    cadastros.RaiseListChangedEvents = true;
                    cadastros.ResetBindings();
                }

                AplicarFiltro();
                dgvCadastrados.ClearSelection();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(
                    this,
                    "Não foi possível carregar os cadastros.\n\n" + ex.Message,
                    "Erro ao consultar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnNovo.Enabled = true;
                btnEditar.Enabled = true;
                btnRemover.Enabled = true;
            }
        }

        // Formata a coluna de número do DataGridView.
        private void dgvCadastrados_CellFormatting(
        object sender,
        DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvCadastrados.Columns[e.ColumnIndex].Name == "clnNumero")
            {
                e.Value = (e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            }
        }
    }
}
