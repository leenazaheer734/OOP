
namespace SpaceShooter
{
    partial class frmGameEnd
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
            this.rstbutton = new System.Windows.Forms.Button();
            this.endbuton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rstbutton
            // 
            this.rstbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rstbutton.BackColor = System.Drawing.Color.MistyRose;
            this.rstbutton.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstbutton.Location = new System.Drawing.Point(143, 336);
            this.rstbutton.Name = "rstbutton";
            this.rstbutton.Size = new System.Drawing.Size(141, 31);
            this.rstbutton.TabIndex = 0;
            this.rstbutton.Text = "RESTART";
            this.rstbutton.UseVisualStyleBackColor = false;
            this.rstbutton.Click += new System.EventHandler(this.rstbutton_Click);
            // 
            // endbuton
            // 
            this.endbuton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.endbuton.BackColor = System.Drawing.Color.MistyRose;
            this.endbuton.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endbuton.Location = new System.Drawing.Point(430, 335);
            this.endbuton.Name = "endbuton";
            this.endbuton.Size = new System.Drawing.Size(151, 31);
            this.endbuton.TabIndex = 1;
            this.endbuton.Text = "END GAME";
            this.endbuton.UseVisualStyleBackColor = false;
            this.endbuton.Click += new System.EventHandler(this.endbuton_Click);
            // 
            // frmGameEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 389);
            this.Controls.Add(this.endbuton);
            this.Controls.Add(this.rstbutton);
            this.Name = "frmGameEnd";
            this.Text = "frmGameEnd";
            this.Load += new System.EventHandler(this.frmGameEnd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rstbutton;
        private System.Windows.Forms.Button endbuton;
    }
}