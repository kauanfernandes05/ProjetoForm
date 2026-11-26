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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            lblPesquisa = new Label();
            txtFiltroNome = new TextBox();
            dgvCadastrados = new DataGridView();
            btnNovo = new Button();
            btnEditar = new Button();
            btnRemover = new Button();
            btnFechar = new Button();
            stsMenu = new StatusStrip();
            TspEsc = new ToolStripStatusLabel();
            TspF2 = new ToolStripStatusLabel();
            TspF3 = new ToolStripStatusLabel();
            TspF4 = new ToolStripStatusLabel();
            TspF5 = new ToolStripStatusLabel();
            TspDelete = new ToolStripStatusLabel();
            lbID = new Label();
            txtFiltroID = new TextBox();
            lbPesquisar = new Label();
            btnPesquisar = new Button();
            imageList2 = new ImageList(components);
            imageList1 = new ImageList(components);
            lbCargo = new Label();
            txtFiltroCargo = new TextBox();
            lstFiltroCargos = new ListBox();
            lblCarregando = new Label();
            btnRelatorios = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCadastrados).BeginInit();
            stsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // lblPesquisa
            // 
            lblPesquisa.AutoSize = true;
            lblPesquisa.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPesquisa.Location = new Point(9, 58);
            lblPesquisa.Name = "lblPesquisa";
            lblPesquisa.Size = new Size(181, 21);
            lblPesquisa.TabIndex = 0;
            lblPesquisa.Text = "Pesquisar por nome : ";
            // 
            // txtFiltroNome
            // 
            txtFiltroNome.Cursor = Cursors.Hand;
            txtFiltroNome.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFiltroNome.Location = new Point(203, 55);
            txtFiltroNome.MaxLength = 70;
            txtFiltroNome.Name = "txtFiltroNome";
            txtFiltroNome.Size = new Size(526, 29);
            txtFiltroNome.TabIndex = 1;
            txtFiltroNome.KeyPress += txtFiltroNome_KeyPress;
            // 
            // dgvCadastrados
            // 
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvCadastrados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCadastrados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCadastrados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCadastrados.Cursor = Cursors.Hand;
            dgvCadastrados.Location = new Point(12, 203);
            dgvCadastrados.Name = "dgvCadastrados";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCadastrados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCadastrados.RowHeadersVisible = false;
            dgvCadastrados.Size = new Size(808, 239);
            dgvCadastrados.TabIndex = 2;
            dgvCadastrados.TabStop = false;
            dgvCadastrados.CellDoubleClick += dgvCadastrados_CellDoubleClick;
            // 
            // btnNovo
            // 
            btnNovo.BackColor = Color.DarkTurquoise;
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNovo.Location = new Point(12, 447);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(126, 49);
            btnNovo.TabIndex = 4;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = SystemColors.ControlDark;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(144, 447);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(120, 49);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnRemover
            // 
            btnRemover.BackColor = Color.DarkRed;
            btnRemover.Cursor = Cursors.Hand;
            btnRemover.FlatAppearance.BorderColor = Color.Black;
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemover.ForeColor = SystemColors.Control;
            btnRemover.Location = new Point(270, 447);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(105, 49);
            btnRemover.TabIndex = 6;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Red;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFechar.ForeColor = Color.Black;
            btnFechar.Location = new Point(721, 447);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(99, 49);
            btnFechar.TabIndex = 7;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // stsMenu
            // 
            stsMenu.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stsMenu.Items.AddRange(new ToolStripItem[] { TspEsc, TspF2, TspF3, TspF4, TspF5, TspDelete });
            stsMenu.Location = new Point(0, 498);
            stsMenu.Name = "stsMenu";
            stsMenu.Size = new Size(832, 26);
            stsMenu.TabIndex = 7;
            stsMenu.Text = "stsMenu";
            // 
            // TspEsc
            // 
            TspEsc.Name = "TspEsc";
            TspEsc.Size = new Size(132, 21);
            TspEsc.Text = "ESC - FECHAR /";
            // 
            // TspF2
            // 
            TspF2.Name = "TspF2";
            TspF2.Size = new Size(108, 21);
            TspF2.Text = "F2 - NOVO /";
            // 
            // TspF3
            // 
            TspF3.Name = "TspF3";
            TspF3.Size = new Size(115, 21);
            TspF3.Text = "F3 - EDITAR /";
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
            TspF5.Size = new Size(149, 21);
            TspF5.Text = "F5 - RELATÓRIO /";
            // 
            // TspDelete
            // 
            TspDelete.Name = "TspDelete";
            TspDelete.Size = new Size(163, 21);
            TspDelete.Text = "DELETE - REMOVER";
            // 
            // lbID
            // 
            lbID.AutoSize = true;
            lbID.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbID.Location = new Point(8, 15);
            lbID.Name = "lbID";
            lbID.Size = new Size(142, 21);
            lbID.TabIndex = 8;
            lbID.Text = "Pesquise por ID :";
            // 
            // txtFiltroID
            // 
            txtFiltroID.Cursor = Cursors.Hand;
            txtFiltroID.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFiltroID.Location = new Point(203, 12);
            txtFiltroID.MaxLength = 7;
            txtFiltroID.Name = "txtFiltroID";
            txtFiltroID.Size = new Size(83, 29);
            txtFiltroID.TabIndex = 0;
            txtFiltroID.KeyPress += txtFiltroID_KeyPress;
            // 
            // lbPesquisar
            // 
            lbPesquisar.AutoSize = true;
            lbPesquisar.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPesquisar.Location = new Point(8, 150);
            lbPesquisar.Name = "lbPesquisar";
            lbPesquisar.Size = new Size(90, 21);
            lbPesquisar.TabIndex = 10;
            lbPesquisar.Text = "Pesquisar:";
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = SystemColors.ControlLight;
            btnPesquisar.Cursor = Cursors.Hand;
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPesquisar.ForeColor = SystemColors.ActiveCaptionText;
            btnPesquisar.ImageIndex = 0;
            btnPesquisar.ImageList = imageList2;
            btnPesquisar.Location = new Point(12, 174);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 3;
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            btnPesquisar.KeyDown += btnPesquisar_KeyDown;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "lupa.png");
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // lbCargo
            // 
            lbCargo.AutoSize = true;
            lbCargo.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbCargo.Location = new Point(9, 105);
            lbCargo.Name = "lbCargo";
            lbCargo.Size = new Size(176, 21);
            lbCargo.TabIndex = 12;
            lbCargo.Text = "Pesquisar por cargo :";
            // 
            // txtFiltroCargo
            // 
            txtFiltroCargo.Cursor = Cursors.Hand;
            txtFiltroCargo.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFiltroCargo.Location = new Point(203, 97);
            txtFiltroCargo.MaxLength = 30;
            txtFiltroCargo.Name = "txtFiltroCargo";
            txtFiltroCargo.Size = new Size(280, 29);
            txtFiltroCargo.TabIndex = 2;
            // 
            // lstFiltroCargos
            // 
            lstFiltroCargos.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstFiltroCargos.FormattingEnabled = true;
            lstFiltroCargos.HorizontalScrollbar = true;
            lstFiltroCargos.ItemHeight = 21;
            lstFiltroCargos.Location = new Point(203, 133);
            lstFiltroCargos.Name = "lstFiltroCargos";
            lstFiltroCargos.Size = new Size(280, 46);
            lstFiltroCargos.TabIndex = 13;
            lstFiltroCargos.TabStop = false;
            lstFiltroCargos.Visible = false;
            // 
            // lblCarregando
            // 
            lblCarregando.AutoSize = true;
            lblCarregando.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCarregando.Location = new Point(255, 179);
            lblCarregando.Name = "lblCarregando";
            lblCarregando.Size = new Size(337, 21);
            lblCarregando.TabIndex = 14;
            lblCarregando.Text = "Carregando dados, aguarde um instante...";
            lblCarregando.Visible = false;
            // 
            // btnRelatorios
            // 
            btnRelatorios.Cursor = Cursors.Hand;
            btnRelatorios.FlatStyle = FlatStyle.Flat;
            btnRelatorios.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRelatorios.Location = new Point(381, 447);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Size = new Size(102, 49);
            btnRelatorios.TabIndex = 15;
            btnRelatorios.Text = "Relatórios";
            btnRelatorios.UseVisualStyleBackColor = true;
            btnRelatorios.Click += btnRelatorios_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 524);
            Controls.Add(btnRelatorios);
            Controls.Add(lblCarregando);
            Controls.Add(lstFiltroCargos);
            Controls.Add(txtFiltroCargo);
            Controls.Add(lbCargo);
            Controls.Add(btnPesquisar);
            Controls.Add(lbPesquisar);
            Controls.Add(txtFiltroID);
            Controls.Add(lbID);
            Controls.Add(stsMenu);
            Controls.Add(btnFechar);
            Controls.Add(btnRemover);
            Controls.Add(btnEditar);
            Controls.Add(btnNovo);
            Controls.Add(dgvCadastrados);
            Controls.Add(txtFiltroNome);
            Controls.Add(lblPesquisa);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MinimizeBox = false;
            Name = "FrmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciamento de cadastros";
            KeyDown += FrmMenu_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvCadastrados).EndInit();
            stsMenu.ResumeLayout(false);
            stsMenu.PerformLayout();
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
        private StatusStrip stsMenu;
        private ToolStripStatusLabel TspEsc;
        private ToolStripStatusLabel TspF2;
        private ToolStripStatusLabel TspF3;
        private ToolStripStatusLabel TspF4;
        private Label lbID;
        private TextBox txtFiltroID;
        private Label lbPesquisar;
        private Button btnPesquisar;
        private ImageList imageList1;
        private ImageList imageList2;
        private Label lbCargo;
        private TextBox txtFiltroCargo;
        private ToolStripStatusLabel TspDelete;
        private ListBox lstFiltroCargos;
        private Label lblCarregando;
        private Button btnRelatorios;
        private ToolStripStatusLabel TspF5;
    }
}