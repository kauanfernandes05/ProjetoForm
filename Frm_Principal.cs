using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoForm
{
    public partial class FormPrincipal : Form
    {

        protected override bool ProcessCmdKey(
        ref Message msg,
        Keys keyData)
        {
            if ((keyData & Keys.KeyCode) == Keys.Tab)
            {
                return true; // Bloqueia a tecla Tab
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private int parteData = 0;
        private int proximoId = 1;
        private bool formatandoSalario = false;

        private readonly CultureInfo cultura =
            CultureInfo.GetCultureInfo("pt-BR");

        public FormPrincipal()
        {
            InitializeComponent();

            ConfigurarTabela();
            ConfigurarCampos();
            ConectarEventos();
        }

        private void ConfigurarTabela()
        {
            if (!Dgv_Cadastros.Columns.Contains("Cln_Id"))
            {
                Dgv_Cadastros.Columns.Insert(
                    0,
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Cln_Id",
                        HeaderText = "ID",
                        ValueType = typeof(int)
                    }
                );
            }

            Dgv_Cadastros.Columns["Cln_Id"].DisplayIndex = 0;

            Dgv_Cadastros.AllowUserToAddRows = false;
            Dgv_Cadastros.ReadOnly = true;
            Dgv_Cadastros.MultiSelect = false;

            Dgv_Cadastros.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            Dgv_Cadastros.AllowUserToResizeColumns = true;
            Dgv_Cadastros.AllowUserToResizeRows = true;

            Dgv_Cadastros.ScrollBars = ScrollBars.Both;

            
            Dgv_Cadastros.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            Dgv_Cadastros.CellBorderStyle =
                DataGridViewCellBorderStyle.None;

            Dgv_Cadastros.RowHeadersVisible = false;

            // Mantém os títulos visíveis.
            Dgv_Cadastros.ColumnHeadersVisible = true;

            Dgv_Cadastros.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            Dgv_Cadastros.EnableHeadersVisualStyles = false;

            Dgv_Cadastros.ColumnHeadersDefaultCellStyle.BackColor =
                Color.LightGray;

            Dgv_Cadastros.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.Black;

            Dgv_Cadastros.Columns["Cln_Id"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            Dgv_Cadastros.Columns["Cln_Nome"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            Dgv_Cadastros.Columns["cln_dataNsc"]
                .DefaultCellStyle.Format = "dd/MM/yyyy";

            Dgv_Cadastros.Columns["cln_dataNsc"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            Dgv_Cadastros.Columns["Cln_Salario"]
                .DefaultCellStyle.Format = "C2";

            Dgv_Cadastros.Columns["Cln_Salario"]
                .DefaultCellStyle.FormatProvider = cultura;

            Dgv_Cadastros.Columns["Cln_Salario"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            Dgv_Cadastros.Columns["cln_Sexo"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            Dgv_Cadastros.Columns["cln_cargo"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
        }

        private void ConfigurarCampos()
        {
            Dtp_dataNsc.Format = DateTimePickerFormat.Custom;
            Dtp_dataNsc.CustomFormat = "dd/MM/yyyy";

            Txt_Pesquisa.ReadOnly = true;

            Txt_Salario.MaxLength = 12;
            Txt_Salario.TextAlign = HorizontalAlignment.Right;

            List_Cargos.Items.Clear();

            List_Cargos.Items.AddRange(new string[]
            {
                "Desenvolvedor",
                "Analista de Sistemas",
                "Gerente de Projetos",
                "Designer",
                "Testador"
            });

            List_Cargos.Visible = false;
        }

        private void ConectarEventos()
        {
            Control[] campos =
            {
                Txt_Nome,
                Dtp_dataNsc,
                Txt_Salario,
                Txt_Pesquisa,
                rdb_Masc,
                rdb_Fem
            };

            foreach (Control campo in campos)
            {
                campo.KeyDown -= Campos_KeyDown;
                campo.KeyDown += Campos_KeyDown;
            }

            Txt_Salario.TextChanged -= Txt_Salario_TextChanged;
            Txt_Salario.TextChanged += Txt_Salario_TextChanged;

           
            Txt_Salario.Leave -= Txt_Salario_Leave;
            Txt_Salario.Leave += Txt_Salario_Leave;

            Dtp_dataNsc.Enter -= Dtp_dataNsc_Enter;
            Dtp_dataNsc.Enter += Dtp_dataNsc_Enter;

            Txt_Pesquisa.Enter -= Txt_Pesquisa_Enter;
            Txt_Pesquisa.Enter += Txt_Pesquisa_Enter;

            List_Cargos.Click -= List_Cargos_Click;
            List_Cargos.Click += List_Cargos_Click;

            List_Cargos.KeyDown -= List_Cargos_KeyDown;
            List_Cargos.KeyDown += List_Cargos_KeyDown;

            Btn_Adicionar.Click -= Btn_Adicionar_Click;
            Btn_Adicionar.Click += Btn_Adicionar_Click;

            Btn_Remover.Click -= Btn_Remover_Click;
            Btn_Remover.Click += Btn_Remover_Click;

            Txt_Salario.TextChanged -= Txt_Salario_TextChanged;
            Txt_Salario.TextChanged += Txt_Salario_TextChanged;

            chk_Transporte.KeyDown -= Campos_KeyDown;
            chk_Transporte.KeyDown += Campos_KeyDown;

            chk_Alimentacao.KeyDown -= Campos_KeyDown;
            chk_Alimentacao.KeyDown += Campos_KeyDown;

            chk_Saude.KeyDown -= Campos_KeyDown;
            chk_Saude.KeyDown += Campos_KeyDown;
        }

        private void Txt_Nome_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void Txt_Idade_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        private void Txt_Salario_TextChanged(object sender, EventArgs e)
        {
            if (formatandoSalario)
                return;

            string texto = Txt_Salario.Text;

            if (string.IsNullOrEmpty(texto))
                return;

            // Conta os números à direita do cursor para manter
            // sua posição após a formatação.
            int numerosADireita = 0;

            for (int i = Txt_Salario.SelectionStart; i < texto.Length; i++)
            {
                if (texto[i] >= '0' && texto[i] <= '9')
                    numerosADireita++;
            }

            string numeros = Regex.Replace(texto, "[^0-9]", "");
            numeros = numeros.TrimStart('0');

            if (numeros.Length == 0)
                numeros = "0";

            formatandoSalario = true;

            try
            {
                // Até 9.999.999,99: nove dígitos incluindo centavos.
                if (numeros.Length > 9)
                {
                    MessageBox.Show("O salário máximo é 9.999.999,99.");

                    Txt_Salario.Clear();
                    return;
                }

                decimal valor =
                    decimal.Parse(numeros, CultureInfo.InvariantCulture) / 100m;

                string formatado = valor.ToString("N2", cultura);

                Txt_Salario.Text = formatado;

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

                Txt_Salario.SelectionStart = posicao;
                Txt_Salario.SelectionLength = 0;
            }
            finally
            {
                formatandoSalario = false;
            }
        }

        private bool TentarLerSalario(out decimal salario)
        {
            string texto = Txt_Salario.Text.Trim();

            // Aceita:
            // 1500
            // 1500,50
            // 1.500,50
            // 9.999.999,99
            bool formatoValido = Regex.IsMatch(
                texto,
                @"^(?:[0-9]{1,7}|[0-9]{1,3}(?:\.[0-9]{3}){1,2})(?:,[0-9]{1,2})?$"
            );

            salario = 0;

            return formatoValido &&
                decimal.TryParse(
                    texto,
                    NumberStyles.Number,
                    cultura,
                    out salario
                ) &&
                salario >= 0 &&
                salario <= 9999999.99m;
        }

        private void Txt_Salario_Leave(
            object sender,
            EventArgs e)
        {
            if (TentarLerSalario(out decimal salario))
            {
                Txt_Salario.Text =
                    salario.ToString("N2", cultura);
            }
        }

        private void Txt_Pesquisa_Enter(
            object sender,
            EventArgs e)
        {
            List_Cargos.Visible = true;
            List_Cargos.BringToFront();
        }

        private void List_Cargos_Click(
            object sender,
            EventArgs e)
        {
            ConfirmarCargo();
        }

        private void List_Cargos_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            ConfirmarCargo();
        }

        private void ConfirmarCargo()
        {
            if (List_Cargos.SelectedItem == null)
                return;

            Txt_Pesquisa.Text =
                List_Cargos.SelectedItem.ToString();

            List_Cargos.Visible = false;

            FocarSexo();
        }

        private void Dtp_dataNsc_Enter(
            object sender,
            EventArgs e)
        {
            parteData = 0;

            BeginInvoke(new Action(() =>
            {
                if (Dtp_dataNsc.Focused)
                    SendKeys.Send("{HOME}");
            }));
        }

        private void Campos_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            // Do campo cargo, entra na lista usando as setas.
            if (sender == Txt_Pesquisa &&
                (e.KeyCode == Keys.Down ||
                 e.KeyCode == Keys.Up))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                List_Cargos.Visible = true;
                List_Cargos.BringToFront();

                if (List_Cargos.Items.Count > 0)
                {
                    if (List_Cargos.SelectedIndex < 0)
                    {
                        List_Cargos.SelectedIndex =
                            e.KeyCode == Keys.Down
                            ? 0
                            : List_Cargos.Items.Count - 1;
                    }

                    List_Cargos.Focus();
                }

                return;
            }

            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            if (sender == Txt_Nome)
            {
                Dtp_dataNsc.Focus();
            }
            else if (sender == Dtp_dataNsc)
            {
                if (parteData < 2)
                {
                    parteData++;
                    SendKeys.Send("{RIGHT}");
                }
                else
                {
                    Txt_Salario.Focus();
                }
            }
            else if (sender == Txt_Salario)
            {
                Txt_Pesquisa.Focus();
            }
            else if (sender == Txt_Pesquisa)
            {
                if (List_Cargos.SelectedItem != null)
                {
                    ConfirmarCargo();
                }
                else
                {
                    List_Cargos.Visible = true;

                    if (List_Cargos.Items.Count > 0)
                    {
                        List_Cargos.SelectedIndex = 0;
                        List_Cargos.Focus();
                    }
                }
            }
            else if (sender == rdb_Masc ||
         sender == rdb_Fem)
            {
                chk_Transporte.Focus();
            }
            else if (sender == chk_Transporte)
            {
                chk_Alimentacao.Focus();
            }
            else if (sender == chk_Alimentacao)
            {
                chk_Saude.Focus();
            }
            else if (sender == chk_Saude)
            {
                Btn_Adicionar.Focus();
            }
        }

        private void FocarSexo()
        {
            if (rdb_Fem.Checked)
                rdb_Fem.Focus();
            else
                rdb_Masc.Focus();
        }

        private void Btn_Adicionar_Click(object sender, EventArgs e)
        {
            // Remove espaços extras do nome.
            string nome = System.Text.RegularExpressions.Regex.Replace(
                Txt_Nome.Text.Trim(),
                " +",
                " "
            );

            DateTime nascimento = Dtp_dataNsc.Value.Date;
            DateTime hoje = DateTime.Today;
            string cargo = Txt_Pesquisa.Text.Trim();

            // Validação do nome.
            bool nomeValido = nome.Length > 0;

            foreach (char caractere in nome)
            {
                if (!char.IsLetter(caractere) && caractere != ' ')
                {
                    nomeValido = false;
                    break;
                }
            }

            if (!nomeValido)
            {
                MessageBox.Show("Informe um nome usando apenas letras e espaços.");
                Txt_Nome.Focus();
                return;
            }

            // Validação da data de nascimento.
            if (nascimento > hoje)
            {
                MessageBox.Show("A data de nascimento não pode ser futura.");
                Dtp_dataNsc.Focus();
                return;
            }

            if (nascimento > hoje.AddYears(-18))
            {
                MessageBox.Show("É necessário ter pelo menos 18 anos para realizar o cadastro.");
                Dtp_dataNsc.Focus();
                return;
            }

            if (nascimento < hoje.AddYears(-120))
            {
                MessageBox.Show("Confira a data de nascimento. O limite permitido é de 120 anos.");
                Dtp_dataNsc.Focus();
                return;
            }

            // Validação do salário.
            if (!TentarLerSalario(out decimal salario))
            {
                MessageBox.Show("Informe um salário entre 0,00 e 9.999.999,99.");
                Txt_Salario.Focus();
                return;
            }

            // Validação do cargo.
            if (!List_Cargos.Items.Contains(cargo))
            {
                MessageBox.Show("Selecione um cargo da lista.");
                Txt_Pesquisa.Focus();
                return;
            }

            // Deve haver exatamente uma opção de sexo marcada.
            if (rdb_Masc.Checked == rdb_Fem.Checked)
            {
                MessageBox.Show("Selecione uma opção de sexo.");
                FocarSexo();
                return;
            }

            string sexo = rdb_Masc.Checked ? "Masculino" : "Feminino";

            // Benefícios opcionais.
            List<string> beneficios = new List<string>();

            if (chk_Transporte.Checked)
                beneficios.Add("Vale-transporte");

            if (chk_Alimentacao.Checked)
                beneficios.Add("Vale-alimentação");

            if (chk_Saude.Checked)
                beneficios.Add("Plano de saúde");

            string textoBeneficios = beneficios.Count > 0
                ? string.Join(", ", beneficios)
                : "Nenhum";

            // Prepara a linha antes de adicioná-la à tabela.
            DataGridViewRow novaLinha = new DataGridViewRow();
            novaLinha.CreateCells(Dgv_Cadastros);

            novaLinha.Cells[Dgv_Cadastros.Columns["Cln_Id"].Index].Value =
                proximoId;

            novaLinha.Cells[Dgv_Cadastros.Columns["Cln_Nome"].Index].Value =
                nome;

            novaLinha.Cells[Dgv_Cadastros.Columns["cln_dataNsc"].Index].Value =
                nascimento;

            novaLinha.Cells[Dgv_Cadastros.Columns["Cln_Salario"].Index].Value =
                salario;

            novaLinha.Cells[Dgv_Cadastros.Columns["cln_cargo"].Index].Value =
                cargo;

            novaLinha.Cells[Dgv_Cadastros.Columns["cln_Sexo"].Index].Value =
                sexo;

            novaLinha.Cells[Dgv_Cadastros.Columns["Cln_Beneficios"].Index].Value =
                textoBeneficios;

            Dgv_Cadastros.Rows.Add(novaLinha);

            // Só avança o ID depois de adicionar.
            proximoId++;

            // Limpa o formulário e volta ao campo nome.
            LimparCampos();
        }

        private void Beneficio_Enter(object sender, EventArgs e)
        {
            CheckBox beneficio = (CheckBox)sender;

            beneficio.BackColor = Color.LightBlue;
            beneficio.ForeColor = Color.Black;
        }

        private void Beneficio_Leave(object sender, EventArgs e)
        {
            CheckBox beneficio = (CheckBox)sender;

            beneficio.BackColor = Color.Transparent;
            beneficio.ForeColor = SystemColors.ControlText;
        }

        private void LimparCampos()
        {
            Txt_Nome.Clear();
            Txt_Salario.Clear();

            List_Cargos.ClearSelected();
            Txt_Pesquisa.Clear();
            List_Cargos.Visible = false;

            Dtp_dataNsc.Value = DateTime.Today;
            parteData = 0;

            rdb_Masc.Checked = false;
            rdb_Fem.Checked = false;

            chk_Transporte.Checked = false;
            chk_Alimentacao.Checked = false;
            chk_Saude.Checked = false;

            Dgv_Cadastros.ClearSelection();


            Txt_Nome.Focus();
        }

        private void Btn_Remover_Click(
            object sender,
            EventArgs e)
        {
            if (Dgv_Cadastros.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecione o cadastro que deseja remover."
                );

                return;
            }

            Dgv_Cadastros.Rows.Remove(
                Dgv_Cadastros.SelectedRows[0]
            );

            Dgv_Cadastros.ClearSelection();
        }
    }
}