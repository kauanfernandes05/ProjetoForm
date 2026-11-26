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
using System.Diagnostics;
using ProjetoForm.Models;
using ProjetoForm.Repositories;

namespace ProjetoForm
{
    public partial class FrmMenu : Form
    {
        // Estado do formulário e lista compartilhada com a tela de cadastro.
        private readonly BindingList<Cadastro> cadastros = new();
        private string colunaOrdenada = "";
        private bool ordemCrescente = true;

        // Inicialização e configuração.

        public FrmMenu()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarTabela();
            ConectarEventos();
            ConfigurarCliquesForaDaLista(this);
        }

        private void ConfigurarFormulario()
        {
            MaximizeBox = false;
            KeyPreview = true;
            txtFiltroID.MaxLength = 7;
        }

        private void ConectarEventos()
        {
            Shown -= FormMenu_Shown;
            Shown += FormMenu_Shown;

            KeyDown -= FrmMenu_KeyDown;
            KeyDown += FrmMenu_KeyDown;

            txtFiltroCargo.TextChanged -= txtFiltroCargo_TextChanged;
            txtFiltroCargo.TextChanged += txtFiltroCargo_TextChanged;

            txtFiltroID.KeyPress -= txtFiltroID_KeyPress;
            txtFiltroID.KeyPress += txtFiltroID_KeyPress;

            txtFiltroID.KeyDown -= CamposPesquisa_KeyDown;
            txtFiltroID.KeyDown += CamposPesquisa_KeyDown;
            txtFiltroNome.KeyDown -= CamposPesquisa_KeyDown;
            txtFiltroNome.KeyDown += CamposPesquisa_KeyDown;
            txtFiltroCargo.KeyDown -= CamposPesquisa_KeyDown;
            txtFiltroCargo.KeyDown += CamposPesquisa_KeyDown;

            txtFiltroCargo.KeyDown -= CamposPesquisa_KeyDown;
            txtFiltroCargo.KeyDown += CamposPesquisa_KeyDown;

            lstFiltroCargos.Click -= lstFiltroCargos_Click;
            lstFiltroCargos.Click += lstFiltroCargos_Click;

            lstFiltroCargos.KeyDown -= lstFiltroCargos_KeyDown;
            lstFiltroCargos.KeyDown += lstFiltroCargos_KeyDown;

            txtFiltroCargo.Enter -= txtFiltroCargo_Enter;
            txtFiltroCargo.Enter += txtFiltroCargo_Enter;

            btnPesquisar.KeyDown -= btnPesquisar_KeyDown;
            btnPesquisar.KeyDown += btnPesquisar_KeyDown;

            txtFiltroCargo.Leave -= OcultarListaCargosAoSair;
            txtFiltroCargo.Leave += OcultarListaCargosAoSair;

            lstFiltroCargos.Leave -= OcultarListaCargosAoSair;
            lstFiltroCargos.Leave += OcultarListaCargosAoSair;

            btnNovo.Click -= btnNovo_Click;
            btnNovo.Click += btnNovo_Click;
            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;
            btnRemover.Click -= btnRemover_Click;
            btnRemover.Click += btnRemover_Click;
            btnFechar.Click -= btnFechar_Click;
            btnFechar.Click += btnFechar_Click;
            btnPesquisar.Click -= btnPesquisar_Click;
            btnPesquisar.Click += btnPesquisar_Click;

            dgvCadastrados.CellDoubleClick -= dgvCadastrados_CellDoubleClick;
            dgvCadastrados.CellDoubleClick += dgvCadastrados_CellDoubleClick;
            dgvCadastrados.ColumnHeaderMouseClick -= OrdenarColuna;
            dgvCadastrados.ColumnHeaderMouseClick += OrdenarColuna;
        }

