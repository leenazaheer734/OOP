
namespace bankGUI
{
    partial class welcomeadmin
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
            this.reqloan_lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // reqloan_lbl
            // 
            this.reqloan_lbl.BackColor = System.Drawing.Color.White;
            this.reqloan_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reqloan_lbl.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqloan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.reqloan_lbl.Location = new System.Drawing.Point(304, 27);
            this.reqloan_lbl.Name = "reqloan_lbl";
            this.reqloan_lbl.Size = new System.Drawing.Size(75, 34);
            this.reqloan_lbl.TabIndex = 22;
            this.reqloan_lbl.Text = "Admin";
            // 
            // welcomeadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImage = global::bankGUI.Properties.Resources.image_removebg_preview__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.reqloan_lbl);
            this.DoubleBuffered = true;
            this.Name = "welcomeadmin";
            this.Size = new System.Drawing.Size(676, 444);
            this.Load += new System.EventHandler(this.welcomeadmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel reqloan_lbl;
    }
}
