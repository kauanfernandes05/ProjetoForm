using ProjetoForm.Models;
using ProjetoForm.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ProjetoForm.Validacoes;

namespace ProjetoForm
{
    public partial class FormCadastro : Form
    {

        // Variaveis para validações de formulario
        private readonly CadastroValidator cadastroValidator = new CadastroValidator();

        // Estado do formulário.
        private int parteData;
        private bool formatandoSalario;
        private bool selecionandoCargo;
        private Cadastro? cadastroEmEdicao;

        // O fechamento automático só é liberado após salvar com sucesso.
        private bool salvandoCadastro;
        private bool fechamentoAposSalvar;
        private string dadosIniciais = "";

        // Lista compartilhada com o menu. O construtor vazio atende ao Designer.
        private readonly BindingList<Cadastro>? cadastros;
        private readonly CultureInfo cultura =
            CultureInfo.GetCultureInfo("pt-BR");

        // Não é apagado ao limpar os campos: identifica a última inclusão.
        public int? UltimoIdCadastrado { get; private set; }

        // Opções disponíveis para pesquisa e seleção de cargo.
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

        // Construtores.

        public FormCadastro()
        {
            InitializeComponent();
            MaximizeBox = false;
            KeyPreview = true;

            // Os botões não podem encerrar o diálogo por configuração do Designer.
            ConfigurarResultadosDosBotoes(this);
            DialogResult = DialogResult.None;

            ConfigurarCampos();
            ConectarEventos();
            ConfigurarCliquesForaDaLista(this);
        }

        public FormCadastro(BindingList<Cadastro> listaCadastros) : this()
        {
            cadastros = listaCadastros;
        }

        public FormCadastro(BindingList<Cadastro> listaCadastros, Cadastro cadastroSelecionado) : this(listaCadastros)
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

        // Configuração e ligação dos eventos.

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

            Txt_Pesquisa.Enter -= Txt_Pesquisa_Enter;
            Txt_Pesquisa.Enter += Txt_Pesquisa_Enter;

            List_Cargos.KeyDown -= List_Cargos_KeyDown;
            List_Cargos.KeyDown += List_Cargos_KeyDown;

            Btn_Adicionar.Click -= Btn_Adicionar_Click;
            Btn_Adicionar.Click += Btn_Adicionar_Click;


            chk_Transporte.KeyDown -= Campos_KeyDown;
            chk_Transporte.KeyDown += Campos_KeyDown;

            chk_Alimentacao.KeyDown -= Campos_KeyDown;
            chk_Alimentacao.KeyDown += Campos_KeyDown;

            chk_Saude.KeyDown -= Campos_KeyDown;
            chk_Saude.KeyDown += Campos_KeyDown;

            KeyDown -= FormCadastro_KeyDown;
            KeyDown += FormCadastro_KeyDown;

            Txt_Pesquisa.Leave -= OcultarListaCargosAoSair;
            Txt_Pesquisa.Leave += OcultarListaCargosAoSair;
            List_Cargos.Leave -= OcultarListaCargosAoSair;
            List_Cargos.Leave += OcultarListaCargosAoSair;
        }

        // Limpeza dos campos e foco.

        private void LimparCampos(bool manterEdicao = false)
        {
            fechamentoAposSalvar = false;
            DialogResult = DialogResult.None;
            if (!manterEdicao)
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

            // Mantém a data dentro dos limites do controle.
            DateTime dataPadrao = DateTime.Today;

            if (dataPadrao < Dtp_dataNsc.MinDate)
                dataPadrao = Dtp_dataNsc.MinDate;
            else if (dataPadrao > Dtp_dataNsc.MaxDate)
                dataPadrao = Dtp_dataNsc.MaxDate;

            Dtp_dataNsc.Value = dataPadrao;
            parteData = 0;

            rdb_Masc.Checked = false;
            rdb_Fem.Checked = false;

            chk_Transporte.Checked = false;
            chk_Alimentacao.Checked = false;
            chk_Saude.Checked = false;

            Btn_Adicionar.Text = cadastroEmEdicao == null
                ? "Salvar"
                : "Alterar";

            if (cadastroEmEdicao == null)
            {
                DialogResult = DialogResult.None;

                // O formulário vazio passa a ser a referência
                // para identificar alterações não salvas.
                dadosIniciais = ObterEstadoDosCampos();
            }

            Txt_Nome.Focus();
        }