        private void ConfigurarTabela()
        {
            dgvCadastrados.AutoGenerateColumns = false;
            dgvCadastrados.Columns.Clear();

            dgvCadastrados.Columns.Add("clnID", "ID");
            dgvCadastrados.Columns.Add("clnNome", "Nome");
            dgvCadastrados.Columns.Add(
                "clnDataNsc",
                "Data de Nascimento"
            );
            dgvCadastrados.Columns.Add("clnSalario", "Salário");
            dgvCadastrados.Columns.Add("clnCargo", "Cargo");
            dgvCadastrados.Columns.Add("clnSexo", "Sexo");
            dgvCadastrados.Columns.Add(
                "clnBeneficios",
                "Benefícios"
            );

            // Liga as colunas às propriedades da classe Cadastro.
            dgvCadastrados.Columns["clnID"].DataPropertyName =
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

            dgvCadastrados.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCadastrados.ScrollBars = ScrollBars.Both;

            // Larguras iniciais.
            dgvCadastrados.Columns["clnID"].Width = 60;
            dgvCadastrados.Columns["clnNome"].Width = 200;
            dgvCadastrados.Columns["clnDataNsc"].Width = 110;
            dgvCadastrados.Columns["clnSalario"].Width = 120;
            dgvCadastrados.Columns["clnCargo"].Width = 170;
            dgvCadastrados.Columns["clnSexo"].Width = 100;
            dgvCadastrados.Columns["clnBeneficios"].Width = 280;

            // Formatação.
            dgvCadastrados.Columns["clnID"]
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            dgvCadastrados.Columns["clnDataNsc"]
                .DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvCadastrados.Columns["clnDataNsc"]
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            dgvCadastrados.Columns["clnSalario"]
                .DefaultCellStyle.Format = "C2";

            dgvCadastrados.Columns["clnSalario"]
                .DefaultCellStyle.FormatProvider =
                    CultureInfo.GetCultureInfo("pt-BR");

            dgvCadastrados.Columns["clnSalario"]
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

            dgvCadastrados.DataSource = cadastros;

            // Permite ordenar pelo clique no título de cada coluna. 
            foreach (DataGridViewColumn coluna in dgvCadastrados.Columns)
            {
                coluna.SortMode = DataGridViewColumnSortMode.Programmatic;
                coluna.HeaderCell.ToolTipText =
                    "Clique para ordenar. Clique novamente para inverter a ordem.";
            }


        }

        private async void FormMenu_Shown(object? sender, EventArgs e)
        {
            lblCarregando.Visible = true;
            lblCarregando.BringToFront();

            UseWaitCursor = true;

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnRemover.Enabled = false;
            dgvCadastrados.Enabled = false;
            btnPesquisar.Enabled = false;
            txtFiltroID.Enabled = false;
            txtFiltroCargo.Enabled = false;
            txtFiltroNome.Enabled = false;


            await System.Threading.Tasks.Task.Yield();

            try
            {
                CadastroRepository repositorio =
                    new CadastroRepository();

                var registros = await repositorio.ListarAsync();

                // Preserva a mesma lista compartilhada entre as telas.
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
                    dgvCadastrados.ClearSelection();
                }


            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(
                    this,
                    "Não foi possível carregar os cadastros.\n\n" +
                    ex.Message,
                    "Erro ao consultar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                lblCarregando.Visible = false;
                UseWaitCursor = false;

                btnPesquisar.Enabled = true;
                txtFiltroID.Enabled = true;
                txtFiltroCargo.Enabled = true;
                txtFiltroNome.Enabled = true;
                btnNovo.Enabled = true;
                btnEditar.Enabled = true;
                btnRemover.Enabled = true;
                dgvCadastrados.Enabled = true;
            }
            txtFiltroID.Focus();
        }

        // Operações de cadastro e pesquisa.

        private void AbrirEdicao(Cadastro cadastroSelecionado)
        {
            using (FormCadastro formulario =
                new FormCadastro(cadastros, cadastroSelecionado))
            {
                formulario.StartPosition =
                    FormStartPosition.CenterParent;

                formulario.ShowDialog(this);
            }
        }

