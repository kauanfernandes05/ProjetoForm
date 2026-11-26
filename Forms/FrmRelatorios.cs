using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoForm.Repositories;
using System.Globalization;
using System.Text.RegularExpressions;
using ProjetoForm.Models;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;
using ProjetoForm.Relatorios;
using ProjetoForm.Validacoes;


namespace ProjetoForm
{
    public partial class FrmRelatorios : Form, IRelatoriosView
    {
        private readonly FiltroRelatorioValidator filtroValidator = new FiltroRelatorioValidator();
        private readonly RelatoriosPresenter presenter;
        private readonly List<string> cargosRelatorio = new List<string>();
        private bool selecionandoCargoRelatorio;
        private int parteDataFiltro = 0;
        private bool formatandoSalario;
        public FrmRelatorios()
        {
            InitializeComponent();
            presenter = new RelatoriosPresenter(this,new RelatorioService());

            ConfigurarFiltros();
            ConfigurarNavegacao();
            ConfigurarPesquisaCargos();

            Shown -= FrmRelatorios_Shown;
            Shown += FrmRelatorios_Shown;

            txtIdInicial.KeyPress -= CamposId_KeyPress;
            txtIdInicial.KeyPress += CamposId_KeyPress;

            txtIdFinal.KeyPress -= CamposId_KeyPress;
            txtIdFinal.KeyPress += CamposId_KeyPress;

            txtNome.KeyPress -= txtNome_KeyPress;
            txtNome.KeyPress += txtNome_KeyPress;

            txtSalarioMin.KeyPress -= CamposSalario_KeyPress;
            txtSalarioMin.KeyPress += CamposSalario_KeyPress;

            txtSalarioMax.KeyPress -= CamposSalario_KeyPress;
            txtSalarioMax.KeyPress += CamposSalario_KeyPress;

            txtSalarioMin.TextChanged -= CamposSalario_TextChanged;
            txtSalarioMin.TextChanged += CamposSalario_TextChanged;

            txtSalarioMax.TextChanged -= CamposSalario_TextChanged;
            txtSalarioMax.TextChanged += CamposSalario_TextChanged;
        }

