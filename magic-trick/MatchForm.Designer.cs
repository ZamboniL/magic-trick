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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchForm));
            this.gpbAposta = new System.Windows.Forms.GroupBox();
            this.gpbJogada = new System.Windows.Forms.GroupBox();
            this.tmrJogador = new System.Windows.Forms.Timer(this.components);
            this.lblVencedor = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblRodada = new System.Windows.Forms.Label();
            this.lblAcao = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnJogador = new System.Windows.Forms.PictureBox();
            this.btnIniciarPartida = new System.Windows.Forms.PictureBox();
            this.btnIniciarTimer = new System.Windows.Forms.PictureBox();
            this.btnReloadTurno = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnJogador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIniciarPartida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIniciarTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReloadTurno)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbAposta
            // 
            this.gpbAposta.BackColor = System.Drawing.Color.Transparent;
            this.gpbAposta.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbAposta.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.gpbAposta.Location = new System.Drawing.Point(551, 355);
            this.gpbAposta.Name = "gpbAposta";
            this.gpbAposta.Size = new System.Drawing.Size(60, 90);
            this.gpbAposta.TabIndex = 12;
            this.gpbAposta.TabStop = false;
            this.gpbAposta.Text = "Aposta";
            // 
            // gpbJogada
            // 
            this.gpbJogada.BackColor = System.Drawing.Color.Transparent;
            this.gpbJogada.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbJogada.ForeColor = System.Drawing.SystemColors.ActiveBorder;
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
            this.lblVencedor.BackColor = System.Drawing.Color.Transparent;
            this.lblVencedor.Font = new System.Drawing.Font("Yu Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVencedor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblVencedor.Location = new System.Drawing.Point(384, 282);
            this.lblVencedor.Name = "lblVencedor";
            this.lblVencedor.Size = new System.Drawing.Size(250, 42);
            this.lblVencedor.TabIndex = 17;
            this.lblVencedor.Text = "Lucas Venceu!";
            this.lblVencedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVencedor.Visible = false;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTurno.Location = new System.Drawing.Point(388, 30);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(0, 25);
            this.lblTurno.TabIndex = 0;
            // 
            // lblRodada
            // 
            this.lblRodada.AutoSize = true;
            this.lblRodada.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRodada.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRodada.Location = new System.Drawing.Point(121, 30);
            this.lblRodada.Name = "lblRodada";
            this.lblRodada.Size = new System.Drawing.Size(0, 25);
            this.lblRodada.TabIndex = 1;
            // 
            // lblAcao
            // 
            this.lblAcao.AutoSize = true;
            this.lblAcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcao.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAcao.Location = new System.Drawing.Point(250, 30);
            this.lblAcao.Name = "lblAcao";
            this.lblAcao.Size = new System.Drawing.Size(0, 25);
            this.lblAcao.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(251, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Ação";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(122, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "Rodada";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(389, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "Vez";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.panel2.Controls.Add(this.btnJogador);
            this.panel2.Controls.Add(this.btnIniciarPartida);
            this.panel2.Controls.Add(this.btnIniciarTimer);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblAcao);
            this.panel2.Controls.Add(this.lblRodada);
            this.panel2.Controls.Add(this.lblTurno);
            this.panel2.Controls.Add(this.btnReloadTurno);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 70);
            this.panel2.TabIndex = 30;
            // 
            // btnJogador
            // 
            this.btnJogador.BackColor = System.Drawing.Color.Transparent;
            this.btnJogador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogador.Image = global::MagicTrick.Properties.Resources.person_;
            this.btnJogador.Location = new System.Drawing.Point(890, -15);
            this.btnJogador.Name = "btnJogador";
            this.btnJogador.Size = new System.Drawing.Size(113, 100);
            this.btnJogador.TabIndex = 35;
            this.btnJogador.TabStop = false;
            this.btnJogador.Click += new System.EventHandler(this.btnJogador_Click);
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.BackColor = System.Drawing.Color.Transparent;
            this.btnIniciarPartida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnIniciarPartida.Image = global::MagicTrick.Properties.Resources.iniciar_partida;
            this.btnIniciarPartida.Location = new System.Drawing.Point(478, -48);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(215, 136);
            this.btnIniciarPartida.TabIndex = 31;
            this.btnIniciarPartida.TabStop = false;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // btnIniciarTimer
            // 
            this.btnIniciarTimer.BackColor = System.Drawing.Color.Transparent;
            this.btnIniciarTimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnIniciarTimer.Image = global::MagicTrick.Properties.Resources.iniciar_robo;
            this.btnIniciarTimer.Location = new System.Drawing.Point(672, -48);
            this.btnIniciarTimer.Name = "btnIniciarTimer";
            this.btnIniciarTimer.Size = new System.Drawing.Size(215, 136);
            this.btnIniciarTimer.TabIndex = 32;
            this.btnIniciarTimer.TabStop = false;
            this.btnIniciarTimer.Click += new System.EventHandler(this.BtnIniciarTimer_Click);
            // 
            // btnReloadTurno
            // 
            this.btnReloadTurno.BackColor = System.Drawing.Color.Transparent;
            this.btnReloadTurno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReloadTurno.Image = global::MagicTrick.Properties.Resources.reload_;
            this.btnReloadTurno.Location = new System.Drawing.Point(-17, -15);
            this.btnReloadTurno.Name = "btnReloadTurno";
            this.btnReloadTurno.Size = new System.Drawing.Size(113, 100);
            this.btnReloadTurno.TabIndex = 34;
            this.btnReloadTurno.TabStop = false;
            this.btnReloadTurno.Click += new System.EventHandler(this.btnReloadTurno_Click);
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MagicTrick.Properties.Resources.bg_neon;
            this.ClientSize = new System.Drawing.Size(984, 721);
            this.Controls.Add(this.lblVencedor);
            this.Controls.Add(this.gpbJogada);
            this.Controls.Add(this.gpbAposta);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 760);
            this.MinimumSize = new System.Drawing.Size(1000, 760);
            this.Name = "MatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partida";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnJogador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIniciarPartida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIniciarTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReloadTurno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gpbAposta;
        private System.Windows.Forms.GroupBox gpbJogada;
        private System.Windows.Forms.Timer tmrJogador;
        private System.Windows.Forms.Label lblVencedor;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblRodada;
        private System.Windows.Forms.Label lblAcao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnIniciarPartida;
        private System.Windows.Forms.PictureBox btnIniciarTimer;
        private System.Windows.Forms.PictureBox btnReloadTurno;
        private System.Windows.Forms.PictureBox btnJogador;
    }
}