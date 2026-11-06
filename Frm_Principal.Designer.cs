namespace ProjetoForm
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            Lbl_Nome = new Label();
            Txt_Nome = new TextBox();
            Lbl_Idade = new Label();
            Lbl_Saldo = new Label();
            Txt_Salario = new TextBox();
            Dgv_Cadastros = new DataGridView();
            Cln_Nome = new DataGridViewTextBoxColumn();
            cln_dataNsc = new DataGridViewTextBoxColumn();
            cln_Salario = new DataGridViewTextBoxColumn();
            cln_Sexo = new DataGridViewTextBoxColumn();
            cln_cargo = new DataGridViewTextBoxColumn();
            Cln_Beneficios = new DataGridViewTextBoxColumn();
            Btn_Adicionar = new Button();
            Btn_Remover = new Button();
            List_Cargos = new ListBox();
            Txt_Pesquisa = new TextBox();
            Dtp_dataNsc = new DateTimePicker();
            lb_Cargo = new Label();
            rdb_Masc = new RadioButton();
            rdb_Fem = new RadioButton();
            lb_Sexo = new Label();
            chk_Transporte = new CheckBox();
            chk_Alimentacao = new CheckBox();
            chk_Saude = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)Dgv_Cadastros).BeginInit();
            SuspendLayout();
            // 
            // Lbl_Nome
            // 
            Lbl_Nome.AutoSize = true;
            Lbl_Nome.Location = new Point(26, 9);
            Lbl_Nome.Name = "Lbl_Nome";
            Lbl_Nome.Size = new Size(40, 15);
            Lbl_Nome.TabIndex = 0;
            Lbl_Nome.Text = "Nome";
            // 
            // Txt_Nome
            // 
            Txt_Nome.Location = new Point(26, 27);
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(645, 23);
            Txt_Nome.TabIndex = 1;
            Txt_Nome.KeyPress += Txt_Nome_KeyPress;
            // 
            // Lbl_Idade
            // 
            Lbl_Idade.AutoSize = true;
            Lbl_Idade.Location = new Point(26, 59);
            Lbl_Idade.Name = "Lbl_Idade";
            Lbl_Idade.Size = new Size(114, 15);
            Lbl_Idade.TabIndex = 3;
            Lbl_Idade.Text = "Data de Nascimento";
            // 
            // Lbl_Saldo
            // 
            Lbl_Saldo.AutoSize = true;
            Lbl_Saldo.Location = new Point(397, 59);
            Lbl_Saldo.Name = "Lbl_Saldo";
            Lbl_Saldo.Size = new Size(42, 15);
            Lbl_Saldo.TabIndex = 5;
            Lbl_Saldo.Text = "Salario";
            // 
            // Txt_Salario
            // 
            Txt_Salario.Location = new Point(445, 56);
            Txt_Salario.Name = "Txt_Salario";
            Txt_Salario.Size = new Size(100, 23);
            Txt_Salario.TabIndex = 4;
            Txt_Salario.TextAlign = HorizontalAlignment.Right;
            // 
            // Dgv_Cadastros
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            Dgv_Cadastros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            Dgv_Cadastros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Cadastros.ColumnHeadersVisible = false;
            Dgv_Cadastros.Columns.AddRange(new DataGridViewColumn[] { Cln_Nome, cln_dataNsc, cln_Salario, cln_Sexo, cln_cargo, Cln_Beneficios });
            Dgv_Cadastros.Location = new Point(26, 191);
            Dgv_Cadastros.Name = "Dgv_Cadastros";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            Dgv_Cadastros.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            Dgv_Cadastros.Size = new Size(807, 201);
            Dgv_Cadastros.TabIndex = 13;
            // 
            // Cln_Nome
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Cln_Nome.DefaultCellStyle = dataGridViewCellStyle6;
            Cln_Nome.HeaderText = "Nome";
            Cln_Nome.Name = "Cln_Nome";
            // 
            // cln_dataNsc
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cln_dataNsc.DefaultCellStyle = dataGridViewCellStyle7;
            cln_dataNsc.HeaderText = "Data de Nascimento";
            cln_dataNsc.Name = "cln_dataNsc";
            // 
            // cln_Salario
            // 
            cln_Salario.HeaderText = "Salario";
            cln_Salario.Name = "cln_Salario";
            // 
            // cln_Sexo
            // 
            cln_Sexo.HeaderText = "Sexo";
            cln_Sexo.Name = "cln_Sexo";
            // 
            // cln_cargo
            // 
            cln_cargo.HeaderText = "Cargo";
            cln_cargo.Name = "cln_cargo";
            // 
            // Cln_Beneficios
            // 
            Cln_Beneficios.HeaderText = "Benefícios";
            Cln_Beneficios.Name = "Cln_Beneficios";
            // 
            // Btn_Adicionar
            // 
            Btn_Adicionar.BackColor = Color.Turquoise;
            Btn_Adicionar.FlatStyle = FlatStyle.Flat;
            Btn_Adicionar.Location = new Point(26, 143);
            Btn_Adicionar.Name = "Btn_Adicionar";
            Btn_Adicionar.Size = new Size(80, 32);
            Btn_Adicionar.TabIndex = 14;
            Btn_Adicionar.Text = "Adicionar";
            Btn_Adicionar.UseVisualStyleBackColor = false;
            Btn_Adicionar.Click += Btn_Adicionar_Click;
            // 
            // Btn_Remover
            // 
            Btn_Remover.BackColor = Color.Red;
            Btn_Remover.FlatStyle = FlatStyle.Flat;
            Btn_Remover.Location = new Point(112, 143);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.Size = new Size(80, 32);
            Btn_Remover.TabIndex = 15;
            Btn_Remover.Text = "Remover";
            Btn_Remover.UseVisualStyleBackColor = false;
            // 
            // List_Cargos
            // 
            List_Cargos.FormattingEnabled = true;
            List_Cargos.ItemHeight = 15;
            List_Cargos.Location = new Point(688, 62);
            List_Cargos.Name = "List_Cargos";
            List_Cargos.Size = new Size(145, 64);
            List_Cargos.TabIndex = 16;
            List_Cargos.KeyDown += List_Cargos_KeyDown;
            // 
            // Txt_Pesquisa
            // 
            Txt_Pesquisa.Location = new Point(688, 33);
            Txt_Pesquisa.Name = "Txt_Pesquisa";
            Txt_Pesquisa.Size = new Size(145, 23);
            Txt_Pesquisa.TabIndex = 17;
            // 
            // Dtp_dataNsc
            // 
            Dtp_dataNsc.Format = DateTimePickerFormat.Short;
            Dtp_dataNsc.Location = new Point(146, 56);
            Dtp_dataNsc.Name = "Dtp_dataNsc";
            Dtp_dataNsc.Size = new Size(238, 23);
            Dtp_dataNsc.TabIndex = 18;
            // 
            // lb_Cargo
            // 
            lb_Cargo.AutoSize = true;
            lb_Cargo.Location = new Point(688, 9);
            lb_Cargo.Name = "lb_Cargo";
            lb_Cargo.Size = new Size(39, 15);
            lb_Cargo.TabIndex = 19;
            lb_Cargo.Text = "Cargo";
            // 
            // rdb_Masc
            // 
            rdb_Masc.AutoSize = true;
            rdb_Masc.Location = new Point(26, 106);
            rdb_Masc.Name = "rdb_Masc";
            rdb_Masc.Size = new Size(80, 19);
            rdb_Masc.TabIndex = 20;
            rdb_Masc.TabStop = true;
            rdb_Masc.Text = "Masculino";
            rdb_Masc.UseVisualStyleBackColor = true;
            // 
            // rdb_Fem
            // 
            rdb_Fem.AutoSize = true;
            rdb_Fem.Location = new Point(117, 106);
            rdb_Fem.Name = "rdb_Fem";
            rdb_Fem.Size = new Size(75, 19);
            rdb_Fem.TabIndex = 21;
            rdb_Fem.TabStop = true;
            rdb_Fem.Text = "Feminino";
            rdb_Fem.UseVisualStyleBackColor = true;
            // 
            // lb_Sexo
            // 
            lb_Sexo.AutoSize = true;
            lb_Sexo.Location = new Point(26, 88);
            lb_Sexo.Name = "lb_Sexo";
            lb_Sexo.Size = new Size(31, 15);
            lb_Sexo.TabIndex = 22;
            lb_Sexo.Text = "Sexo";
            // 
            // chk_Transporte
            // 
            chk_Transporte.AutoSize = true;
            chk_Transporte.Location = new Point(278, 106);
            chk_Transporte.Name = "chk_Transporte";
            chk_Transporte.Size = new Size(106, 19);
            chk_Transporte.TabIndex = 23;
            chk_Transporte.Text = "Vale Transporte";
            chk_Transporte.UseVisualStyleBackColor = true;
            // 
            // chk_Alimentacao
            // 
            chk_Alimentacao.AutoSize = true;
            chk_Alimentacao.Location = new Point(397, 106);
            chk_Alimentacao.Name = "chk_Alimentacao";
            chk_Alimentacao.Size = new Size(115, 19);
            chk_Alimentacao.TabIndex = 24;
            chk_Alimentacao.Text = "Vale alimentação";
            chk_Alimentacao.UseVisualStyleBackColor = true;
            // 
            // chk_Saude
            // 
            chk_Saude.AutoSize = true;
            chk_Saude.Location = new Point(528, 106);
            chk_Saude.Name = "chk_Saude";
            chk_Saude.Size = new Size(107, 19);
            chk_Saude.TabIndex = 25;
            chk_Saude.Text = "Plano de Saúde";
            chk_Saude.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(877, 522);
            Controls.Add(chk_Saude);
            Controls.Add(chk_Alimentacao);
            Controls.Add(chk_Transporte);
            Controls.Add(lb_Sexo);
            Controls.Add(rdb_Fem);
            Controls.Add(rdb_Masc);
            Controls.Add(lb_Cargo);
            Controls.Add(Dtp_dataNsc);
            Controls.Add(Txt_Pesquisa);
            Controls.Add(List_Cargos);
            Controls.Add(Btn_Remover);
            Controls.Add(Btn_Adicionar);
            Controls.Add(Lbl_Saldo);
            Controls.Add(Txt_Salario);
            Controls.Add(Lbl_Idade);
            Controls.Add(Txt_Nome);
            Controls.Add(Lbl_Nome);
            Controls.Add(Dgv_Cadastros);
            Name = "FormPrincipal";
            Text = "Formulário de Cadastro";
            ((System.ComponentModel.ISupportInitialize)Dgv_Cadastros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_Nome;
        private TextBox Txt_Nome;
        private TextBox Txt_Idade;
        private Label Lbl_Idade;
        private Label Lbl_Saldo;
        private TextBox Txt_Salario;
        private DataGridView Dgv_Cadastros;
        private Button Btn_Adicionar;
        private Button Btn_Remover;
        private ListBox List_Cargos;
        private TextBox Txt_Pesquisa;
        private DateTimePicker Dtp_dataNsc;
        private Label lb_Cargo;
        private RadioButton rdb_Masc;
        private RadioButton rdb_Fem;
        private Label lb_Sexo;
        private DataGridViewTextBoxColumn Cln_Nome;
        private DataGridViewTextBoxColumn cln_dataNsc;
        private DataGridViewTextBoxColumn cln_Salario;
        private DataGridViewTextBoxColumn cln_Sexo;
        private DataGridViewTextBoxColumn cln_cargo;
        private DataGridViewTextBoxColumn Cln_Beneficios;
        private CheckBox chk_Transporte;
        private CheckBox chk_Alimentacao;
        private CheckBox chk_Saude;
    }
}
