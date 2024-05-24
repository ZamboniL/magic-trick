namespace MagicTrick
{
    partial class MatchForm
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
            this.components = new System.ComponentModel.Container();
            this.gpbAposta = new System.Windows.Forms.GroupBox();
            this.gpbJogada = new System.Windows.Forms.GroupBox();
            this.tmrJogador = new System.Windows.Forms.Timer(this.components);
            this.lblVencedor = new System.Windows.Forms.Label();
            this.dgvJogadores = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnIniciarTimer = new System.Windows.Forms.Button();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.btnAdicionarJogador = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReloadTurno = new System.Windows.Forms.Button();
            this.lblAcao = new System.Windows.Forms.Label();
            this.lblRodada = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jogadorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jogadorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbAposta
            // 
            this.gpbAposta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gpbAposta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbAposta.Location = new System.Drawing.Point(551, 355);
            this.gpbAposta.Name = "gpbAposta";
            this.gpbAposta.Size = new System.Drawing.Size(60, 90);
            this.gpbAposta.TabIndex = 12;
            this.gpbAposta.TabStop = false;
            this.gpbAposta.Text = "Aposta";
            // 
            // gpbJogada
            // 
            this.gpbJogada.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gpbJogada.Location = new System.Drawing.Point(391, 355);
            this.gpbJogada.Name = "gpbJogada";
            this.gpbJogada.Size = new System.Drawing.Size(60, 90);
            this.gpbJogada.TabIndex = 14;
            this.gpbJogada.TabStop = false;
            this.gpbJogada.Text = "Jogada";
            // 
            // tmrJogador
            // 
            this.tmrJogador.Interval = 5000;
            this.tmrJogador.Tick += new System.EventHandler(this.TmrJogador_Tick);
            // 
            // lblVencedor
            // 
            this.lblVencedor.AutoSize = true;
            this.lblVencedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVencedor.Location = new System.Drawing.Point(384, 282);
            this.lblVencedor.Name = "lblVencedor";
            this.lblVencedor.Size = new System.Drawing.Size(242, 37);
            this.lblVencedor.TabIndex = 17;
            this.lblVencedor.Text = "Lucas Venceu!";
            this.lblVencedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVencedor.Visible = false;
            // 
            // dgvJogadores
            // 
            this.dgvJogadores.AllowUserToAddRows = false;
            this.dgvJogadores.AllowUserToDeleteRows = false;
            this.dgvJogadores.AllowUserToResizeColumns = false;
            this.dgvJogadores.AllowUserToResizeRows = false;
            this.dgvJogadores.AutoGenerateColumns = false;
            this.dgvJogadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJogadores.ColumnHeadersHeight = 24;
            this.dgvJogadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvJogadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn});
            this.dgvJogadores.DataSource = this.jogadorBindingSource;
            this.dgvJogadores.Location = new System.Drawing.Point(14, 264);
            this.dgvJogadores.MultiSelect = false;
            this.dgvJogadores.Name = "dgvJogadores";
            this.dgvJogadores.ReadOnly = true;
            this.dgvJogadores.RowHeadersVisible = false;
            this.dgvJogadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJogadores.Size = new System.Drawing.Size(188, 114);
            this.dgvJogadores.TabIndex = 18;
            this.dgvJogadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJogadores_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.btnIniciarTimer);
            this.panel1.Controls.Add(this.btnIniciarPartida);
            this.panel1.Controls.Add(this.btnAdicionarJogador);
            this.panel1.Controls.Add(this.dgvJogadores);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(968, -27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 804);
            this.panel1.TabIndex = 19;
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = global::MagicTrick.Properties.Resources.reload;
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Location = new System.Drawing.Point(148, 202);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(54, 56);
            this.btnReload.TabIndex = 29;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnIniciarTimer
            // 
            this.btnIniciarTimer.Location = new System.Drawing.Point(14, 446);
            this.btnIniciarTimer.Name = "btnIniciarTimer";
            this.btnIniciarTimer.Size = new System.Drawing.Size(188, 56);
            this.btnIniciarTimer.TabIndex = 28;
            this.btnIniciarTimer.Text = "Iniciar Robo";
            this.btnIniciarTimer.UseVisualStyleBackColor = true;
            this.btnIniciarTimer.Click += new System.EventHandler(this.BtnIniciarTimer_Click);
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Location = new System.Drawing.Point(14, 384);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(188, 56);
            this.btnIniciarPartida.TabIndex = 27;
            this.btnIniciarPartida.Text = "Iniciar Partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // btnAdicionarJogador
            // 
            this.btnAdicionarJogador.Location = new System.Drawing.Point(14, 202);
            this.btnAdicionarJogador.Name = "btnAdicionarJogador";
            this.btnAdicionarJogador.Size = new System.Drawing.Size(128, 56);
            this.btnAdicionarJogador.TabIndex = 20;
            this.btnAdicionarJogador.Text = "Adicionar jogador";
            this.btnAdicionarJogador.UseVisualStyleBackColor = true;
            this.btnAdicionarJogador.Click += new System.EventHandler(this.btnAdicionarJogador_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(64, 116);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(138, 20);
            this.txtSenha.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Nome";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(14, 116);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(44, 20);
            this.txtId.TabIndex = 22;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(14, 165);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(188, 20);
            this.txtNome.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Senha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnReloadTurno);
            this.panel2.Controls.Add(this.lblAcao);
            this.panel2.Controls.Add(this.lblRodada);
            this.panel2.Controls.Add(this.lblTurno);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 64);
            this.panel2.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(389, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "Vez";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(122, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 32;
            this.label8.Text = "Rodada";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(251, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 15);
            this.label7.TabIndex = 31;
            this.label7.Text = "Ação";
            // 
            // btnReloadTurno
            // 
            this.btnReloadTurno.BackgroundImage = global::MagicTrick.Properties.Resources.reload;
            this.btnReloadTurno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReloadTurno.Location = new System.Drawing.Point(13, 4);
            this.btnReloadTurno.Name = "btnReloadTurno";
            this.btnReloadTurno.Size = new System.Drawing.Size(54, 56);
            this.btnReloadTurno.TabIndex = 30;
            this.btnReloadTurno.UseVisualStyleBackColor = true;
            this.btnReloadTurno.Click += new System.EventHandler(this.btnReloadTurno_Click);
            // 
            // lblAcao
            // 
            this.lblAcao.AutoSize = true;
            this.lblAcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcao.Location = new System.Drawing.Point(250, 30);
            this.lblAcao.Name = "lblAcao";
            this.lblAcao.Size = new System.Drawing.Size(0, 25);
            this.lblAcao.TabIndex = 2;
            // 
            // lblRodada
            // 
            this.lblRodada.AutoSize = true;
            this.lblRodada.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRodada.Location = new System.Drawing.Point(121, 30);
            this.lblRodada.Name = "lblRodada";
            this.lblRodada.Size = new System.Drawing.Size(0, 25);
            this.lblRodada.TabIndex = 1;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.Location = new System.Drawing.Point(388, 30);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(0, 25);
            this.lblTurno.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jogadorBindingSource
            // 
            this.jogadorBindingSource.DataSource = typeof(MagicTrick.Jogador);
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 721);
            this.Controls.Add(this.lblVencedor);
            this.Controls.Add(this.gpbJogada);
            this.Controls.Add(this.gpbAposta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 760);
            this.MinimumSize = new System.Drawing.Size(1200, 760);
            this.Name = "MatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MatchForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jogadorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gpbAposta;
        private System.Windows.Forms.GroupBox gpbJogada;
        private System.Windows.Forms.Timer tmrJogador;
        private System.Windows.Forms.Label lblVencedor;
        private System.Windows.Forms.DataGridView dgvJogadores;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource jogadorBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnIniciarTimer;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAdicionarJogador;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRodada;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReloadTurno;
        private System.Windows.Forms.Label lblAcao;
    }
}