
namespace bankGUI
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
            this.components = new System.ComponentModel.Container();
            this.form1timer = new System.Windows.Forms.Timer(this.components);
            this.loadingBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.SuspendLayout();
            // 
            // form1timer
            // 
            this.form1timer.Enabled = true;
            this.form1timer.Tick += new System.EventHandler(this.form1timer_Tick);
            // 
            // loadingBar
            // 
            this.loadingBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingBar.Location = new System.Drawing.Point(0, 310);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.ProgressColor = System.Drawing.Color.DarkGray;
            this.loadingBar.ProgressColor2 = System.Drawing.Color.MidnightBlue;
            this.loadingBar.Size = new System.Drawing.Size(574, 11);
            this.loadingBar.TabIndex = 0;
            this.loadingBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::bankGUI.Properties.Resources.firstImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(573, 321);
            this.Controls.Add(this.loadingBar);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leena\'s Bank";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer form1timer;
        private Guna.UI2.WinForms.Guna2ProgressBar loadingBar;
    }
}