        private void CamposId_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }
        private void txtNome_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'º' || e.KeyChar == '°' || e.KeyChar == 'ª')
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
        private void CamposSalario_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // A máscara coloca os pontos e a vírgula automaticamente.
            if (!char.IsControl(e.KeyChar) &&
                (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }
        private void CamposSalario_TextChanged(
            object? sender,
            EventArgs e)
        {
            if (formatandoSalario || sender is not TextBox campo)
                return;

            string texto = campo.Text;

            if (texto.Length == 0)
                return;

            // Texto inválido colado será rejeitado pela validação ao gerar.
            if (!Regex.IsMatch(texto, @"^[0-9.,]+$"))
                return;

            int numerosADireita = 0;

            for (int i = campo.SelectionStart; i < texto.Length; i++)
            {
                if (texto[i] >= '0' && texto[i] <= '9')
                    numerosADireita++;
            }

            string numeros = Regex.Replace(texto, "[^0-9]", "")
                .TrimStart('0');

            if (numeros.Length == 0)
                numeros = "0";

            // Até nove dígitos, incluindo os centavos.
            if (numeros.Length > 9)
                return;

            decimal valor =
                decimal.Parse(numeros, CultureInfo.InvariantCulture) / 100m;

            string formatado = valor.ToString(
                "N2",
                CultureInfo.GetCultureInfo("pt-BR")
            );

            formatandoSalario = true;

            try
            {
                campo.Text = formatado;

                int posicao = formatado.Length;
                int encontrados = 0;

                while (posicao > 0 && encontrados < numerosADireita)
                {
                    posicao--;

                    if (formatado[posicao] >= '0' &&
                        formatado[posicao] <= '9')
                    {
                        encontrados++;
                    }
                }

                campo.SelectionStart = posicao;
                campo.SelectionLength = 0;
            }
            finally
            {
                formatandoSalario = false;
            }
        }
        private void DataFiltro_Enter(object? sender, EventArgs e)
        {
            parteDataFiltro = 0;
        }
        private void CamposFiltro_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is DateTimePicker data)
            {
                // Ativa o filtro e move da caixinha para o dia.
                if (e.KeyCode == Keys.Space && !data.Checked)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    data.Checked = true;
                    parteDataFiltro = 0;

                    BeginInvoke(new Action(() =>
                    {
                        if (data.Focused)
                        {
                            SendKeys.SendWait("{RIGHT}");
                        }
                    }));

                    return;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    // Se estiver desmarcada, apenas passa ao próximo campo.
                    if (data.Checked && parteDataFiltro < 2)
                    {
                        parteDataFiltro++;

                        SendKeys.SendWait("{RIGHT}");
                        return;
                    }

                    if (data.Checked)
                    {
                        // Retorna ao dia para a próxima entrada no campo.
                        SendKeys.SendWait("{RIGHT}");
                    }

                    parteDataFiltro = 0;

                    if (data == dtpNascimentoInicial)
                    {
                        dtpNascimentoFinal.Focus();
                    }
                    else
                    {
                        txtSalarioMin.Focus();
                    }

                    return;
                }
            }

            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            if (sender == cmbSaude)
            {
                cmbSaude.DroppedDown = false;

                RadioButton selecionado = grpOrdenacao.Controls
                    .OfType<RadioButton>()
                    .FirstOrDefault(radio => radio.Checked)
                    ?? rdbOrdenarID;
                selecionado.Focus();
                return;
            }

            Control[] sequencia =
            {
                txtIdInicial,
                txtIdFinal,
                txtNome,
                dtpNascimentoInicial,
                dtpNascimentoFinal,
                txtSalarioMin,
                txtSalarioMax,
                txtPesquisaCargo,
                cmbSexo,
                cmbTransporte,
                cmbAlimentacao,
                cmbSaude,
                btnGerarRelatorio
            };

            for (int i = 0; i < sequencia.Length - 1; i++)
            {
                if (sender == sequencia[i])
                {
                    if (sender is ComboBox combo)
                        combo.DroppedDown = false;

                    sequencia[i + 1].Focus();
                    return;
                }
            }
        }
        private void Ordenacao_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            btnGerarRelatorio.Focus();
        }
        private void btnGerarRelatorio_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                btnGerarRelatorio.PerformClick();
            }
        }
        private void ConfigurarNavegacao()
        {
            Control[] campos =
            {
                txtIdInicial,
                txtIdFinal,
                txtNome,
                dtpNascimentoInicial,
                dtpNascimentoFinal,
                txtSalarioMin,
                txtSalarioMax,
                cmbSexo,
                cmbTransporte,
                cmbAlimentacao,
                cmbSaude
            };

            foreach (Control campo in campos)
            {
                campo.KeyDown -= CamposFiltro_KeyDown;
                campo.KeyDown += CamposFiltro_KeyDown;
            }

            Control[] ordemTab =
            {
                txtIdInicial, txtIdFinal, txtNome,
                dtpNascimentoInicial, dtpNascimentoFinal,
                txtSalarioMin, txtSalarioMax, txtPesquisaCargo,
                cmbSexo, cmbTransporte, cmbAlimentacao, cmbSaude,
                btnGerarRelatorio, btnLimparFiltros, btnFechar
            };

            for (int i = 0; i < ordemTab.Length; i++)
                ordemTab[i].TabIndex = i;

            lstSugestoesCargos.TabStop = false;
            lstCargosSelecionados.TabStop = false;

            btnGerarRelatorio.KeyDown -= btnGerarRelatorio_KeyDown;
            btnGerarRelatorio.KeyDown += btnGerarRelatorio_KeyDown;

            ComboBox[] combos =
            {
                cmbSexo,
                cmbTransporte,
                cmbAlimentacao,
                cmbSaude
            };

            foreach (ComboBox combo in combos)
            {
                combo.Enter -= ComboFiltro_Enter;
                combo.Enter += ComboFiltro_Enter;

                combo.Leave -= ComboFiltro_Leave;
                combo.Leave += ComboFiltro_Leave;
            }

            grpFiltros.Paint -= DesenharFocoCombos;
            grpFiltros.Paint += DesenharFocoCombos;

            dtpNascimentoInicial.Enter -= DataFiltro_Enter;
            dtpNascimentoInicial.Enter += DataFiltro_Enter;

            dtpNascimentoFinal.Enter -= DataFiltro_Enter;
            dtpNascimentoFinal.Enter += DataFiltro_Enter;

            RadioButton[] opcoesOrdenacao =
            {
                rdbOrdenarID,
                rdbOrdenarNome,
                rdbOrdenarNascimento,
                rdbOrdenarSalario
            };

            foreach (RadioButton radio in opcoesOrdenacao)
            {
                radio.KeyDown -= Ordenacao_KeyDown;
                radio.KeyDown += Ordenacao_KeyDown;
            }
        }
        private void ConfigurarFiltros()
        {
            txtPesquisaCargo.ReadOnly = false;
            txtPesquisaCargo.MaxLength = 100;
            lstSugestoesCargos.Items.Clear();
            lstCargosSelecionados.Items.Clear();
            txtSalarioMin.MaxLength = 12;
            txtSalarioMax.MaxLength = 12;

            // Sexo.
            cmbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSexo.Items.Clear();
            cmbSexo.Items.AddRange(new string[]
            {
                "Todos",
                "Masculino",
                "Feminino"
            });

            cmbSexo.SelectedIndex = 0;

            // Benefícios.
            ComboBox[] beneficios =
            {
                cmbTransporte,
                cmbAlimentacao,
                cmbSaude
            };

            foreach (ComboBox campo in beneficios)
            {
                campo.DropDownStyle = ComboBoxStyle.DropDownList;
                campo.Items.Clear();

                campo.Items.AddRange(new string[]
                {
                "Todos",
                "Possui",
                "Não possui"
                });

                campo.SelectedIndex = 0;
            }

            // Datas opcionais.
            dtpNascimentoInicial.Format = DateTimePickerFormat.Custom;
            dtpNascimentoInicial.CustomFormat = "dd/MM/yyyy";
            dtpNascimentoInicial.ShowCheckBox = true;
            dtpNascimentoInicial.Checked = false;

            dtpNascimentoFinal.Format = DateTimePickerFormat.Custom;
            dtpNascimentoFinal.CustomFormat = "dd/MM/yyyy";
            dtpNascimentoFinal.ShowCheckBox = true;
            dtpNascimentoFinal.Checked = false;

            txtIdInicial.MaxLength = 7;
            txtIdFinal.MaxLength = 7;

            txtNome.MaxLength = 150;

            txtSalarioMin.TextAlign = HorizontalAlignment.Right;
            txtSalarioMax.TextAlign = HorizontalAlignment.Right;
        }
        private void ComboFiltro_Enter(object? sender, EventArgs e)
        {
            if (sender is Control controle)
                controle.Parent?.Invalidate();
        }
        private void ComboFiltro_Leave(object? sender, EventArgs e)
        {
            if (sender is Control controle)
                controle.Parent?.Invalidate();
        }
        private void DesenharFocoCombos(object? sender, PaintEventArgs e)
        {
            if (sender is not Control container)
                return;

            foreach (Control controle in container.Controls)
            {
                if (controle is ComboBox combo && combo.Focused)
                {
                    Rectangle borda = combo.Bounds;
                    borda.Inflate(3, 3);

                    ControlPaint.DrawFocusRectangle(
                        e.Graphics,
                        borda,
                        container.ForeColor,
                        container.BackColor
                    );
                }
            }
        }
        private async void FrmRelatorios_Shown(object? sender, EventArgs e)
        {
            btnGerarRelatorio.Enabled = false;
            txtPesquisaCargo.Enabled = false;
            UseWaitCursor = true;

            try
            {
                CadastroRepository repositorio = new CadastroRepository();

                var cadastros = await repositorio.ListarAsync();

                var cargos = cadastros
                    .Select(cadastro => cadastro.Cargo.Trim())
                    .Where(cargo => !string.IsNullOrWhiteSpace(cargo))
                    .Distinct(StringComparer.CurrentCultureIgnoreCase)
                    .OrderBy(cargo => cargo)
                    .ToArray();

                cargosRelatorio.Clear();
                cargosRelatorio.AddRange(cargos);

            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(
                    this,
                    "Não foi possível carregar os cargos.\n\n" + ex.Message,
                    "Erro ao consultar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                txtPesquisaCargo.Enabled = true;
                btnGerarRelatorio.Enabled = true;
                UseWaitCursor = false;
            }
        }
        private void LimparFiltros()
        {
            txtIdInicial.Clear();
            txtIdFinal.Clear();
            txtNome.Clear();
            txtSalarioMin.Clear();
            txtSalarioMax.Clear();

            txtPesquisaCargo.Clear();
            lstSugestoesCargos.Items.Clear();
            lstSugestoesCargos.Visible = false;
            lstCargosSelecionados.Items.Clear();
            AtualizarVisibilidadeCargos();
            lstCargosSelecionados.Visible = false;
            parteDataFiltro = 0;
            cmbSexo.SelectedIndex = 0;
            cmbTransporte.SelectedIndex = 0;
            cmbAlimentacao.SelectedIndex = 0;
            cmbSaude.SelectedIndex = 0;

            dtpNascimentoInicial.Checked = false;
            dtpNascimentoFinal.Checked = false;
            rdbOrdenarID.Checked = true;
            txtIdInicial.Focus();
        }
        private void btnLimparFiltros_Click(object? sender, EventArgs e)
        {
            LimparFiltros();
        }

        private void btnFechar_Click(object? sender, EventArgs e)
        {
            Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.Cancel)
                return;

            DialogResult resposta = MessageBox.Show(
                this,
                "Deseja realmente fechar a tela de relatórios?",
                "Confirmar saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (resposta != DialogResult.Yes)
                e.Cancel = true;
        }
        private bool LerIdOpcional(TextBox campo, out int? valor)
        {
            valor = null;
            string texto = campo.Text.Trim();

            if (texto.Length == 0)
                return true;

            if (!Regex.IsMatch(texto, @"^[0-9]{1,7}$") ||
                !int.TryParse(texto, out int numero) ||
                numero <= 0)
            {
                MessageBox.Show("Informe um ID de 1 a 9.999.999.");
                campo.Focus();
                return false;
            }

            valor = numero;
            return true;
        }
        private bool LerSalarioOpcional(TextBox campo, out decimal? valor)
        {
            valor = null;
            string texto = campo.Text.Trim();

            if (texto.Length == 0)
                return true;

            var cultura = CultureInfo.GetCultureInfo("pt-BR");

            bool formatoValido = Regex.IsMatch(
                texto,
                @"^(?:[0-9]{1,7}|[0-9]{1,3}(?:\.[0-9]{3}){1,2})(?:,[0-9]{1,2})?$"
            );

            if (!formatoValido ||
                !decimal.TryParse(
                    texto,
                    NumberStyles.Number,
                    cultura,
                    out decimal salario) ||
                salario < 0 ||
                salario > 9999999.99m)
            {
                MessageBox.Show(
                    "Informe um valor entre 0,00 e 9.999.999,99. " +
                    "Use vírgula para os centavos."
                );

                campo.Focus();
                return false;
            }

            valor = salario;
            return true;
        }
        public bool TentarObterFiltros(out FiltroRelatorio filtro)
        {
            filtro = new FiltroRelatorio();

            if (!string.IsNullOrWhiteSpace(txtPesquisaCargo.Text))
            {
                MessageBox.Show(this,
                    "Confirme o cargo com Enter ou clique na lista. " +
                    "Para ignorar a pesquisa digitada, apague o texto.",
                    "Seleção de cargos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPesquisaCargo.Focus();
                return false;
            }

            string nome = txtNome.Text.Trim();

            if (!filtroValidator.ValidarNome(nome))
            {
                MessageBox.Show(
                    "A pesquisa por nome permite até 150 caracteres: " +
                    "letras, números, espaços, pontos, traços e barras."
                );

                txtNome.Focus();
                return false;
            }

            if (!LerIdOpcional(txtIdInicial, out int? idInicial))
                return false;

            if (!LerIdOpcional(txtIdFinal, out int? idFinal))
                return false;

            if (!filtroValidator.ValidarIntervaloIds(idInicial, idFinal))
            {
                MessageBox.Show("O ID inicial não pode ser maior que o ID final." );

                txtIdInicial.Focus();
                return false;
            }

            if (!LerSalarioOpcional(txtSalarioMin,out decimal? salarioMinimo))
            {
                return false;
            }

            if (!LerSalarioOpcional(txtSalarioMax,out decimal? salarioMaximo))
            {
                return false;
            }

            if (!filtroValidator.ValidarIntervaloSalarios(salarioMinimo, salarioMaximo))
            {
                MessageBox.Show(
                    "O salário mínimo não pode ser maior que o máximo."
                );

                txtSalarioMin.Focus();
                return false;
            }

            DateTime? nascimentoInicial = dtpNascimentoInicial.Checked? dtpNascimentoInicial.Value.Date: null;

            DateTime? nascimentoFinal = dtpNascimentoFinal.Checked ? dtpNascimentoFinal.Value.Date: null;

            if (!filtroValidator.ValidarIntervaloData(nascimentoInicial, nascimentoFinal))
            {
                MessageBox.Show( "A data inicial não pode ser posterior à data final.");

                dtpNascimentoInicial.Focus();
                return false;
            }

            // As opções devem ter sido inicializadas pelo ConfigurarFiltros().
            ComboBox[] opcoes =
            {
                cmbSexo,
                cmbTransporte,
                cmbAlimentacao,
                cmbSaude
            };

            foreach (ComboBox campo in opcoes)
            {
                if (campo.SelectedIndex < 0)
                {
                    MessageBox.Show(
                        "Selecione uma opção ou escolha Todos."
                    );

                    campo.Focus();
                    return false;
                }
            }

            filtro.IdInicial = idInicial;
            filtro.IdFinal = idFinal;
            filtro.Nome = nome;

            filtro.NascimentoInicial = nascimentoInicial;
            filtro.NascimentoFinal = nascimentoFinal;

            filtro.SalarioMinimo = salarioMinimo;
            filtro.SalarioMaximo = salarioMaximo;

            // Índice 0 corresponde à opção Todos.
            filtro.Cargo = null;

            filtro.Sexo = cmbSexo.SelectedIndex == 0
                ? null
                : cmbSexo.SelectedItem?.ToString();

            filtro.ValeTransporte = cmbTransporte.SelectedIndex switch
            {
                1 => true,
                2 => false,
                _ => null
            };

            filtro.ValeAlimentacao = cmbAlimentacao.SelectedIndex switch
            {
                1 => true,
                2 => false,
                _ => null
            };

            filtro.PlanoSaude = cmbSaude.SelectedIndex switch
            {
                1 => true,
                2 => false,
                _ => null
            };

            return true;
        }

        private async void btnGerarRelatorio_Click(object? sender,EventArgs e)
        {
            if (!btnGerarRelatorio.Enabled)return;

            await presenter.GerarRelatorioAsync();
        }

        private void ConfigurarPesquisaCargos()
        {
            lstSugestoesCargos.Visible = false;
            lstSugestoesCargos.HorizontalScrollbar = true;

            lstCargosSelecionados.HorizontalScrollbar = true;

            txtPesquisaCargo.TextChanged -= PesquisaCargo_TextChanged;
            txtPesquisaCargo.TextChanged += PesquisaCargo_TextChanged;

            txtPesquisaCargo.KeyDown -= PesquisaCargo_KeyDown;
            txtPesquisaCargo.KeyDown += PesquisaCargo_KeyDown;

            lstSugestoesCargos.KeyDown -= SugestoesCargos_KeyDown;
            lstSugestoesCargos.KeyDown += SugestoesCargos_KeyDown;

            lstSugestoesCargos.MouseClick -= SugestoesCargos_MouseClick;
            lstSugestoesCargos.MouseClick += SugestoesCargos_MouseClick;

            txtPesquisaCargo.Leave -= CampoCargo_Leave;
            txtPesquisaCargo.Leave += CampoCargo_Leave;

            lstSugestoesCargos.Leave -= CampoCargo_Leave;
            lstSugestoesCargos.Leave += CampoCargo_Leave;

            AtualizarVisibilidadeCargos();
        }
        private void PesquisaCargo_TextChanged(object? sender, EventArgs e)
        {
            if (selecionandoCargoRelatorio)
                return;

            PesquisarCargosRelatorio();
        }
        private void PesquisarCargosRelatorio()
        {
            string pesquisa = txtPesquisaCargo.Text.Trim();

            lstSugestoesCargos.Items.Clear();

            if (pesquisa.Length == 0)
            {
                lstSugestoesCargos.Visible = false;
                return;
            }

            string[] selecionados = lstCargosSelecionados.Items.Cast<string>().ToArray();

            string[] resultados = cargosRelatorio.Where(cargo =>
                    cargo.Contains(
                        pesquisa,
                        StringComparison.CurrentCultureIgnoreCase
                    ) &&
                    !selecionados.Contains(
                        cargo,
                        StringComparer.CurrentCultureIgnoreCase
                    ))
                .ToArray();

            lstSugestoesCargos.Items.AddRange(resultados);
            lstSugestoesCargos.Visible = resultados.Length > 0;

            if (resultados.Length > 0)
            {
                lstSugestoesCargos.SelectedIndex = 0;
                lstSugestoesCargos.BringToFront();
            }
        }
        private void PesquisaCargo_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Down)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Enter)
            {
                if (lstSugestoesCargos.Visible &&
                    lstSugestoesCargos.SelectedItem != null)
                {
                    AdicionarCargoSelecionado();
                }
                else if (string.IsNullOrWhiteSpace(txtPesquisaCargo.Text))
                {
                    cmbSexo.Focus();
                }
                else
                {
                    MessageBox.Show(
                        this,
                        "Selecione um cargo válido da lista.",
                        "Cargo não encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                return;
            }

            if (lstSugestoesCargos.Visible &&
                lstSugestoesCargos.Items.Count > 0)
            {
                lstSugestoesCargos.Focus();
            }
        }

        private void SugestoesCargos_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                AdicionarCargoSelecionado();
            }
        }

        private void SugestoesCargos_MouseClick(object? sender, MouseEventArgs e)
        {
            int indice = lstSugestoesCargos.IndexFromPoint(e.Location);

            if (indice == ListBox.NoMatches)
                return;

            lstSugestoesCargos.SelectedIndex = indice;
            AdicionarCargoSelecionado();
        }

        private void AdicionarCargoSelecionado()
        {
            if (lstSugestoesCargos.SelectedItem is not string cargo)
                return;

            bool jaSelecionado = lstCargosSelecionados.Items
                .Cast<string>()
                .Contains(
                    cargo,
                    StringComparer.CurrentCultureIgnoreCase
                );

            if (!jaSelecionado)
                lstCargosSelecionados.Items.Add(cargo);

            lstCargosSelecionados.Visible =
                lstCargosSelecionados.Items.Count > 0;

            AtualizarVisibilidadeCargos();

            try
            {
                txtPesquisaCargo.Clear();
                lstSugestoesCargos.Items.Clear();
                lstSugestoesCargos.Visible = false;
            }
            finally
            {
                selecionandoCargoRelatorio = false;
            }

            txtPesquisaCargo.Focus();
        }

        private void CampoCargo_Leave(object? sender, EventArgs e)
        {
            if (IsDisposed || Disposing || !IsHandleCreated)
                return;

            BeginInvoke(new Action(() =>
            {
                if (IsDisposed || Disposing)
                    return;

                if (!txtPesquisaCargo.ContainsFocus &&
                    !lstSugestoesCargos.ContainsFocus)
                {
                    lstSugestoesCargos.Visible = false;
                }
            }));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    btnFechar.PerformClick();
                    return true;
                   
                case Keys.F2:
                    btnGerarRelatorio.PerformClick();
                    return true;
                    
                case Keys.F4:
                    btnLimparFiltros.PerformClick();
                    return true;
                    

                case Keys.Delete:
                    btnRemoveCargo.PerformClick();
                    return true;
                   
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRemoveCargo_Click(object sender, EventArgs e)
        {
            int indice = lstCargosSelecionados.SelectedIndex;

            if (indice < 0)
            {
                MessageBox.Show(
                    this,
                    "Selecione um cargo da lista para remover.",
                    "Remover cargo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                lstCargosSelecionados.Focus();
                return;
            }

            lstCargosSelecionados.Items.RemoveAt(indice);

            AtualizarVisibilidadeCargos();

            if (lstCargosSelecionados.Items.Count > 0)
            {
                lstCargosSelecionados.SelectedIndex = Math.Min(indice,lstCargosSelecionados.Items.Count - 1);
            }
            else
            {
                txtPesquisaCargo.Focus();
            }
        }

        private void AtualizarVisibilidadeCargos()
        {
            bool temCargos = lstCargosSelecionados.Items.Count > 0;

            lstCargosSelecionados.Visible = temCargos;
            lstCargosSelecionados.TabStop = temCargos;

            btnRemoveCargo.Visible = temCargos;
            tspDel.Visible = temCargos;
        }

        public OrdenacaoRelatorio ObterOrdenacaoSelecionada()
        {
            if (rdbOrdenarNome.Checked) return OrdenacaoRelatorio.Nome;

            if (rdbOrdenarNascimento.Checked) return OrdenacaoRelatorio.Nascimento;

            if (rdbOrdenarSalario.Checked) return OrdenacaoRelatorio.Salario;

            return OrdenacaoRelatorio.Id;
        }

        public List<string> ObterCargosSelecionados()
        {
            return lstCargosSelecionados.Items.Cast<string>().Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
        }

        public void DefinirCarregamento(bool carregando)
        {
            if (IsDisposed || Disposing) return;

            btnGerarRelatorio.Enabled = !carregando;
            btnLimparFiltros.Enabled = !carregando;
            grpFiltros.Enabled = !carregando;
            UseWaitCursor = carregando;
        }

        public void MostrarAviso(String mensagem)
        {
            if(IsDisposed || Disposing) return;

            MessageBox.Show(this, mensagem, "Relatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MostrarErro(string mensagem)
        {
            if(IsDisposed || Disposing) {return;}

            MessageBox.Show(this, mensagem, "Erro ao consultar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ExibirPrevia(List<Cadastro> registros,FiltroRelatorio filtro,List<string> cargosSelecionados)
        {
            if (IsDisposed || Disposing) return;

            UseWaitCursor = false;

            var relatorio = new RelatorioCadastros();

            relatorio.AbrirPreviaRelatorio(this,registros,filtro,cargosSelecionados);
        }
    }
}
