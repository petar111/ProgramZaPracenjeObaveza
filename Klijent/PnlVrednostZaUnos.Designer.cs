namespace Klijent
{
    partial class PnlVrednostZaUnos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblVrednost = new System.Windows.Forms.Label();
            this.lblVrednostUpozorenje = new System.Windows.Forms.Label();
            this.txtVrednost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblVrednost
            // 
            this.lblVrednost.AutoSize = true;
            this.lblVrednost.Location = new System.Drawing.Point(5, 7);
            this.lblVrednost.Name = "lblVrednost";
            this.lblVrednost.Size = new System.Drawing.Size(59, 13);
            this.lblVrednost.TabIndex = 0;
            this.lblVrednost.Text = "lblVrednost";
            // 
            // lblVrednostUpozorenje
            // 
            this.lblVrednostUpozorenje.AutoSize = true;
            this.lblVrednostUpozorenje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblVrednostUpozorenje.Location = new System.Drawing.Point(4, 32);
            this.lblVrednostUpozorenje.Name = "lblVrednostUpozorenje";
            this.lblVrednostUpozorenje.Size = new System.Drawing.Size(113, 13);
            this.lblVrednostUpozorenje.TabIndex = 1;
            this.lblVrednostUpozorenje.Text = "lblVrednostUpozorenje";
            // 
            // txtVrednost
            // 
            this.txtVrednost.Location = new System.Drawing.Point(143, 4);
            this.txtVrednost.Name = "txtVrednost";
            this.txtVrednost.Size = new System.Drawing.Size(267, 20);
            this.txtVrednost.TabIndex = 2;
            // 
            // PnlVrednostZaUnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtVrednost);
            this.Controls.Add(this.lblVrednostUpozorenje);
            this.Controls.Add(this.lblVrednost);
            this.Name = "PnlVrednostZaUnos";
            this.Size = new System.Drawing.Size(413, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVrednost;
        private System.Windows.Forms.Label lblVrednostUpozorenje;
        private System.Windows.Forms.TextBox txtVrednost;
    }
}