        private void FocarSexo()
        {
            if (rdb_Fem.Checked)
                rdb_Fem.Focus();
            else
                rdb_Masc.Focus();
        }

        // Validação das entradas e data de nascimento.

        private void Txt_NomeKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'º' || e.KeyChar == '°' || e.KeyChar == 'ª')
            {
                e.Handled = true;
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != '.' &&
                e.KeyChar != '-' &&
                e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void Txt_IdadeKeyPress( object? sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        private void Dtp_dataNsc_Enter(object? sender, EventArgs e)
        {
            parteData = 0;
        }

        // Leitura e formatação do salário.

        private bool TentarLerSalario(out decimal salario)
        {
            string texto = Txt_Salario.Text.Trim();

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

        private void Txt_Salario_TextChanged(object? sender, EventArgs e)
        {
            if (formatandoSalario)
                return;

            string texto = Txt_Salario.Text;

            if (string.IsNullOrEmpty(texto)) return;

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

        private void Txt_Salario_Leave(object? sender, EventArgs e)
        {
            if (TentarLerSalario(out decimal salario))
            {
                Txt_Salario.Text =
                    salario.ToString("N2", cultura);
            }
        }

        private void Txt_Pesquisa_Enter(object? sender, EventArgs e)
        {
            List_Cargos.Visible = false;
        }

        private void Txt_Pesquisa_TextChanged(object? sender, EventArgs e)
        {
            if (selecionandoCargo)
                return;

            List_Cargos.ClearSelected();
            List_Cargos.Visible = false;
        }

        private void PesquisarCargos()
        {
            string pesquisa = Txt_Pesquisa.Text.Trim();

            List_Cargos.Visible = false;
            List_Cargos.Items.Clear();

            if (string.IsNullOrWhiteSpace(pesquisa))
                return;

            foreach (string cargo in cargosDisponiveis)
            {
                if (cargo.Contains(
                    pesquisa,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    List_Cargos.Items.Add(cargo);
                }
            }

            if (List_Cargos.Items.Count == 0)
            {
                MessageBox.Show(
                    this,
                    "Nenhum cargo encontrado.",
                    "Pesquisa de cargos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Txt_Pesquisa.Focus();
                return;
            }

            List_Cargos.Visible = true;
            List_Cargos.BringToFront();
            List_Cargos.SelectedIndex = 0;
            List_Cargos.Focus();
        }

        private void ConfirmarCargo()
        {
            if (List_Cargos.SelectedItem == null)
                return;

            string cargo = Convert.ToString(List_Cargos.SelectedItem) ?? "";

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
            
        private void List_Cargos_Click( object? sender,EventArgs e)
        {
            ConfirmarCargo();
        }

        private void List_Cargos_KeyDown( object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            ConfirmarCargo();
        }

        private void OcultarListaCargosAoSair(object? sender, EventArgs e)
        {
            if (IsDisposed || Disposing || !IsHandleCreated)
                return;

            BeginInvoke(new Action(() =>
            {
                if (IsDisposed || Disposing)
                    return;

                if (!Txt_Pesquisa.ContainsFocus &&
                    !List_Cargos.ContainsFocus)
                {
                    List_Cargos.Visible = false;
                }
            }));
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

        private void OcultarListaAoClicarFora(object? sender, MouseEventArgs e)
        {
            if (sender is not Control controle)
                return;

            // Permite digitar no campo e selecionar os cargos.
            if (controle == Txt_Pesquisa ||
                Txt_Pesquisa.Contains(controle) ||
                controle == List_Cargos ||
                List_Cargos.Contains(controle))
            {
                return;
            }

            List_Cargos.Visible = false;
        }

        // Indicação de foco nos benefícios.

        private void Beneficio_Enter(object? sender, EventArgs e)
        {
            if (sender is CheckBox beneficio)
                beneficio.Invalidate();
        }

        private void Beneficio_Leave(object? sender, EventArgs e)
        {
            if (sender is CheckBox beneficio)
                beneficio.Invalidate();
        }

        private void Beneficio_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not CheckBox beneficio || !beneficio.Focused)
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

        private void Beneficio_Focus(object? sender, EventArgs e)
        {
            if (sender is not CheckBox beneficio)
                return;

            beneficio.BackColor = Color.LightBlue;
            beneficio.ForeColor = Color.Black;
        }

        // Eventos dos botões: salvar, alterar e fechar.

        private async void Btn_Adicionar_Click(object? sender, EventArgs e)
        {
            if (salvandoCadastro || !Btn_Adicionar.Enabled)
                return;

            if (!TentarObterCadastro(out Cadastro cadastro))
                return;

            Cadastro? cadastroOriginal = cadastroEmEdicao;
            bool editando = cadastroOriginal != null;

            string nome = cadastro.Nome;

            if (!ConfirmarSalvamento(nome, editando))
                return;

            DefinirSalvamento(true);

            try
            {
                CadastroRepository repositorio = new CadastroRepository();

                if (cadastroOriginal != null)
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
                    cadastro.Id = await repositorio.InserirAsync(cadastro);
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(this,"Não foi possível salvar os dados no banco.\n\n" + ex.Message,"Erro ao salvar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }
            finally
            {
                DefinirSalvamento(true);
            }

            if (cadastroOriginal != null)
            {
                cadastroOriginal.Nome = cadastro.Nome;
                cadastroOriginal.DataNascimento = cadastro.DataNascimento;
                cadastroOriginal.Salario = cadastro.Salario;
                cadastroOriginal.Cargo = cadastro.Cargo;
                cadastroOriginal.Sexo = cadastro.Sexo;
                cadastroOriginal.ValeTransporte = cadastro.ValeTransporte;
                cadastroOriginal.ValeAlimentacao = cadastro.ValeAlimentacao;
                cadastroOriginal.PlanoSaude = cadastro.PlanoSaude;

                cadastros.ResetItem(cadastros.IndexOf(cadastroOriginal));
            }
            else
            {
                cadastros.Add(cadastro);
                UltimoIdCadastrado = cadastro.Id;
            }

            dadosIniciais = ObterEstadoDosCampos();

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
            if (cadastroOriginal != null)
            {
                fechamentoAposSalvar = true;
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
                DefinirSalvamento(false);
                Txt_Nome.Focus();
            }
            else
            {
                fechamentoAposSalvar = true;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public bool TentarObterCadastro(out Cadastro cadastro)
        {
            cadastro = new Cadastro();

            if (cadastros == null)
            {
                MessageBox.Show("Abra a tela de cadastro pelo menu.");
                return false;
            }

            string nome = Regex.Replace(Txt_Nome.Text.Trim(), " +", " ");

            DateTime nascimento = Dtp_dataNsc.Value.Date;
            DateTime hoje = DateTime.Today;
            string cargo = Txt_Pesquisa.Text.Trim();

            // Validação do nome ou razão social.
            if (!cadastroValidator.ValidarNome(nome))
            {
                MessageBox.Show(
                    this,
                    "Informe um nome ou razão social com até 150 caracteres, " +
                    "pelo menos duas letras, começando com letra ou número. " +
                    "Use apenas letras, números, espaços, pontos, traços e barras, " +
                    "sem três ou mais símbolos consecutivos.",
                    "Confira o nome",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );

                Txt_Nome.Focus();
                return false;
            }

            // validação de data de nascimento
            if (!cadastroValidator.ValidarNascimento(nascimento, hoje))
            {
                MessageBox.Show(
                    this,
                    "Informe uma data de nascimento válida, " +
                    "que não seja futura e esteja dentro dos limites de 18 a 120 anos.",
                    "Confira a data de nascimento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Dtp_dataNsc.Focus();
                return false;
            }

            // Validação do salário.
            if (!TentarLerSalario(out decimal salario) || !cadastroValidator.ValidarSalario(salario))
            {
                MessageBox.Show(
                    this,
                    "Informe um salário entre R$ 800,00 e R$ 9.999.999,99.",
                    "Confira o salário",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Txt_Salario.Focus();
                return false;
            }

            // validação e Consulta a lista completa de cargos.
            if (!cadastroValidator.ValidarCargo(cargo, cargosDisponiveis))
            {
                MessageBox.Show(
                    this,
                    "Selecione um cargo válido da lista.",
                    "Confira o cargo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Txt_Pesquisa.Focus();
                return false;
            }

            // Mantém a escrita original do cargo da lista.
            cargo = cargosDisponiveis.First(item => string.Equals(item, cargo, StringComparison.CurrentCultureIgnoreCase));

            // Exatamente uma opção de sexo deve estar marcada.
            if (rdb_Masc.Checked == rdb_Fem.Checked)
            {
                MessageBox.Show("Selecione uma opção de sexo.");
                FocarSexo();
                return false;
            }

            string sexo = rdb_Masc.Checked ? "Masculino" : "Feminino";

            // Verifica duplicidade na lista carregada.
            Cadastro dadosParaValidar = new Cadastro
            {
                Nome = nome,
                DataNascimento = nascimento,
                Salario = salario,
                Cargo = cargo,
                Sexo = sexo,
                ValeTransporte = chk_Transporte.Checked,
                ValeAlimentacao = chk_Alimentacao.Checked,
                PlanoSaude = chk_Saude.Checked
            };

            if (cadastroValidator.ExisteDuplicado(dadosParaValidar, cadastros, cadastroEmEdicao))
            {
                MessageBox.Show(
                    this,
                    "Já existe um cadastro com esses mesmos dados.",
                    "Cadastro duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Txt_Nome.Focus();
                return false;
            }

            cadastro = dadosParaValidar;
            cadastro.Id = cadastroEmEdicao?.Id ?? 0;

            return true;
        }

        public bool ConfirmarSalvamento(string nome, bool editando)
        {
            DialogResult resposta = MessageBox.Show(this, editando
                    ? $"Deseja salvar as alterações do usuário \"{nome}\"?"
                    : $"Deseja cadastrar o usuário \"{nome}\" na lista?",
                editando ? "Confirmar edição" : "Confirmar cadastro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return resposta == DialogResult.Yes;
        }

        public void DefinirSalvamento(bool salvando)
        {
            salvandoCadastro = salvando;
            if (IsDisposed || Disposing) return;
            Btn_Adicionar.Enabled = !salvando;
        }

        private void btnFecharP_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // Navegação com Enter e atalhos. A navegação com Tab permanece padrão.
        private void Campos_KeyDown(object? sender, KeyEventArgs e)
        {
            // Do campo cargo, entra na lista usando as setas.
            if (sender == Txt_Pesquisa && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                List_Cargos.Visible = true;
                List_Cargos.BringToFront();

                if (List_Cargos.Items.Count > 0)
                {
                    if (List_Cargos.SelectedIndex < 0)
                    {
                        List_Cargos.SelectedIndex = e.KeyCode == Keys.Down ? 0: List_Cargos.Items.Count - 1;
                    }

                    List_Cargos.Focus();
                }
                return;
            }

            if (e.KeyCode != Keys.Enter)return;
            e.Handled = true;
            e.SuppressKeyPress = true;

            if (sender == Txt_Nome)
            {
                Txt_Pesquisa.Focus(); // Cargo
            }
            else if (sender == Txt_Pesquisa)
            {
                PesquisarCargos();
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
        private void FormCadastro_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Modifiers != Keys.None)
                return;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    btnFecharP_Click(sender, e);
                    break;

                case Keys.F4:
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    if (Btn_Adicionar.Enabled)
                        LimparCampos(manterEdicao: true);
                    break;

                case Keys.F5:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    Btn_Adicionar.PerformClick();
                    break;
            }
        }
        // Controle de alterações não salvas e fechamento da tela.
        private string ObterEstadoDosCampos()
        {
            return string.Join("\u001F",
                Txt_Nome.Text,
                Dtp_dataNsc.Value.Date.ToString("yyyy-MM-dd"),
                Txt_Salario.Text,
                Txt_Pesquisa.Text,
                rdb_Masc.Checked.ToString(),
                rdb_Fem.Checked.ToString(),
                chk_Transporte.Checked.ToString(),
                chk_Alimentacao.Checked.ToString(),
                chk_Saude.Checked.ToString()
            );
        }

        private void ConfigurarResultadosDosBotoes(Control controle)
        {
            if (controle is Button botao)
                botao.DialogResult = DialogResult.None;

            foreach (Control filho in controle.Controls)
                ConfigurarResultadosDosBotoes(filho);
        }

        protected override void OnShown(EventArgs e)
        {
            fechamentoAposSalvar = false;
            DialogResult = DialogResult.None;
            dadosIniciais = ObterEstadoDosCampos();

            base.OnShown(e);
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!fechamentoAposSalvar)
            {
                bool possuiAlteracoes =
                    ObterEstadoDosCampos() != dadosIniciais;

                if (possuiAlteracoes)
                {
                    DialogResult resposta = MessageBox.Show(
                        this,
                        "Existem alterações não salvas. Deseja mesmo fechar? " +
                        "Os dados não salvos serão perdidos.",
                        "Confirmar saída",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2
                    );

                    if (resposta != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        DialogResult = DialogResult.None;
                    }
                }
            }
            base.OnFormClosing(e);
        }
    }
}
