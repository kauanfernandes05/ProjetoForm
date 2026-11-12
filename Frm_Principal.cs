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
        // variaveis globais para controle de estado do formulário.
        private int parteData = 0;
        private int proximoId = 1;
        private bool formatandoSalario = false;
        private DataGridViewRow linhaEmEdicao = null;
        private bool selecionandoCargo = false;
        private Cadastro cadastroEmEdicao = null;
        private readonly CultureInfo cultura =
           CultureInfo.GetCultureInfo("pt-BR");

        // Lista de cadastros armazenados na tabela.
        private System.ComponentModel.BindingList<Cadastro> cadastros;

        // Lista de cargos disponíveis para seleção.
        private readonly List<string> cargosDisponiveis = new List<string>
        {
            "Administrador",
            "Analista Administrativo",
            "Analista de Dados",
            "Analista de Sistemas",
            "Analista Financeiro",
            "Assistente Administrativo",
            "Auxiliar Administrativo",
            "Designer",
            "Desenvolvedor",
            "Desenvolvedor C#",
            "Desenvolvedor Front-end",
            "Desenvolvedor Back-end",
            "Desenvolvedor Full Stack",
            "Engenheiro de Software",
            "Estagiário de Desenvolvimento",
            "Engenheiro de projetos",
            "Estagiário de suporte técnico",
            "Estagiário de testes",
            "Gerente de Projetos",
            "Suporte Técnico",
            "Testador"
        };

        // Construtor do formulário principal, inicializando componentes e configurando a interface.
        public FormPrincipal()
        {
            InitializeComponent();

            ConfigurarCampos();
            ConectarEventos();
        }

        // Construtor que recebe a lista do menu
        public FormPrincipal(
            System.ComponentModel.BindingList<Cadastro> listaCadastros)
            : this()
        {
            cadastros = listaCadastros;
        }

        // construtor que recebe a lista do menu e o cadastro selecionado para edição
        public FormPrincipal(
            System.ComponentModel.BindingList<Cadastro> listaCadastros,
            Cadastro cadastroSelecionado)
            : this(listaCadastros)
        {
            cadastroEmEdicao = cadastroSelecionado;

            Txt_Nome.Text = cadastroSelecionado.Nome;
            Dtp_dataNsc.Value = cadastroSelecionado.DataNascimento;

            // Evita que a máscara altere o salário carregado.
            formatandoSalario = true;

            try
            {
                Txt_Salario.Text =
                    cadastroSelecionado.Salario.ToString("N2", cultura);
            }
            finally
            {
                formatandoSalario = false;
            }

            selecionandoCargo = true;

            try
            {
                Txt_Pesquisa.Text = cadastroSelecionado.Cargo;
            }
            finally
            {
                selecionandoCargo = false;
            }

            List_Cargos.Visible = false;

            rdb_Masc.Checked = cadastroSelecionado.Sexo == "Masculino";
            rdb_Fem.Checked = cadastroSelecionado.Sexo == "Feminino";

            chk_Transporte.Checked = cadastroSelecionado.ValeTransporte;
            chk_Alimentacao.Checked = cadastroSelecionado.ValeAlimentacao;
            chk_Saude.Checked = cadastroSelecionado.PlanoSaude;

            Btn_Adicionar.Text = "Alterar";
        }


        // Validação do campo de nome, permitindo apenas letras, números, espaços e pontos.
        private void Txt_NomeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        // Validação do campo de idade, permitindo apenas números e .
        private void Txt_IdadeKeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }
        private void Dtp_dataNsc_Enter(object sender, EventArgs e)
        {
            parteData = 0;
        }

        // funcionalidades do campo de salário, incluindo validação e formatação.
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

        // funcionalidades de pesquisa e seleção de cargo.
        private void Txt_Pesquisa_Enter(
            object sender,
            EventArgs e)
        {
            List_Cargos.Visible = true;
            List_Cargos.BringToFront();
        }
        private void Txt_Pesquisa_TextChanged(object sender, EventArgs e)
        {
            if (selecionandoCargo)
                return;

            string pesquisa = Txt_Pesquisa.Text.Trim();

            List_Cargos.BeginUpdate();

            try
            {
                List_Cargos.Items.Clear();

                foreach (string cargo in cargosDisponiveis)
                {
                    if (cargo.IndexOf(
                        pesquisa,
                        StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        List_Cargos.Items.Add(cargo);
                    }
                }

                List_Cargos.ClearSelected();
            }
            finally
            {
                List_Cargos.EndUpdate();
            }

            List_Cargos.Visible =
                Txt_Pesquisa.Focused && List_Cargos.Items.Count > 0;

            if (List_Cargos.Visible)
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

            string cargo = List_Cargos.SelectedItem.ToString();

            selecionandoCargo = true;

            try
            {
                Txt_Pesquisa.Text = cargo;
                Txt_Pesquisa.SelectionStart = Txt_Pesquisa.TextLength;
            }
            finally
            {
                selecionandoCargo = false;
            }

            List_Cargos.Visible = false;
           Dtp_dataNsc.Focus();
        }

        // Eventos para desenhar a borda de foco nos CheckBoxes de benefícios.
        private void Beneficio_Enter(object? sender, EventArgs e)
        {
            ((CheckBox)sender).Invalidate();
        }
        private void Beneficio_Leave(object sender, EventArgs e)
        {
            ((CheckBox)sender).Invalidate();
        }
        private void Beneficio_Paint(object? sender, PaintEventArgs e)
        {
            CheckBox beneficio = (CheckBox)sender;

            if (!beneficio.Focused)
                return;

            Rectangle borda = beneficio.ClientRectangle;
            borda.Inflate(-1, -1);

            ControlPaint.DrawFocusRectangle(
                e.Graphics,
                borda,
                beneficio.ForeColor,
                beneficio.BackColor
            );
        }
        private void Beneficio_Focus(object sender, EventArgs e)
        {
            CheckBox beneficio = (CheckBox)sender;

            beneficio.BackColor = Color.LightBlue;
            beneficio.ForeColor = Color.Black;
        }

        // Foca o primeiro RadioButton de sexo marcado, caso haja algum.
        private void FocarSexo()
        {
            if (rdb_Fem.Checked)
                rdb_Fem.Focus();
            else
                rdb_Masc.Focus();
        }

        // botões de ação: Adicionar.
        private async void Btn_Adicionar_Click(object sender, EventArgs e)
        {
            if (cadastros == null)
            {
                MessageBox.Show("Abra a tela de cadastro pelo menu.");
                return;
            }

            string nome = System.Text.RegularExpressions.Regex.Replace(
                Txt_Nome.Text.Trim(),
                " +",
                " "
            );

            DateTime nascimento = Dtp_dataNsc.Value.Date;
            DateTime hoje = DateTime.Today;
            string cargo = Txt_Pesquisa.Text.Trim();

            // Validação do nome ou razão social.
            bool nomeValido = nome.Length > 0 && nome.Length <= 150;

            foreach (char caractere in nome)
            {
                if (!char.IsLetterOrDigit(caractere) &&
                    caractere != ' ' &&
                    caractere != '.')
                {
                    nomeValido = false;
                    break;
                }
            }

            if (!nomeValido)
            {
                MessageBox.Show(
                    "Informe um nome ou razão social com até 150 caracteres, " +
                    "usando letras, números, espaços e pontos."
                );

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
                MessageBox.Show(
                    "É necessário ter pelo menos 18 anos para realizar o cadastro."
                );

                Dtp_dataNsc.Focus();
                return;
            }

            if (nascimento < hoje.AddYears(-120))
            {
                MessageBox.Show(
                    "Confira a data de nascimento. O limite permitido é de 120 anos."
                );

                Dtp_dataNsc.Focus();
                return;
            }

            // Validação do salário.
            if (!TentarLerSalario(out decimal salario) ||
                salario < 800m ||
                salario > 9999999.99m)
            {
                MessageBox.Show(
                    "Informe um salário entre R$ 800,00 e R$ 9.999.999,99."
                );

                Txt_Salario.Focus();
                return;
            }

            // Consulta a lista completa de cargos.
            string cargoEncontrado = cargosDisponiveis.Find(
                item => string.Equals(
                    item,
                    cargo,
                    StringComparison.CurrentCultureIgnoreCase
                )
            );

            if (cargoEncontrado == null)
            {
                MessageBox.Show("Selecione um cargo válido da lista.");
                Txt_Pesquisa.Focus();
                return;
            }

            cargo = cargoEncontrado;

            // Exatamente uma opção de sexo deve estar marcada.
            if (rdb_Masc.Checked == rdb_Fem.Checked)
            {
                MessageBox.Show("Selecione uma opção de sexo.");
                FocarSexo();
                return;
            }

            string sexo = rdb_Masc.Checked ? "Masculino" : "Feminino";

            // Verifica duplicidade na lista carregada.
            foreach (Cadastro registro in cadastros)
            {
                // Ignora o próprio cadastro durante a edição.
                if (registro == cadastroEmEdicao)
                    continue;

                string nomeExistente =
                    System.Text.RegularExpressions.Regex.Replace(
                        registro.Nome.Trim(),
                        " +",
                        " "
                    );

                bool duplicado =
                    string.Equals(
                        nomeExistente,
                        nome,
                        StringComparison.OrdinalIgnoreCase
                    ) &&
                    registro.DataNascimento.Date == nascimento &&
                    registro.Salario == salario &&
                    string.Equals(
                        registro.Cargo,
                        cargo,
                        StringComparison.OrdinalIgnoreCase
                    ) &&
                    registro.Sexo == sexo &&
                    registro.ValeTransporte == chk_Transporte.Checked &&
                    registro.ValeAlimentacao == chk_Alimentacao.Checked &&
                    registro.PlanoSaude == chk_Saude.Checked;

                if (duplicado)
                {
                    MessageBox.Show(
                        this,
                        "Já existe um cadastro com esses mesmos dados.",
                        "Cadastro duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    Txt_Nome.Focus();
                    return;
                }
            }

            bool editando = cadastroEmEdicao != null;

            // Confirma a inclusão ou a edição.
            DialogResult resposta = MessageBox.Show(
                this,
                editando
                    ? $"Deseja salvar as alterações do usuário \"{nome}\"?"
                    : $"Deseja cadastrar o usuário \"{nome}\" na lista?",
                editando ? "Confirmar edição" : "Confirmar cadastro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta != DialogResult.Yes)
                return;

            // Prepara os dados sem modificar o objeto original.
            Cadastro cadastro = new Cadastro
            {
                Id = editando ? cadastroEmEdicao.Id : 0,
                Nome = nome,
                DataNascimento = nascimento,
                Salario = salario,
                Cargo = cargo,
                Sexo = sexo,
                ValeTransporte = chk_Transporte.Checked,
                ValeAlimentacao = chk_Alimentacao.Checked,
                PlanoSaude = chk_Saude.Checked
            };

            Btn_Adicionar.Enabled = false;

            try
            {
                CadastroRepository repositorio = new CadastroRepository();

                if (editando)
                {
                    bool atualizado =
                        await repositorio.AtualizarAsync(cadastro);

                    if (!atualizado)
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
                }
                else
                {
                    // O SQL Server gera o ID do novo cadastro.
                    cadastro.Id = await repositorio.InserirAsync(cadastro);
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(
                    this,
                    "Não foi possível salvar os dados no banco.\n\n" +
                    ex.Message,
                    "Erro ao salvar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }
            finally
            {
                Btn_Adicionar.Enabled = true;
            }

            // Atualiza o menu somente após salvar no banco.
            if (editando)
            {
                cadastroEmEdicao.Nome = cadastro.Nome;
                cadastroEmEdicao.DataNascimento = cadastro.DataNascimento;
                cadastroEmEdicao.Salario = cadastro.Salario;
                cadastroEmEdicao.Cargo = cadastro.Cargo;
                cadastroEmEdicao.Sexo = cadastro.Sexo;
                cadastroEmEdicao.ValeTransporte = cadastro.ValeTransporte;
                cadastroEmEdicao.ValeAlimentacao = cadastro.ValeAlimentacao;
                cadastroEmEdicao.PlanoSaude = cadastro.PlanoSaude;

                cadastros.ResetItem(cadastros.IndexOf(cadastroEmEdicao));
            }
            else
            {
                cadastros.Add(cadastro);
            }

            MessageBox.Show(
                this,
                editando
                    ? $"Usuário \"{nome}\" alterado com sucesso!"
                    : $"Usuário \"{nome}\" cadastrado com sucesso!",
                editando ? "Edição concluída" : "Cadastro concluído",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Após editar, volta diretamente ao menu.
            if (editando)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            // Somente no cadastro novo pergunta se deseja continuar.
            DialogResult cadastrarOutro = MessageBox.Show(
                this,
                "Deseja cadastrar outro usuário?",
                "Novo cadastro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cadastrarOutro == DialogResult.Yes)
            {
                LimparCampos();
                Txt_Nome.Focus();
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        // Configurações iniciais da tabela de cadastros.
        private void ConfigurarCampos()
        {
            Dtp_dataNsc.Format = DateTimePickerFormat.Custom;
            Dtp_dataNsc.CustomFormat = "dd/MM/yyyy";

            Txt_Pesquisa.ReadOnly = false;

            Txt_Salario.MaxLength = 12;
            Txt_Salario.TextAlign = HorizontalAlignment.Right;

            List_Cargos.Items.Clear();

            List_Cargos.Items.AddRange(cargosDisponiveis.ToArray());

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

            CheckBox[] beneficios =
            {
                chk_Transporte,
                chk_Alimentacao,
                chk_Saude
            };

            foreach (Control campo in campos)
            {
                campo.KeyDown -= Campos_KeyDown;
                campo.KeyDown += Campos_KeyDown;
            }

            foreach (CheckBox beneficio in beneficios)
            {
                beneficio.Enter -= Beneficio_Enter;
                beneficio.Enter += Beneficio_Enter;

                beneficio.Leave -= Beneficio_Leave;
                beneficio.Leave += Beneficio_Leave;

                beneficio.Paint -= Beneficio_Paint;
                beneficio.Paint += Beneficio_Paint;
            }

            Txt_Salario.TextChanged -= Txt_Salario_TextChanged;
            Txt_Salario.TextChanged += Txt_Salario_TextChanged;

            Txt_Salario.Leave -= Txt_Salario_Leave;
            Txt_Salario.Leave += Txt_Salario_Leave;

            Dtp_dataNsc.Enter -= Dtp_dataNsc_Enter;
            Dtp_dataNsc.Enter += Dtp_dataNsc_Enter;

            List_Cargos.Click -= List_Cargos_Click;
            List_Cargos.Click += List_Cargos_Click;

            Txt_Pesquisa.TextChanged -= Txt_Pesquisa_TextChanged;
            Txt_Pesquisa.TextChanged += Txt_Pesquisa_TextChanged;

            List_Cargos.KeyDown -= List_Cargos_KeyDown;
            List_Cargos.KeyDown += List_Cargos_KeyDown;

            Btn_Adicionar.Click -= Btn_Adicionar_Click;
            Btn_Adicionar.Click += Btn_Adicionar_Click;

            Txt_Salario.TextChanged -= Txt_Salario_TextChanged;
            Txt_Salario.TextChanged += Txt_Salario_TextChanged;

            chk_Transporte.KeyDown -= Campos_KeyDown;
            chk_Transporte.KeyDown += Campos_KeyDown;

            chk_Alimentacao.KeyDown -= Campos_KeyDown;
            chk_Alimentacao.KeyDown += Campos_KeyDown;

            chk_Saude.KeyDown -= Campos_KeyDown;
            chk_Saude.KeyDown += Campos_KeyDown;

        }

        // Trata a navegação entre os campos usando a tecla Enter.
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
                Txt_Pesquisa.Focus(); // Cargo
            }
            else if (sender == Txt_Pesquisa)
            {
                if (List_Cargos.SelectedItem != null)
                {
                    ConfirmarCargo();
                }
                else if (List_Cargos.Items.Count > 0)
                {
                    List_Cargos.Visible = true;
                    List_Cargos.BringToFront();

                    List_Cargos.SelectedIndex = 0;
                    List_Cargos.Focus();
                }
            }
            else if (sender == Dtp_dataNsc)
            {
                if (parteData < 2)
                {
                    parteData++;
                    SendKeys.SendWait("{RIGHT}");
                }
                else
                {
                    // Retorna a seleção ao dia antes de sair.
                    SendKeys.SendWait("{RIGHT}");

                    parteData = 0;
                    Txt_Salario.Focus();
                }
            }
            else if (sender == Txt_Salario)
            {
                FocarSexo();
            }
            else if (sender == rdb_Masc || sender == rdb_Fem)
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

        // Bloqueia a tecla Tab duante a navegação entre os campos.
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

        private void FormPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                e.SuppressKeyPress = true;
            }
        }

        private void btnFecharP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                this,
                "Deseja realmente fechar o formulário?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void LimparCampos()
        {
            cadastroEmEdicao = null;

            Txt_Nome.Clear();

            formatandoSalario = true;

            try
            {
                Txt_Salario.Clear();
            }
            finally
            {
                formatandoSalario = false;
            }

            selecionandoCargo = true;

            try
            {
                Txt_Pesquisa.Clear();

                List_Cargos.Items.Clear();
                List_Cargos.Items.AddRange(cargosDisponiveis.ToArray());
                List_Cargos.ClearSelected();
                List_Cargos.Visible = false;
            }
            finally
            {
                selecionandoCargo = false;
            }

            Dtp_dataNsc.Value = DateTime.Today;
            parteData = 0;

            rdb_Masc.Checked = false;
            rdb_Fem.Checked = false;

            chk_Transporte.Checked = false;
            chk_Alimentacao.Checked = false;
            chk_Saude.Checked = false;

            Btn_Adicionar.Text = "Salvar";

            Txt_Nome.Focus();
        }
    }
}