        private void PesquisarCadastros(bool exibirMensagem = true)
        {
            string textoId = txtFiltroID.Text.Trim();
            string nome = txtFiltroNome.Text.Trim();
            string cargo = txtFiltroCargo.Text.Trim();

            var resultado = cadastros.AsEnumerable();

            // Filtra pelo ID exato.
            if (!string.IsNullOrWhiteSpace(textoId))
            {
                if (!int.TryParse(textoId, out int id) || id <= 0)
                {
                    MessageBox.Show(
                        this,
                        "Informe um ID válido.",
                        "Pesquisa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtFiltroID.Focus();
                    return;
                }

                resultado = resultado.Where(cadastro =>
                    cadastro.Id == id);
            }

            // Filtra pelo nome.
            if (!string.IsNullOrWhiteSpace(nome))
            {
                resultado = resultado.Where(cadastro =>
                    cadastro.Nome.Contains(
                        nome,
                        StringComparison.CurrentCultureIgnoreCase
                    ));
            }

            // Filtra pelo cargo.
            if (!string.IsNullOrWhiteSpace(cargo))
            {
                resultado = resultado.Where(cadastro =>
                    cadastro.Cargo.Contains(
                        cargo,
                        StringComparison.CurrentCultureIgnoreCase
                    ));
            }

            var encontrados = resultado.ToList();

            bool possuiFiltro =
                textoId.Length > 0 ||
                nome.Length > 0 ||
                cargo.Length > 0;

            // Mostra somente os registros que atendem a todos os filtros.
            dgvCadastrados.DataSource = possuiFiltro
                ? encontrados
                : cadastros;

            RedefinirOrdenacao();
            dgvCadastrados.ClearSelection();

            if (exibirMensagem && possuiFiltro && encontrados.Count == 0)
            {
                MessageBox.Show(
                    this,
                    "Cadastro não encontrado.",
                    "Pesquisa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void LimparCamposPesquisa()
        {
            txtFiltroID.Clear();
            txtFiltroNome.Clear();
            txtFiltroCargo.Clear();
        }

        private void RedefinirOrdenacao()
        {
            colunaOrdenada = "";
            ordemCrescente = true;

            foreach (DataGridViewColumn coluna in dgvCadastrados.Columns)
            {
                coluna.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
        }

        private void SelecionarCadastro(int id)
        {
            // Limpa a pesquisa para garantir que o novo cadastro apareça.
            LimparCamposPesquisa();

            dgvCadastrados.DataSource = cadastros;
            RedefinirOrdenacao();
            dgvCadastrados.ClearSelection();

            foreach (DataGridViewRow linha in dgvCadastrados.Rows)
            {
                if (linha.DataBoundItem is Cadastro cadastro &&
                    cadastro.Id == id)
                {
                    dgvCadastrados.CurrentCell = linha.Cells["clnID"];
                    linha.Selected = true;

                    // Rola a tabela até o registro selecionado.
                    dgvCadastrados.FirstDisplayedScrollingRowIndex =
                        linha.Index;

                    dgvCadastrados.Focus();
                    break;
                }
            }
        }

        // Ordenação da tabela.

        private void OrdenarColuna(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            DataGridViewColumn coluna =
                dgvCadastrados.Columns[e.ColumnIndex];

            var propriedade = typeof(Cadastro).GetProperty(
                coluna.DataPropertyName
            );

            if (propriedade == null)
                return;

            // Alterna a direção ao clicar novamente na mesma coluna.
            if (colunaOrdenada == coluna.Name)
            {
                ordemCrescente = !ordemCrescente;
            }
            else
            {
                colunaOrdenada = coluna.Name;
                ordemCrescente = true;
            }

            // Usa os registros exibidos para preservar a pesquisa.
            var registros = dgvCadastrados.Rows
                .Cast<DataGridViewRow>()
                .Where(linha => !linha.IsNewRow)
                .Select(linha => linha.DataBoundItem)
                .OfType<Cadastro>()
                .ToList();

            dgvCadastrados.DataSource = ordemCrescente
                ? registros.OrderBy(cadastro =>
                    propriedade.GetValue(cadastro)).ToList()
                : registros.OrderByDescending(cadastro =>
                    propriedade.GetValue(cadastro)).ToList();

            // Remove a seta das outras colunas.
            foreach (DataGridViewColumn item in dgvCadastrados.Columns)
            {
                item.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            // Mostra a direção na coluna clicada.
            coluna.HeaderCell.SortGlyphDirection = ordemCrescente
                ? SortOrder.Ascending
                : SortOrder.Descending;

            dgvCadastrados.ClearSelection();
        }

        // Eventos dos botões.

        private void btnNovo_Click(object? sender, EventArgs e)
        {
            using (FormCadastro formulario = new FormCadastro(cadastros))
            {
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.ShowDialog(this);

                if (formulario.UltimoIdCadastrado is int id)
                {
                    SelecionarCadastro(id);
                }
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            if (dgvCadastrados.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    this,
                    "Selecione o cadastro que deseja editar.",
                    "Selecione um cadastro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            if (dgvCadastrados.SelectedRows[0].DataBoundItem
                is not Cadastro cadastroSelecionado)
            {
                return;
            }

            AbrirEdicao(cadastroSelecionado);
        }

        private async void btnRemover_Click(object? sender, EventArgs e)
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

            if (dgvCadastrados.SelectedRows[0].DataBoundItem
                is not Cadastro cadastroSelecionado)
            {
                return;
            }

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
            dgvCadastrados.Enabled = false;

            try
            {
                CadastroRepository repositorio =
                    new CadastroRepository();

                bool removido = await repositorio.RemoverAsync(
                    cadastroSelecionado.Id
                );

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

                cadastros.Remove(cadastroSelecionado);

                PesquisarCadastros(exibirMensagem: false);

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
                dgvCadastrados.Enabled = true;
            }
        }

        private void btnFechar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                this,
                "Deseja realmente fechar o programa?",
                "Confirmar saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (resposta != DialogResult.Yes)
                e.Cancel = true;

            base.OnFormClosing(e);
        }

        private void btnPesquisar_Click(object? sender, EventArgs e)
        {
            PesquisarCadastros();
            LimparCamposPesquisa();
            txtFiltroID.Focus();
        }

        // Eventos da tabela.

        private void dgvCadastrados_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (!btnEditar.Enabled ||
                e.RowIndex < 0 ||
                e.RowIndex >= dgvCadastrados.Rows.Count)
            {
                return;
            }

            if (dgvCadastrados.Rows[e.RowIndex].DataBoundItem
                is Cadastro cadastroSelecionado)
            {
                AbrirEdicao(cadastroSelecionado);
            }
        }

        // Navegação e atalhos de teclado.

        private void FrmMenu_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Modifiers != Keys.None)
                return;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    if (dgvCadastrados.ContainsFocus)
                    {
                        dgvCadastrados.ClearSelection();
                        txtFiltroID.Focus();
                    }
                    else
                    {
                        btnFechar.PerformClick();
                    }
                    break;

                case Keys.F2:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    btnNovo.PerformClick();
                    break;

                case Keys.F3:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    btnEditar.PerformClick();
                    break;

                case Keys.F4:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    LimparCamposPesquisa();
                    dgvCadastrados.DataSource = cadastros;
                    RedefinirOrdenacao();
                    dgvCadastrados.ClearSelection();
                    txtFiltroID.Focus();
                    break;

                case Keys.F5:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    btnRelatorios.PerformClick();
                    break;

                case Keys.Delete:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    btnRemover.PerformClick();
                    break;
            }
        }

        private void CamposPesquisa_KeyDown(object? sender, KeyEventArgs e)
        {
            // Entra na lista de cargos usando as setas.
            if (sender == txtFiltroCargo &&
                (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                AtualizarListaCargos(txtFiltroCargo.Text.Trim());

                if (lstFiltroCargos.Items.Count > 0)
                {
                    lstFiltroCargos.Visible = true;
                    lstFiltroCargos.BringToFront();

                    lstFiltroCargos.SelectedIndex =
                        e.KeyCode == Keys.Down
                            ? 0
                            : lstFiltroCargos.Items.Count - 1;

                    lstFiltroCargos.Focus();
                }

                return;
            }

            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            if (sender == txtFiltroID)
            {
                txtFiltroNome.Focus();
            }
            else if (sender == txtFiltroNome)
            {
                txtFiltroCargo.Focus();
            }
            else if (sender == txtFiltroCargo)
            {
                lstFiltroCargos.Visible = false;
                btnPesquisar.Focus();
            }
        }

        private void btnPesquisar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnPesquisar.PerformClick();
            }
        }

