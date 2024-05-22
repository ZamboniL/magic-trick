namespace MagicTrick
{
    partial class frmCriacaoPartida
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnCriar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 64);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(152, 20);
            this.txtNome.TabIndex = 0;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(170, 64);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(142, 20);
            this.txtSenha.TabIndex = 1;
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(12, 107);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(300, 45);
            this.btnCriar.TabIndex = 2;
            this.btnCriar.Text = "Criar Partida";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha";
            // 
            // frmCriacaoPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 211);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtNome);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 250);
            this.MinimumSize = new System.Drawing.Size(340, 250);
            this.Name = "frmCriacaoPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Criar partida";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}