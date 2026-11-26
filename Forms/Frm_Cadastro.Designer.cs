namespace ProjetoForm
{
    partial class FormCadastro
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
            Lbl_Nome = new Label();
            Txt_Nome = new TextBox();
            Lbl_Idade = new Label();
            Lbl_Saldo = new Label();
            Txt_Salario = new TextBox();
            Btn_Adicionar = new Button();
            List_Cargos = new ListBox();
            Txt_Pesquisa = new TextBox();
            lb_Cargo = new Label();
            rdb_Masc = new RadioButton();
            rdb_Fem = new RadioButton();
            lb_Sexo = new Label();
            chk_Transporte = new CheckBox();
            chk_Alimentacao = new CheckBox();
            chk_Saude = new CheckBox();
            Dtp_dataNsc = new DateTimePicker();
            btnFecharP = new Button();
            stsCadastro = new StatusStrip();
            TspESC = new ToolStripStatusLabel();
            TspF4 = new ToolStripStatusLabel();
            TspF5 = new ToolStripStatusLabel();
            stsCadastro.SuspendLayout();
            SuspendLayout();
            // 
            // Lbl_Nome
            // 
            Lbl_Nome.AutoSize = true;
            Lbl_Nome.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Nome.Location = new Point(12, 5);
            Lbl_Nome.Name = "Lbl_Nome";
            Lbl_Nome.Size = new Size(66, 21);
            Lbl_Nome.TabIndex = 0;
            Lbl_Nome.Text = "Nome :";
            // 
            // Txt_Nome
            // 
            Txt_Nome.Cursor = Cursors.Hand;
            Txt_Nome.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Txt_Nome.Location = new Point(12, 29);
            Txt_Nome.MaxLength = 150;
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(604, 29);
            Txt_Nome.TabIndex = 0;
            Txt_Nome.KeyPress += Txt_NomeKeyPress;
            // 
            // Lbl_Idade
            // 
            Lbl_Idade.AutoSize = true;
            Lbl_Idade.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Idade.Location = new Point(0, 67);
            Lbl_Idade.Name = "Lbl_Idade";
            Lbl_Idade.Size = new Size(177, 21);
            Lbl_Idade.TabIndex = 3;
            Lbl_Idade.Text = "Data de Nascimento :";
            // 
            // Lbl_Saldo
            // 
            Lbl_Saldo.AutoSize = true;
            Lbl_Saldo.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Saldo.Location = new Point(365, 70);
            Lbl_Saldo.Name = "Lbl_Saldo";
            Lbl_Saldo.Size = new Size(74, 21);
            Lbl_Saldo.TabIndex = 5;
            Lbl_Saldo.Text = "Salario :";
            // 
            // Txt_Salario
            // 
            Txt_Salario.Cursor = Cursors.Hand;
            Txt_Salario.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Txt_Salario.Location = new Point(445, 64);
            Txt_Salario.Name = "Txt_Salario";
            Txt_Salario.Size = new Size(171, 29);
            Txt_Salario.TabIndex = 3;
            Txt_Salario.TextAlign = HorizontalAlignment.Right;
            // 
            // Btn_Adicionar
            // 
            Btn_Adicionar.BackColor = Color.Turquoise;
            Btn_Adicionar.Cursor = Cursors.Hand;
            Btn_Adicionar.FlatStyle = FlatStyle.Flat;
            Btn_Adicionar.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Adicionar.Location = new Point(12, 182);
            Btn_Adicionar.Name = "Btn_Adicionar";
            Btn_Adicionar.Size = new Size(126, 49);
            Btn_Adicionar.TabIndex = 9;
            Btn_Adicionar.Text = "Salvar ";
            Btn_Adicionar.UseVisualStyleBackColor = false;
            Btn_Adicionar.Click += Btn_Adicionar_Click;
            // 
            // List_Cargos
            // 
            List_Cargos.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            List_Cargos.FormattingEnabled = true;
            List_Cargos.HorizontalScrollbar = true;
            List_Cargos.ItemHeight = 21;
            List_Cargos.Location = new Point(631, 64);
            List_Cargos.Name = "List_Cargos";
            List_Cargos.Size = new Size(264, 109);
            List_Cargos.TabIndex = 16;
            List_Cargos.KeyDown += List_Cargos_KeyDown;
            // 
            // Txt_Pesquisa
            // 
            Txt_Pesquisa.Cursor = Cursors.Hand;
            Txt_Pesquisa.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Txt_Pesquisa.Location = new Point(631, 29);
            Txt_Pesquisa.Name = "Txt_Pesquisa";
            Txt_Pesquisa.Size = new Size(264, 29);
            Txt_Pesquisa.TabIndex = 1;
            Txt_Pesquisa.TextChanged += Txt_Pesquisa_TextChanged;
            // 
            // lb_Cargo
            // 
            lb_Cargo.AutoSize = true;
            lb_Cargo.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Cargo.Location = new Point(631, 5);
            lb_Cargo.Name = "lb_Cargo";
            lb_Cargo.Size = new Size(66, 21);
            lb_Cargo.TabIndex = 19;
            lb_Cargo.Text = "Cargo :";
            // 
            // rdb_Masc
            // 
            rdb_Masc.AutoSize = true;
            rdb_Masc.Cursor = Cursors.Hand;
            rdb_Masc.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdb_Masc.Location = new Point(12, 120);
            rdb_Masc.Name = "rdb_Masc";
            rdb_Masc.Size = new Size(108, 25);
            rdb_Masc.TabIndex = 4;
            rdb_Masc.TabStop = true;
            rdb_Masc.Text = "Masculino";
            rdb_Masc.UseVisualStyleBackColor = true;
            // 
            // rdb_Fem
            // 
            rdb_Fem.AutoSize = true;
            rdb_Fem.Cursor = Cursors.Hand;
            rdb_Fem.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdb_Fem.Location = new Point(126, 120);
            rdb_Fem.Name = "rdb_Fem";
            rdb_Fem.Size = new Size(101, 25);
            rdb_Fem.TabIndex = 5;
            rdb_Fem.TabStop = true;
            rdb_Fem.Text = "Feminino";
            rdb_Fem.UseVisualStyleBackColor = true;
            // 
            // lb_Sexo
            // 
            lb_Sexo.AutoSize = true;
            lb_Sexo.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Sexo.Location = new Point(12, 96);
            lb_Sexo.Name = "lb_Sexo";
            lb_Sexo.Size = new Size(56, 21);
            lb_Sexo.TabIndex = 22;
            lb_Sexo.Text = "Sexo :";
            // 
            // chk_Transporte
            // 
            chk_Transporte.AutoSize = true;
            chk_Transporte.Cursor = Cursors.Hand;
            chk_Transporte.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chk_Transporte.Location = new Point(294, 121);
            chk_Transporte.Name = "chk_Transporte";
            chk_Transporte.Size = new Size(153, 25);
            chk_Transporte.TabIndex = 6;
            chk_Transporte.Text = "Vale Transporte";
            chk_Transporte.UseVisualStyleBackColor = true;
            // 
            // chk_Alimentacao
            // 
            chk_Alimentacao.AutoSize = true;
            chk_Alimentacao.Cursor = Cursors.Hand;
            chk_Alimentacao.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chk_Alimentacao.Location = new Point(453, 121);
            chk_Alimentacao.Name = "chk_Alimentacao";
            chk_Alimentacao.Size = new Size(163, 25);
            chk_Alimentacao.TabIndex = 7;
            chk_Alimentacao.Text = "Vale alimentação";
            chk_Alimentacao.UseVisualStyleBackColor = true;
            // 
            // chk_Saude
            // 
            chk_Saude.AutoSize = true;
            chk_Saude.Cursor = Cursors.Hand;
            chk_Saude.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chk_Saude.Location = new Point(377, 147);
            chk_Saude.Name = "chk_Saude";
            chk_Saude.Size = new Size(150, 25);
            chk_Saude.TabIndex = 8;
            chk_Saude.Text = "Plano de Saúde";
            chk_Saude.UseVisualStyleBackColor = true;
            // 
            // Dtp_dataNsc
            // 
            Dtp_dataNsc.Cursor = Cursors.Hand;
            Dtp_dataNsc.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Dtp_dataNsc.Format = DateTimePickerFormat.Custom;
            Dtp_dataNsc.Location = new Point(195, 64);
            Dtp_dataNsc.Name = "Dtp_dataNsc";
            Dtp_dataNsc.Size = new Size(135, 29);
            Dtp_dataNsc.TabIndex = 2;
            // 
            // btnFecharP
            // 
            btnFecharP.BackColor = Color.Red;
            btnFecharP.Cursor = Cursors.Hand;
            btnFecharP.FlatStyle = FlatStyle.Flat;
            btnFecharP.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFecharP.Location = new Point(769, 181);
            btnFecharP.Name = "btnFecharP";
            btnFecharP.Size = new Size(126, 49);
            btnFecharP.TabIndex = 30;
            btnFecharP.Text = "Fechar";
            btnFecharP.UseVisualStyleBackColor = false;
            btnFecharP.Click += btnFecharP_Click;
            // 
            // stsCadastro
            // 
            stsCadastro.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stsCadastro.Items.AddRange(new ToolStripItem[] { TspESC, TspF4, TspF5 });
            stsCadastro.Location = new Point(0, 233);
            stsCadastro.Name = "stsCadastro";
            stsCadastro.Size = new Size(907, 26);
            stsCadastro.TabIndex = 31;
            stsCadastro.Text = "stsCadastro";
            // 
            // TspESC
            // 
            TspESC.Name = "TspESC";
            TspESC.Size = new Size(132, 21);
            TspESC.Text = "ESC - FECHAR /";
            // 
            // TspF4
            // 
            TspF4.Name = "TspF4";
            TspF4.Size = new Size(119, 21);
            TspF4.Text = "F4 - LIMPAR /";
            // 
            // TspF5
            // 
            TspF5.Name = "TspF5";
            TspF5.Size = new Size(114, 21);
            TspF5.Text = "F5 - SALVAR ";
            // 
            // FormCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(907, 259);
            Controls.Add(stsCadastro);
            Controls.Add(btnFecharP);
            Controls.Add(Dtp_dataNsc);
            Controls.Add(chk_Saude);
            Controls.Add(chk_Alimentacao);
            Controls.Add(chk_Transporte);
            Controls.Add(lb_Sexo);
            Controls.Add(rdb_Fem);
            Controls.Add(rdb_Masc);
            Controls.Add(lb_Cargo);
            Controls.Add(Txt_Pesquisa);
            Controls.Add(List_Cargos);
            Controls.Add(Btn_Adicionar);
            Controls.Add(Lbl_Saldo);
            Controls.Add(Txt_Salario);
            Controls.Add(Lbl_Idade);
            Controls.Add(Txt_Nome);
            Controls.Add(Lbl_Nome);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulário de Cadastro";
            KeyDown += FormCadastro_KeyDown;
            stsCadastro.ResumeLayout(false);
            stsCadastro.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_Nome;
        private TextBox Txt_Nome;
        private Label Lbl_Idade;
        private Label Lbl_Saldo;
        private TextBox Txt_Salario;
        private Button Btn_Adicionar;
        private ListBox List_Cargos;
        private TextBox Txt_Pesquisa;
        private Label lb_Cargo;
        private RadioButton rdb_Masc;
        private RadioButton rdb_Fem;
        private Label lb_Sexo;
        private CheckBox chk_Transporte;
        private CheckBox chk_Alimentacao;
        private CheckBox chk_Saude;
        private DateTimePicker Dtp_dataNsc;
        private Button btnFecharP;
        private StatusStrip stsCadastro;
        private ToolStripStatusLabel TspESC;
        private ToolStripStatusLabel TspF4;
        private ToolStripStatusLabel TspF5;
    }
}