        private void txtFiltroID_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        // Lista de cargos para pesquisa no menu 
        private void AtualizarListaCargos(string pesquisa)
        {
            var cargos = cadastros
                .Select(cadastro => cadastro.Cargo)
                .Where(cargo => !string.IsNullOrWhiteSpace(cargo))
                .Distinct(StringComparer.CurrentCultureIgnoreCase)
                .Where(cargo => cargo.Contains(
                    pesquisa,
                    StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(cargo => cargo)
                .ToArray();

            lstFiltroCargos.BeginUpdate();

            try
            {
                lstFiltroCargos.Items.Clear();
                lstFiltroCargos.Items.AddRange(cargos);
                lstFiltroCargos.ClearSelected();
            }
            finally
            {
                lstFiltroCargos.EndUpdate();
            }

            lstFiltroCargos.Visible =
                txtFiltroCargo.Focused && cargos.Length > 0;

            if (lstFiltroCargos.Visible)
                lstFiltroCargos.BringToFront();
        }

        private void txtFiltroCargo_Enter(object? sender, EventArgs e)
        {
            // Mostra todas as opções ao entrar no campo.
            AtualizarListaCargos("");
        }

        private void txtFiltroCargo_TextChanged(object? sender, EventArgs e)
        {
            AtualizarListaCargos(txtFiltroCargo.Text.Trim());
        }

        private void ConfirmarCargoFiltro()
        {
            if (lstFiltroCargos.SelectedItem is not string cargo)
                return;

            txtFiltroCargo.Text = cargo;
            lstFiltroCargos.Visible = false;

            btnPesquisar.Focus();
        }

        private void lstFiltroCargos_Click(object? sender, EventArgs e)
        {
            ConfirmarCargoFiltro();
        }

        private void lstFiltroCargos_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                ConfirmarCargoFiltro();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                txtFiltroCargo.Focus();
                lstFiltroCargos.Visible = false;
            }
        }

