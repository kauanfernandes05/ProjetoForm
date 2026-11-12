namespace ProjetoForm
{
    partial class FrmMenu
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
            lblPesquisa = new Label();
            txtFiltroNome = new TextBox();
            dgvCadastrados = new DataGridView();
            btnNovo = new Button();
            btnEditar = new Button();
            btnRemover = new Button();
            btnFechar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCadastrados).BeginInit();
            SuspendLayout();
            // 
            // lblPesquisa
            // 
            lblPesquisa.AutoSize = true;
            lblPesquisa.Location = new Point(27, 9);
            lblPesquisa.Name = "lblPesquisa";
            lblPesquisa.Size = new Size(118, 15);
            lblPesquisa.TabIndex = 0;
            lblPesquisa.Text = "Pesquisar por nome: ";
            // 
            // txtFiltroNome
            // 
            txtFiltroNome.Location = new Point(27, 27);
            txtFiltroNome.MaxLength = 150;
            txtFiltroNome.Name = "txtFiltroNome";
            txtFiltroNome.Size = new Size(739, 23);
            txtFiltroNome.TabIndex = 1;
            // 
            // dgvCadastrados
            // 
            dgvCadastrados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCadastrados.Location = new Point(27, 65);
            dgvCadastrados.Name = "dgvCadastrados";
            dgvCadastrados.Size = new Size(739, 216);
            dgvCadastrados.TabIndex = 2;
            dgvCadastrados.CellDoubleClick += dgvCadastrados_CellDoubleClick;
            // 
            // btnNovo
            // 
            btnNovo.BackColor = Color.DarkTurquoise;
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.Location = new Point(254, 303);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(87, 35);
            btnNovo.TabIndex = 3;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = SystemColors.ControlDark;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Location = new Point(347, 303);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(87, 35);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnRemover
            // 
            btnRemover.BackColor = Color.DarkRed;
            btnRemover.FlatAppearance.BorderColor = Color.Black;
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.ForeColor = SystemColors.Control;
            btnRemover.Location = new Point(441, 303);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(87, 35);
            btnRemover.TabIndex = 5;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Red;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.ForeColor = Color.Black;
            btnFechar.Location = new Point(685, 303);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(81, 35);
            btnFechar.TabIndex = 6;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 369);
            Controls.Add(btnFechar);
            Controls.Add(btnRemover);
            Controls.Add(btnEditar);
            Controls.Add(btnNovo);
            Controls.Add(dgvCadastrados);
            Controls.Add(txtFiltroNome);
            Controls.Add(lblPesquisa);
            Name = "FrmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciamento de cadastros";
            ((System.ComponentModel.ISupportInitialize)dgvCadastrados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPesquisa;
        private TextBox txtFiltroNome;
        private DataGridView dgvCadastrados;
        private Button btnNovo;
        private Button btnEditar;
        private Button btnRemover;
        private Button btnFechar;
    }
}