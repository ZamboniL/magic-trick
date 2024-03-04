namespace MagicTrick
{
    partial class Form1
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
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnCreateMatch = new System.Windows.Forms.Button();
            this.txtMatchName = new System.Windows.Forms.TextBox();
            this.txtMatchPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstMatchList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstPlayerList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(718, 428);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(3, 0, 12, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(61, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Versão: 1.2";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCreateMatch
            // 
            this.btnCreateMatch.Location = new System.Drawing.Point(82, 90);
            this.btnCreateMatch.Name = "btnCreateMatch";
            this.btnCreateMatch.Size = new System.Drawing.Size(241, 23);
            this.btnCreateMatch.TabIndex = 1;
            this.btnCreateMatch.Text = "Criar partida";
            this.btnCreateMatch.UseVisualStyleBackColor = true;
            this.btnCreateMatch.Click += new System.EventHandler(this.btnCreateMatch_Click);
            // 
            // txtMatchName
            // 
            this.txtMatchName.Location = new System.Drawing.Point(82, 15);
            this.txtMatchName.Name = "txtMatchName";
            this.txtMatchName.Size = new System.Drawing.Size(241, 20);
            this.txtMatchName.TabIndex = 2;
            // 
            // txtMatchPassword
            // 
            this.txtMatchPassword.Location = new System.Drawing.Point(82, 52);
            this.txtMatchPassword.Name = "txtMatchPassword";
            this.txtMatchPassword.PasswordChar = '*';
            this.txtMatchPassword.Size = new System.Drawing.Size(241, 20);
            this.txtMatchPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha";
            // 
            // lstMatchList
            // 
            this.lstMatchList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMatchList.FormattingEnabled = true;
            this.lstMatchList.Location = new System.Drawing.Point(34, 151);
            this.lstMatchList.Name = "lstMatchList";
            this.lstMatchList.Size = new System.Drawing.Size(289, 264);
            this.lstMatchList.TabIndex = 6;
            this.lstMatchList.SelectedIndexChanged += new System.EventHandler(this.lstMatchList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Partidas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Jogadores";
            // 
            // lstPlayerList
            // 
            this.lstPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPlayerList.FormattingEnabled = true;
            this.lstPlayerList.Location = new System.Drawing.Point(368, 151);
            this.lstPlayerList.Name = "lstPlayerList";
            this.lstPlayerList.Size = new System.Drawing.Size(289, 264);
            this.lstPlayerList.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Beatriz Adeodato, Julia Almeida Leite, Lucas Zamboni, Maria Coelho";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstPlayerList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstMatchList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMatchPassword);
            this.Controls.Add(this.txtMatchName);
            this.Controls.Add(this.btnCreateMatch);
            this.Controls.Add(this.lblVersion);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnCreateMatch;
        private System.Windows.Forms.TextBox txtMatchName;
        private System.Windows.Forms.TextBox txtMatchPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstMatchList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstPlayerList;
        private System.Windows.Forms.Label label5;
    }
}

