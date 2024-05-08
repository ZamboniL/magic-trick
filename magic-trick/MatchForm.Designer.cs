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
            this.lblTurno = new System.Windows.Forms.Label();
            this.gpbAposta = new System.Windows.Forms.GroupBox();
            this.gpbJogada = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.tmrJogador = new System.Windows.Forms.Timer(this.components);
            this.btnIniciarTimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTurno
            // 
            this.lblTurno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.Location = new System.Drawing.Point(12, 9);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(225, 115);
            this.lblTurno.TabIndex = 0;
            this.lblTurno.Text = "Turno:";
            // 
            // gpbAposta
            // 
            this.gpbAposta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gpbAposta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbAposta.Location = new System.Drawing.Point(632, 330);
            this.gpbAposta.Name = "gpbAposta";
            this.gpbAposta.Size = new System.Drawing.Size(60, 90);
            this.gpbAposta.TabIndex = 12;
            this.gpbAposta.TabStop = false;
            this.gpbAposta.Text = "Aposta";
            // 
            // gpbJogada
            // 
            this.gpbJogada.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gpbJogada.Location = new System.Drawing.Point(350, 330);
            this.gpbJogada.Name = "gpbJogada";
            this.gpbJogada.Size = new System.Drawing.Size(60, 90);
            this.gpbJogada.TabIndex = 14;
            this.gpbJogada.TabStop = false;
            this.gpbJogada.Text = "Jogada";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 739);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Amsterdã";
            // 
            // lblVersao
            // 
            this.lblVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(902, 739);
            this.lblVersao.Margin = new System.Windows.Forms.Padding(3, 0, 12, 0);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(61, 13);
            this.lblVersao.TabIndex = 11;
            this.lblVersao.Text = "Versão: 1.2";
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrJogador
            // 
            this.tmrJogador.Interval = 5000;
            this.tmrJogador.Tick += new System.EventHandler(this.TmrJogador_Tick);
            // 
            // btnIniciarTimer
            // 
            this.btnIniciarTimer.Location = new System.Drawing.Point(484, 366);
            this.btnIniciarTimer.Name = "btnIniciarTimer";
            this.btnIniciarTimer.Size = new System.Drawing.Size(75, 23);
            this.btnIniciarTimer.TabIndex = 15;
            this.btnIniciarTimer.Text = "Iniciar";
            this.btnIniciarTimer.UseVisualStyleBackColor = true;
            this.btnIniciarTimer.Click += new System.EventHandler(this.BtnIniciarTimer_Click);
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.btnIniciarTimer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.gpbJogada);
            this.Controls.Add(this.gpbAposta);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "MatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MatchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.GroupBox gpbAposta;
        private System.Windows.Forms.GroupBox gpbJogada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Timer tmrJogador;
        private System.Windows.Forms.Button btnIniciarTimer;
    }
}