        private void ConfigurarCliquesForaDaLista(Control controle)
        {
            controle.MouseDown -= OcultarListaAoClicarFora;
            controle.MouseDown += OcultarListaAoClicarFora;

            foreach (Control filho in controle.Controls)
            {
                ConfigurarCliquesForaDaLista(filho);
            }
        }

        private void OcultarListaAoClicarFora(
            object? sender,
            MouseEventArgs e)
        {
            if (sender is not Control controle)
                return;

            if (controle == txtFiltroCargo ||
                txtFiltroCargo.Contains(controle) ||
                controle == lstFiltroCargos ||
                lstFiltroCargos.Contains(controle))
            {
                return;
            }

            lstFiltroCargos.Visible = false;
        }

        // Também oculta quando sair pelo teclado.
        private void OcultarListaCargosAoSair(object? sender, EventArgs e)
        {
            if (IsDisposed || Disposing || !IsHandleCreated)
                return;

            BeginInvoke(new Action(() =>
            {
                if (IsDisposed || Disposing)
                    return;

                if (!txtFiltroCargo.ContainsFocus &&
                    !lstFiltroCargos.ContainsFocus)
                {
                    lstFiltroCargos.Visible = false;
                }
            }));
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            using (FrmRelatorios formulario = new FrmRelatorios())
            {
                formulario.ShowDialog(this);
            }
        }

        private void txtFiltroNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'º' || e.KeyChar == '°' || e.KeyChar == 'ª')
            {
                e.Handled = true;
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != '.' &&
                e.KeyChar != '-' &&
                e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }
    }
}
