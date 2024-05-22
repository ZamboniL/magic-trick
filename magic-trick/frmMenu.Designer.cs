namespace MagicTrick
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnEntrar = new System.Windows.Forms.PictureBox();
            this.btnCriar = new System.Windows.Forms.PictureBox();
            this.lblVersao = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnEntrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCriar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.Transparent;
            this.btnEntrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrar.Image")));
            this.btnEntrar.Location = new System.Drawing.Point(389, 191);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(244, 122);
            this.btnEntrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnEntrar.TabIndex = 3;
            this.btnEntrar.TabStop = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnCriar
            // 
            this.btnCriar.BackColor = System.Drawing.Color.Transparent;
            this.btnCriar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCriar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCriar.Image = global::MagicTrick.Properties.Resources.criar;
            this.btnCriar.Location = new System.Drawing.Point(389, 291);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(244, 122);
            this.btnCriar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCriar.TabIndex = 4;
            this.btnCriar.TabStop = false;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersao.AutoSize = true;
            this.lblVersao.BackColor = System.Drawing.Color.Transparent;
            this.lblVersao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVersao.Location = new System.Drawing.Point(12, 403);
            this.lblVersao.Margin = new System.Windows.Forms.Padding(3, 0, 12, 0);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(61, 13);
            this.lblVersao.TabIndex = 5;
            this.lblVersao.Text = "Versão: 1.2";
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(88, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Amsterdã";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MagicTrick.Properties.Resources.Main;
            this.ClientSize = new System.Drawing.Size(624, 425);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.btnCriar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 464);
            this.MinimumSize = new System.Drawing.Size(640, 464);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MagicTrick - Amsterdã";
            ((System.ComponentModel.ISupportInitialize)(this.btnEntrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCriar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox btnEntrar;
        private System.Windows.Forms.PictureBox btnCriar;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Label label5;
    }
}