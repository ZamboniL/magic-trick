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
            this.btnJogarCarta = new System.Windows.Forms.Button();
            this.btnApostar = new System.Windows.Forms.Button();
            this.lstCartas1 = new System.Windows.Forms.ListBox();
            this.lstCartas2 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCartaJogada = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCartaApostada = new System.Windows.Forms.TextBox();
            this.txtAposta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblJogador = new System.Windows.Forms.Label();
            this.lblOponente = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnJogarCarta
            // 
            this.btnJogarCarta.Location = new System.Drawing.Point(249, 291);
            this.btnJogarCarta.Name = "btnJogarCarta";
            this.btnJogarCarta.Size = new System.Drawing.Size(100, 23);
            this.btnJogarCarta.TabIndex = 0;
            this.btnJogarCarta.Text = "Jogar Carta";
            this.btnJogarCarta.UseVisualStyleBackColor = true;
            this.btnJogarCarta.Click += new System.EventHandler(this.btnJogarCarta_Click);
            // 
            // btnApostar
            // 
            this.btnApostar.Location = new System.Drawing.Point(249, 242);
            this.btnApostar.Name = "btnApostar";
            this.btnApostar.Size = new System.Drawing.Size(100, 23);
            this.btnApostar.TabIndex = 1;
            this.btnApostar.Text = "Apostar";
            this.btnApostar.UseVisualStyleBackColor = true;
            this.btnApostar.Click += new System.EventHandler(this.btnApostar_Click);
            // 
            // lstCartas1
            // 
            this.lstCartas1.FormattingEnabled = true;
            this.lstCartas1.Location = new System.Drawing.Point(27, 143);
            this.lstCartas1.Name = "lstCartas1";
            this.lstCartas1.Size = new System.Drawing.Size(200, 277);
            this.lstCartas1.TabIndex = 2;
            // 
            // lstCartas2
            // 
            this.lstCartas2.FormattingEnabled = true;
            this.lstCartas2.Location = new System.Drawing.Point(368, 143);
            this.lstCartas2.Name = "lstCartas2";
            this.lstCartas2.Size = new System.Drawing.Size(200, 277);
            this.lstCartas2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCartaJogada);
            this.groupBox1.Location = new System.Drawing.Point(27, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 61);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carta Jogada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Valor";
            // 
            // txtCartaJogada
            // 
            this.txtCartaJogada.Location = new System.Drawing.Point(59, 22);
            this.txtCartaJogada.Name = "txtCartaJogada";
            this.txtCartaJogada.Size = new System.Drawing.Size(100, 20);
            this.txtCartaJogada.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCartaApostada);
            this.groupBox2.Location = new System.Drawing.Point(368, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 61);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carta Apostada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Valor";
            // 
            // txtCartaApostada
            // 
            this.txtCartaApostada.Location = new System.Drawing.Point(59, 22);
            this.txtCartaApostada.Name = "txtCartaApostada";
            this.txtCartaApostada.Size = new System.Drawing.Size(100, 20);
            this.txtCartaApostada.TabIndex = 5;
            // 
            // txtAposta
            // 
            this.txtAposta.Location = new System.Drawing.Point(249, 216);
            this.txtAposta.Name = "txtAposta";
            this.txtAposta.Size = new System.Drawing.Size(100, 20);
            this.txtAposta.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Aposta";
            // 
            // lblJogador
            // 
            this.lblJogador.AutoSize = true;
            this.lblJogador.Location = new System.Drawing.Point(27, 124);
            this.lblJogador.Name = "lblJogador";
            this.lblJogador.Size = new System.Drawing.Size(35, 13);
            this.lblJogador.TabIndex = 10;
            this.lblJogador.Text = "label4";
            // 
            // lblOponente
            // 
            this.lblOponente.AutoSize = true;
            this.lblOponente.Location = new System.Drawing.Point(365, 124);
            this.lblOponente.Name = "lblOponente";
            this.lblOponente.Size = new System.Drawing.Size(35, 13);
            this.lblOponente.TabIndex = 11;
            this.lblOponente.Text = "label5";
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 450);
            this.Controls.Add(this.lblOponente);
            this.Controls.Add(this.lblJogador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAposta);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstCartas2);
            this.Controls.Add(this.lstCartas1);
            this.Controls.Add(this.btnApostar);
            this.Controls.Add(this.btnJogarCarta);
            this.Name = "MatchForm";
            this.Text = "MatchForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJogarCarta;
        private System.Windows.Forms.Button btnApostar;
        private System.Windows.Forms.ListBox lstCartas1;
        private System.Windows.Forms.ListBox lstCartas2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCartaJogada;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCartaApostada;
        private System.Windows.Forms.TextBox txtAposta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblJogador;
        private System.Windows.Forms.Label lblOponente;
    }
}