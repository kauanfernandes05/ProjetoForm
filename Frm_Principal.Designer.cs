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
            statusStrip1 = new StatusStrip();
            btnFecharP = new Button();
            SuspendLayout();
            // 
            // Lbl_Nome
            // 
            Lbl_Nome.AutoSize = true;
            Lbl_Nome.Location = new Point(12, 5);
            Lbl_Nome.Name = "Lbl_Nome";
            Lbl_Nome.Size = new Size(40, 15);
            Lbl_Nome.TabIndex = 0;
            Lbl_Nome.Text = "Nome";
            // 
            // Txt_Nome
            // 
            Txt_Nome.Location = new Point(12, 23);
            Txt_Nome.MaxLength = 150;
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(645, 23);
            Txt_Nome.TabIndex = 1;
            Txt_Nome.KeyPress += Txt_NomeKeyPress;
            // 
            // Lbl_Idade
            // 
            Lbl_Idade.AutoSize = true;
            Lbl_Idade.Location = new Point(12, 55);
            Lbl_Idade.Name = "Lbl_Idade";
            Lbl_Idade.Size = new Size(114, 15);
            Lbl_Idade.TabIndex = 3;
            Lbl_Idade.Text = "Data de Nascimento";
            // 
            // Lbl_Saldo
            // 
            Lbl_Saldo.AutoSize = true;
            Lbl_Saldo.Location = new Point(456, 58);
            Lbl_Saldo.Name = "Lbl_Saldo";
            Lbl_Saldo.Size = new Size(42, 15);
            Lbl_Saldo.TabIndex = 5;
            Lbl_Saldo.Text = "Salario";
            // 
            // Txt_Salario
            // 
            Txt_Salario.Location = new Point(509, 52);
            Txt_Salario.Name = "Txt_Salario";
            Txt_Salario.Size = new Size(148, 23);
            Txt_Salario.TabIndex = 4;
            Txt_Salario.TextAlign = HorizontalAlignment.Right;
            // 
            // Btn_Adicionar
            // 
            Btn_Adicionar.BackColor = Color.Turquoise;
            Btn_Adicionar.FlatStyle = FlatStyle.Flat;
            Btn_Adicionar.Location = new Point(12, 139);
            Btn_Adicionar.Name = "Btn_Adicionar";
            Btn_Adicionar.Size = new Size(80, 32);
            Btn_Adicionar.TabIndex = 14;
            Btn_Adicionar.Text = "Salvar ";
            Btn_Adicionar.UseVisualStyleBackColor = false;
            Btn_Adicionar.Click += Btn_Adicionar_Click;
            // 
            // List_Cargos
            // 
            List_Cargos.FormattingEnabled = true;
            List_Cargos.ItemHeight = 15;
            List_Cargos.Location = new Point(676, 52);
            List_Cargos.Name = "List_Cargos";
            List_Cargos.Size = new Size(189, 64);
            List_Cargos.TabIndex = 16;
            List_Cargos.KeyDown += List_Cargos_KeyDown;
            // 
            // Txt_Pesquisa
            // 
            Txt_Pesquisa.Location = new Point(676, 23);
            Txt_Pesquisa.Name = "Txt_Pesquisa";
            Txt_Pesquisa.Size = new Size(189, 23);
            Txt_Pesquisa.TabIndex = 17;
            Txt_Pesquisa.TextChanged += Txt_Pesquisa_TextChanged;
            // 
            // lb_Cargo
            // 
            lb_Cargo.AutoSize = true;
            lb_Cargo.Location = new Point(676, 6);
            lb_Cargo.Name = "lb_Cargo";
            lb_Cargo.Size = new Size(39, 15);
            lb_Cargo.TabIndex = 19;
            lb_Cargo.Text = "Cargo";
            // 
            // rdb_Masc
            // 
            rdb_Masc.AutoSize = true;
            rdb_Masc.Location = new Point(12, 102);
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
            rdb_Fem.Location = new Point(103, 102);
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
            lb_Sexo.Location = new Point(12, 84);
            lb_Sexo.Name = "lb_Sexo";
            lb_Sexo.Size = new Size(31, 15);
            lb_Sexo.TabIndex = 22;
            lb_Sexo.Text = "Sexo";
            // 
            // chk_Transporte
            // 
            chk_Transporte.AutoSize = true;
            chk_Transporte.Location = new Point(264, 102);
            chk_Transporte.Name = "chk_Transporte";
            chk_Transporte.Size = new Size(106, 19);
            chk_Transporte.TabIndex = 23;
            chk_Transporte.Text = "Vale Transporte";
            chk_Transporte.UseVisualStyleBackColor = true;
            // 
            // chk_Alimentacao
            // 
            chk_Alimentacao.AutoSize = true;
            chk_Alimentacao.Location = new Point(383, 102);
            chk_Alimentacao.Name = "chk_Alimentacao";
            chk_Alimentacao.Size = new Size(115, 19);
            chk_Alimentacao.TabIndex = 24;
            chk_Alimentacao.Text = "Vale alimentação";
            chk_Alimentacao.UseVisualStyleBackColor = true;
            // 
            // chk_Saude
            // 
            chk_Saude.AutoSize = true;
            chk_Saude.Location = new Point(514, 102);
            chk_Saude.Name = "chk_Saude";
            chk_Saude.Size = new Size(107, 19);
            chk_Saude.TabIndex = 25;
            chk_Saude.Text = "Plano de Saúde";
            chk_Saude.UseVisualStyleBackColor = true;
            // 
            // Dtp_dataNsc
            // 
            Dtp_dataNsc.Format = DateTimePickerFormat.Custom;
            Dtp_dataNsc.Location = new Point(132, 52);
            Dtp_dataNsc.Name = "Dtp_dataNsc";
            Dtp_dataNsc.Size = new Size(200, 23);
            Dtp_dataNsc.TabIndex = 28;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 186);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(877, 22);
            statusStrip1.TabIndex = 29;
            statusStrip1.Text = "statusStrip1";
            // 
            // btnFecharP
            // 
            btnFecharP.BackColor = Color.Red;
            btnFecharP.FlatStyle = FlatStyle.Flat;
            btnFecharP.Location = new Point(98, 139);
            btnFecharP.Name = "btnFecharP";
            btnFecharP.Size = new Size(90, 32);
            btnFecharP.TabIndex = 30;
            btnFecharP.Text = "Fechar";
            btnFecharP.UseVisualStyleBackColor = false;
            btnFecharP.Click += btnFecharP_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(877, 208);
            Controls.Add(btnFecharP);
            Controls.Add(statusStrip1);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulário de Cadastro";
            KeyDown += FormPrincipal_KeyDown;
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
        private StatusStrip statusStrip1;
        private Button btnFecharP;
    }
}
