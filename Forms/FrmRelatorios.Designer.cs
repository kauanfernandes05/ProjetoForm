namespace ProjetoForm
{
    partial class FrmRelatorios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpFiltros = new GroupBox();
            chkFiltroTodos = new CheckBox();
            lbTodos = new Label();
            chkFiltroSaude = new CheckBox();
            chkFiltroAlimentacao = new CheckBox();
            chkFiltroTransporte = new CheckBox();
            grpOrdenacao = new GroupBox();
            rdbOrdenarSalario = new RadioButton();
            rdbOrdenarNascimento = new RadioButton();
            rdbOrdenarNome = new RadioButton();
            rdbOrdenarID = new RadioButton();
            lbSaude = new Label();
            btnRemoveCargo = new Button();
            lbTransporte = new Label();
            lbAlimentacao = new Label();
            lstCargosSelecionados = new ListBox();
            lstSugestoesCargos = new ListBox();
            txtPesquisaCargo = new TextBox();
            lbAviso = new Label();
            btnFechar = new Button();
            btnLimparFiltros = new Button();
            btnGerarRelatorio = new Button();
            cmbSexo = new ComboBox();
            lbSexo = new Label();
            lbCargo = new Label();
            txtSalarioMax = new TextBox();
            txtSalarioMin = new TextBox();
            lbSalarioMax = new Label();
            lbSalarioMin = new Label();
            lbDataFinal = new Label();
            dtpNascimentoFinal = new DateTimePicker();
            lbDataIncial = new Label();
            dtpNascimentoInicial = new DateTimePicker();
            lbNome = new Label();
            txtNome = new TextBox();
            lbIDFinal = new Label();
            txtIdFinal = new TextBox();
            lbIDinicial = new Label();
            txtIdInicial = new TextBox();
            statusStrip1 = new StatusStrip();
            TspEsc = new ToolStripStatusLabel();
            TspF2 = new ToolStripStatusLabel();
            TspF4 = new ToolStripStatusLabel();
            tspDel = new ToolStripStatusLabel();
            grpFiltros.SuspendLayout();
            grpOrdenacao.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpFiltros
            // 
            grpFiltros.Controls.Add(chkFiltroTodos);
            grpFiltros.Controls.Add(lbTodos);
            grpFiltros.Controls.Add(chkFiltroSaude);
            grpFiltros.Controls.Add(chkFiltroAlimentacao);
            grpFiltros.Controls.Add(chkFiltroTransporte);
            grpFiltros.Controls.Add(grpOrdenacao);
            grpFiltros.Controls.Add(lbSaude);
            grpFiltros.Controls.Add(btnRemoveCargo);
            grpFiltros.Controls.Add(lbTransporte);
            grpFiltros.Controls.Add(lbAlimentacao);
            grpFiltros.Controls.Add(lstCargosSelecionados);
            grpFiltros.Controls.Add(lstSugestoesCargos);
            grpFiltros.Controls.Add(txtPesquisaCargo);
            grpFiltros.Controls.Add(lbAviso);
            grpFiltros.Controls.Add(btnFechar);
            grpFiltros.Controls.Add(btnLimparFiltros);
            grpFiltros.Controls.Add(btnGerarRelatorio);
            grpFiltros.Controls.Add(cmbSexo);
            grpFiltros.Controls.Add(lbSexo);
            grpFiltros.Controls.Add(lbCargo);
            grpFiltros.Controls.Add(txtSalarioMax);
            grpFiltros.Controls.Add(txtSalarioMin);
            grpFiltros.Controls.Add(lbSalarioMax);
            grpFiltros.Controls.Add(lbSalarioMin);
            grpFiltros.Controls.Add(lbDataFinal);
            grpFiltros.Controls.Add(dtpNascimentoFinal);
            grpFiltros.Controls.Add(lbDataIncial);
            grpFiltros.Controls.Add(dtpNascimentoInicial);
            grpFiltros.Controls.Add(lbNome);
            grpFiltros.Controls.Add(txtNome);
            grpFiltros.Controls.Add(lbIDFinal);
            grpFiltros.Controls.Add(txtIdFinal);
            grpFiltros.Controls.Add(lbIDinicial);
            grpFiltros.Controls.Add(txtIdInicial);
            grpFiltros.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFiltros.Location = new Point(12, 12);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Size = new Size(955, 452);
            grpFiltros.TabIndex = 0;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Filtros do relatório";
            // 
            // chkFiltroTodos
            // 
            chkFiltroTodos.AutoSize = true;
            chkFiltroTodos.Location = new Point(489, 358);
            chkFiltroTodos.Name = "chkFiltroTodos";
            chkFiltroTodos.Size = new Size(15, 14);
            chkFiltroTodos.TabIndex = 37;
            chkFiltroTodos.UseVisualStyleBackColor = true;
            // 
            // lbTodos
            // 
            lbTodos.AutoSize = true;
            lbTodos.Location = new Point(418, 354);
            lbTodos.Name = "lbTodos";
            lbTodos.Size = new Size(66, 21);
            lbTodos.TabIndex = 36;
            lbTodos.Text = "Todos: ";
            // 
            // chkFiltroSaude
            // 
            chkFiltroSaude.AutoSize = true;
            chkFiltroSaude.Location = new Point(576, 323);
            chkFiltroSaude.Name = "chkFiltroSaude";
            chkFiltroSaude.Size = new Size(15, 14);
            chkFiltroSaude.TabIndex = 35;
            chkFiltroSaude.UseVisualStyleBackColor = true;
            // 
            // chkFiltroAlimentacao
            // 
            chkFiltroAlimentacao.AutoSize = true;
            chkFiltroAlimentacao.Location = new Point(576, 282);
            chkFiltroAlimentacao.Name = "chkFiltroAlimentacao";
            chkFiltroAlimentacao.Size = new Size(15, 14);
            chkFiltroAlimentacao.TabIndex = 34;
            chkFiltroAlimentacao.UseVisualStyleBackColor = true;
            // 
            // chkFiltroTransporte
            // 
            chkFiltroTransporte.AutoSize = true;
            chkFiltroTransporte.Location = new Point(576, 243);
            chkFiltroTransporte.Name = "chkFiltroTransporte";
            chkFiltroTransporte.Size = new Size(15, 14);
            chkFiltroTransporte.TabIndex = 33;
            chkFiltroTransporte.UseVisualStyleBackColor = true;
            // 
            // grpOrdenacao
            // 
            grpOrdenacao.Controls.Add(rdbOrdenarSalario);
            grpOrdenacao.Controls.Add(rdbOrdenarNascimento);
            grpOrdenacao.Controls.Add(rdbOrdenarNome);
            grpOrdenacao.Controls.Add(rdbOrdenarID);
            grpOrdenacao.Location = new Point(691, 230);
            grpOrdenacao.Name = "grpOrdenacao";
            grpOrdenacao.Size = new Size(255, 147);
            grpOrdenacao.TabIndex = 32;
            grpOrdenacao.TabStop = false;
            grpOrdenacao.Text = "Ordenar relatório por";
            // 
            // rdbOrdenarSalario
            // 
            rdbOrdenarSalario.AutoSize = true;
            rdbOrdenarSalario.Location = new Point(6, 118);
            rdbOrdenarSalario.Name = "rdbOrdenarSalario";
            rdbOrdenarSalario.Size = new Size(211, 25);
            rdbOrdenarSalario.TabIndex = 3;
            rdbOrdenarSalario.TabStop = true;
            rdbOrdenarSalario.Text = "Salario: maior primeiro";
            rdbOrdenarSalario.UseVisualStyleBackColor = true;
            // 
            // rdbOrdenarNascimento
            // 
            rdbOrdenarNascimento.AutoSize = true;
            rdbOrdenarNascimento.Location = new Point(6, 87);
            rdbOrdenarNascimento.Name = "rdbOrdenarNascimento";
            rdbOrdenarNascimento.Size = new Size(200, 25);
            rdbOrdenarNascimento.TabIndex = 2;
            rdbOrdenarNascimento.TabStop = true;
            rdbOrdenarNascimento.Text = "Nascimento crescente";
            rdbOrdenarNascimento.UseVisualStyleBackColor = true;
            // 
            // rdbOrdenarNome
            // 
            rdbOrdenarNome.AutoSize = true;
            rdbOrdenarNome.Location = new Point(6, 56);
            rdbOrdenarNome.Name = "rdbOrdenarNome";
            rdbOrdenarNome.Size = new Size(144, 25);
            rdbOrdenarNome.TabIndex = 1;
            rdbOrdenarNome.TabStop = true;
            rdbOrdenarNome.Text = "Nome de A a Z";
            rdbOrdenarNome.UseVisualStyleBackColor = true;
            // 
            // rdbOrdenarID
            // 
            rdbOrdenarID.AutoSize = true;
            rdbOrdenarID.Location = new Point(6, 25);
            rdbOrdenarID.Name = "rdbOrdenarID";
            rdbOrdenarID.Size = new Size(127, 25);
            rdbOrdenarID.TabIndex = 0;
            rdbOrdenarID.TabStop = true;
            rdbOrdenarID.Text = "ID Crescente";
            rdbOrdenarID.UseVisualStyleBackColor = true;
            // 
            // lbSaude
            // 
            lbSaude.AutoSize = true;
            lbSaude.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSaude.Location = new Point(418, 318);
            lbSaude.Name = "lbSaude";
            lbSaude.Size = new Size(133, 21);
            lbSaude.TabIndex = 22;
            lbSaude.Text = "Plano de saúde:";
            // 
            // btnRemoveCargo
            // 
            btnRemoveCargo.BackColor = Color.Red;
            btnRemoveCargo.FlatStyle = FlatStyle.Flat;
            btnRemoveCargo.Font = new Font("Segoe UI Emoji", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveCargo.Location = new Point(636, 84);
            btnRemoveCargo.Name = "btnRemoveCargo";
            btnRemoveCargo.Size = new Size(65, 29);
            btnRemoveCargo.TabIndex = 31;
            btnRemoveCargo.Text = "Del";
            btnRemoveCargo.UseVisualStyleBackColor = false;
            btnRemoveCargo.Click += btnRemoveCargo_Click;
            // 
            // lbTransporte
            // 
            lbTransporte.AutoSize = true;
            lbTransporte.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTransporte.Location = new Point(418, 239);
            lbTransporte.Name = "lbTransporte";
            lbTransporte.Size = new Size(140, 21);
            lbTransporte.TabIndex = 18;
            lbTransporte.Text = "Vale-Transporte:";
            // 
            // lbAlimentacao
            // 
            lbAlimentacao.AutoSize = true;
            lbAlimentacao.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbAlimentacao.Location = new Point(418, 278);
            lbAlimentacao.Name = "lbAlimentacao";
            lbAlimentacao.Size = new Size(152, 21);
            lbAlimentacao.TabIndex = 20;
            lbAlimentacao.Text = "Vale-Alimentação:";
            // 
            // lstCargosSelecionados
            // 
            lstCargosSelecionados.FormattingEnabled = true;
            lstCargosSelecionados.ItemHeight = 21;
            lstCargosSelecionados.Location = new Point(707, 83);
            lstCargosSelecionados.Name = "lstCargosSelecionados";
            lstCargosSelecionados.Size = new Size(242, 130);
            lstCargosSelecionados.TabIndex = 30;
            lstCargosSelecionados.Visible = false;
            // 
            // lstSugestoesCargos
            // 
            lstSugestoesCargos.FormattingEnabled = true;
            lstSugestoesCargos.ItemHeight = 21;
            lstSugestoesCargos.Location = new Point(707, 84);
            lstSugestoesCargos.Name = "lstSugestoesCargos";
            lstSugestoesCargos.Size = new Size(242, 67);
            lstSugestoesCargos.TabIndex = 29;
            lstSugestoesCargos.Visible = false;
            // 
            // txtPesquisaCargo
            // 
            txtPesquisaCargo.Location = new Point(707, 51);
            txtPesquisaCargo.MaxLength = 100;
            txtPesquisaCargo.Name = "txtPesquisaCargo";
            txtPesquisaCargo.Size = new Size(242, 29);
            txtPesquisaCargo.TabIndex = 28;
            // 
            // lbAviso
            // 
            lbAviso.AutoSize = true;
            lbAviso.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbAviso.Location = new Point(6, 21);
            lbAviso.Name = "lbAviso";
            lbAviso.Size = new Size(725, 21);
            lbAviso.TabIndex = 27;
            lbAviso.Text = "Obs: Preencha somente os filtros desejados. Sem filtros, serão exibidos todos os cadastros.";
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Red;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFechar.ForeColor = SystemColors.ControlText;
            btnFechar.Location = new Point(833, 380);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(116, 61);
            btnFechar.TabIndex = 26;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.BackColor = SystemColors.HotTrack;
            btnLimparFiltros.Cursor = Cursors.Hand;
            btnLimparFiltros.FlatStyle = FlatStyle.Flat;
            btnLimparFiltros.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimparFiltros.ForeColor = SystemColors.ControlText;
            btnLimparFiltros.Location = new Point(157, 380);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(131, 61);
            btnLimparFiltros.TabIndex = 25;
            btnLimparFiltros.Text = "Limpar filtros";
            btnLimparFiltros.UseVisualStyleBackColor = false;
            btnLimparFiltros.Click += btnLimparFiltros_Click;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.BackColor = Color.Turquoise;
            btnGerarRelatorio.Cursor = Cursors.Hand;
            btnGerarRelatorio.FlatStyle = FlatStyle.Flat;
            btnGerarRelatorio.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGerarRelatorio.Location = new Point(7, 380);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.Size = new Size(144, 61);
            btnGerarRelatorio.TabIndex = 24;
            btnGerarRelatorio.Text = "Gerar relatório";
            btnGerarRelatorio.UseVisualStyleBackColor = false;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
            // 
            // cmbSexo
            // 
            cmbSexo.Cursor = Cursors.Hand;
            cmbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSexo.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbSexo.FormattingEnabled = true;
            cmbSexo.Location = new Point(78, 239);
            cmbSexo.Name = "cmbSexo";
            cmbSexo.Size = new Size(242, 29);
            cmbSexo.TabIndex = 17;
            // 
            // lbSexo
            // 
            lbSexo.AutoSize = true;
            lbSexo.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSexo.Location = new Point(7, 242);
            lbSexo.Name = "lbSexo";
            lbSexo.Size = new Size(51, 21);
            lbSexo.TabIndex = 16;
            lbSexo.Text = "Sexo:";
            // 
            // lbCargo
            // 
            lbCargo.AutoSize = true;
            lbCargo.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbCargo.Location = new Point(633, 57);
            lbCargo.Name = "lbCargo";
            lbCargo.Size = new Size(61, 21);
            lbCargo.TabIndex = 14;
            lbCargo.Text = "Cargo:";
            // 
            // txtSalarioMax
            // 
            txtSalarioMax.Cursor = Cursors.Hand;
            txtSalarioMax.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSalarioMax.Location = new Point(147, 316);
            txtSalarioMax.Name = "txtSalarioMax";
            txtSalarioMax.Size = new Size(174, 29);
            txtSalarioMax.TabIndex = 13;
            // 
            // txtSalarioMin
            // 
            txtSalarioMin.Cursor = Cursors.Hand;
            txtSalarioMin.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSalarioMin.Location = new Point(147, 280);
            txtSalarioMin.Name = "txtSalarioMin";
            txtSalarioMin.Size = new Size(174, 29);
            txtSalarioMin.TabIndex = 12;
            // 
            // lbSalarioMax
            // 
            lbSalarioMax.AutoSize = true;
            lbSalarioMax.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSalarioMax.Location = new Point(5, 319);
            lbSalarioMax.Name = "lbSalarioMax";
            lbSalarioMax.Size = new Size(136, 21);
            lbSalarioMax.TabIndex = 11;
            lbSalarioMax.Text = "Salário máximo:";
            // 
            // lbSalarioMin
            // 
            lbSalarioMin.AutoSize = true;
            lbSalarioMin.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSalarioMin.Location = new Point(7, 280);
            lbSalarioMin.Name = "lbSalarioMin";
            lbSalarioMin.Size = new Size(134, 21);
            lbSalarioMin.TabIndex = 10;
            lbSalarioMin.Text = "Salário mínimo:";
            // 
            // lbDataFinal
            // 
            lbDataFinal.AutoSize = true;
            lbDataFinal.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDataFinal.Location = new Point(5, 190);
            lbDataFinal.Name = "lbDataFinal";
            lbDataFinal.Size = new Size(198, 21);
            lbDataFinal.TabIndex = 9;
            lbDataFinal.Text = "Data de nascimento até:";
            // 
            // dtpNascimentoFinal
            // 
            dtpNascimentoFinal.Checked = false;
            dtpNascimentoFinal.Cursor = Cursors.Hand;
            dtpNascimentoFinal.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpNascimentoFinal.Format = DateTimePickerFormat.Custom;
            dtpNascimentoFinal.Location = new Point(206, 184);
            dtpNascimentoFinal.Name = "dtpNascimentoFinal";
            dtpNascimentoFinal.ShowCheckBox = true;
            dtpNascimentoFinal.Size = new Size(200, 29);
            dtpNascimentoFinal.TabIndex = 8;
            // 
            // lbDataIncial
            // 
            lbDataIncial.AutoSize = true;
            lbDataIncial.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDataIncial.Location = new Point(7, 151);
            lbDataIncial.Name = "lbDataIncial";
            lbDataIncial.Size = new Size(193, 21);
            lbDataIncial.TabIndex = 7;
            lbDataIncial.Text = "Data de nascimento de:";
            // 
            // dtpNascimentoInicial
            // 
            dtpNascimentoInicial.Checked = false;
            dtpNascimentoInicial.Cursor = Cursors.Hand;
            dtpNascimentoInicial.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpNascimentoInicial.Format = DateTimePickerFormat.Custom;
            dtpNascimentoInicial.Location = new Point(206, 145);
            dtpNascimentoInicial.Name = "dtpNascimentoInicial";
            dtpNascimentoInicial.ShowCheckBox = true;
            dtpNascimentoInicial.Size = new Size(200, 29);
            dtpNascimentoInicial.TabIndex = 6;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNome.Location = new Point(7, 102);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(61, 21);
            lbNome.TabIndex = 5;
            lbNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Cursor = Cursors.Hand;
            txtNome.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNome.Location = new Point(96, 99);
            txtNome.MaxLength = 150;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(462, 29);
            txtNome.TabIndex = 4;
            txtNome.TextAlign = HorizontalAlignment.Right;
            // 
            // lbIDFinal
            // 
            lbIDFinal.AutoSize = true;
            lbIDFinal.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbIDFinal.Location = new Point(331, 57);
            lbIDFinal.Name = "lbIDFinal";
            lbIDFinal.Size = new Size(74, 21);
            lbIDFinal.TabIndex = 3;
            lbIDFinal.Text = "ID Final:";
            // 
            // txtIdFinal
            // 
            txtIdFinal.Cursor = Cursors.Hand;
            txtIdFinal.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtIdFinal.Location = new Point(411, 53);
            txtIdFinal.MaxLength = 7;
            txtIdFinal.Name = "txtIdFinal";
            txtIdFinal.Size = new Size(147, 29);
            txtIdFinal.TabIndex = 2;
            // 
            // lbIDinicial
            // 
            lbIDinicial.AutoSize = true;
            lbIDinicial.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbIDinicial.Location = new Point(7, 57);
            lbIDinicial.Name = "lbIDinicial";
            lbIDinicial.Size = new Size(83, 21);
            lbIDinicial.TabIndex = 1;
            lbIDinicial.Text = "ID Inicial:";
            // 
            // txtIdInicial
            // 
            txtIdInicial.Cursor = Cursors.Hand;
            txtIdInicial.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtIdInicial.Location = new Point(96, 51);
            txtIdInicial.MaxLength = 7;
            txtIdInicial.Name = "txtIdInicial";
            txtIdInicial.Size = new Size(154, 29);
            txtIdInicial.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { TspEsc, TspF2, TspF4, tspDel });
            statusStrip1.Location = new Point(0, 464);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(979, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // TspEsc
            // 
            TspEsc.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TspEsc.Name = "TspEsc";
            TspEsc.Size = new Size(142, 21);
            TspEsc.Text = "ESC -  FECHAR / ";
            // 
            // TspF2
            // 
            TspF2.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TspF2.Name = "TspF2";
            TspF2.Size = new Size(213, 21);
            TspF2.Text = "F2 - GERAR RELATÓRIO / ";
            // 
            // TspF4
            // 
            TspF4.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TspF4.Name = "TspF4";
            TspF4.Size = new Size(195, 21);
            TspF4.Text = "F4 - LIMPAR FILTROS / ";
            // 
            // tspDel
            // 
            tspDel.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tspDel.Name = "tspDel";
            tspDel.Size = new Size(345, 21);
            tspDel.Text = "DELETE -  REMOVER NA LISTA DE CARGOS";
            tspDel.Visible = false;
            // 
            // FrmRelatorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 490);
            Controls.Add(statusStrip1);
            Controls.Add(grpFiltros);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRelatorios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Relatórios de cadastros ";
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            grpOrdenacao.ResumeLayout(false);
            grpOrdenacao.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpFiltros;
        private Label lbIDinicial;
        private TextBox txtIdInicial;
        private TextBox txtNome;
        private Label lbIDFinal;
        private TextBox txtIdFinal;
        private Label lbNome;
        private Label lbDataIncial;
        private DateTimePicker dtpNascimentoInicial;
        private Label lbSalarioMax;
        private Label lbSalarioMin;
        private Label lbDataFinal;
        private DateTimePicker dtpNascimentoFinal;
        private Label lbSaude;
        private Label lbAlimentacao;
        private Label lbTransporte;
        private ComboBox cmbSexo;
        private Label lbSexo;
        private Label lbCargo;
        private TextBox txtSalarioMax;
        private TextBox txtSalarioMin;
        private Button btnFechar;
        private Button btnLimparFiltros;
        private Button btnGerarRelatorio;
        private Label lbAviso;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel TspEsc;
        private ToolStripStatusLabel TspF2;
        private ToolStripStatusLabel TspF4;
        private TextBox txtPesquisaCargo;
        private ListBox lstSugestoesCargos;
        private ListBox lstCargosSelecionados;
        private Button btnRemoveCargo;
        private ToolStripStatusLabel tspDel;
        private GroupBox grpOrdenacao;
        private RadioButton rdbOrdenarNascimento;
        private RadioButton rdbOrdenarNome;
        private RadioButton rdbOrdenarID;
        private RadioButton rdbOrdenarSalario;
        private CheckBox chkFiltroTransporte;
        private CheckBox chkFiltroSaude;
        private CheckBox chkFiltroAlimentacao;
        private Label lbTodos;
        private CheckBox chkFiltroTodos;
    }
}