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
            this.SuspendLayout();
            // 
            // btnJogarCarta
            // 
            this.btnJogarCarta.Location = new System.Drawing.Point(209, 146);
            this.btnJogarCarta.Name = "btnJogarCarta";
            this.btnJogarCarta.Size = new System.Drawing.Size(75, 23);
            this.btnJogarCarta.TabIndex = 0;
            this.btnJogarCarta.Text = "Jogar Carta";
            this.btnJogarCarta.UseVisualStyleBackColor = true;
            this.btnJogarCarta.Click += new System.EventHandler(this.btnJogarCarta_Click);
            // 
            // btnApostar
            // 
            this.btnApostar.Location = new System.Drawing.Point(480, 146);
            this.btnApostar.Name = "btnApostar";
            this.btnApostar.Size = new System.Drawing.Size(75, 23);
            this.btnApostar.TabIndex = 1;
            this.btnApostar.Text = "Apostar";
            this.btnApostar.UseVisualStyleBackColor = true;
            // 
            // lstCartas1
            // 
            this.lstCartas1.FormattingEnabled = true;
            this.lstCartas1.Location = new System.Drawing.Point(209, 208);
            this.lstCartas1.Name = "lstCartas1";
            this.lstCartas1.Size = new System.Drawing.Size(120, 95);
            this.lstCartas1.TabIndex = 2;
            // 
            // lstCartas2
            // 
            this.lstCartas2.FormattingEnabled = true;
            this.lstCartas2.Location = new System.Drawing.Point(480, 208);
            this.lstCartas2.Name = "lstCartas2";
            this.lstCartas2.Size = new System.Drawing.Size(120, 95);
            this.lstCartas2.TabIndex = 3;
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstCartas2);
            this.Controls.Add(this.lstCartas1);
            this.Controls.Add(this.btnApostar);
            this.Controls.Add(this.btnJogarCarta);
            this.Name = "MatchForm";
            this.Text = "MatchForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJogarCarta;
        private System.Windows.Forms.Button btnApostar;
        private System.Windows.Forms.ListBox lstCartas1;
        private System.Windows.Forms.ListBox lstCartas2;
    }
}