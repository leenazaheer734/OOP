
namespace SpaceShooter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timeGameLoop = new System.Windows.Forms.Timer(this.components);
            this.scorelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeGameLoop
            // 
            this.timeGameLoop.Enabled = true;
            this.timeGameLoop.Tick += new System.EventHandler(this.timeGameLoop_Tick);
            // 
            // scorelabel
            // 
            this.scorelabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scorelabel.AutoSize = true;
            this.scorelabel.BackColor = System.Drawing.Color.Transparent;
            this.scorelabel.Font = new System.Drawing.Font("Jokerman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scorelabel.ForeColor = System.Drawing.Color.Green;
            this.scorelabel.Location = new System.Drawing.Point(1, 0);
            this.scorelabel.Name = "scorelabel";
            this.scorelabel.Size = new System.Drawing.Size(101, 35);
            this.scorelabel.TabIndex = 2;
            this.scorelabel.Text = "Score= ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(919, 618);
            this.Controls.Add(this.scorelabel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Score:  0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox playerShip;
        private System.Windows.Forms.Timer timeGameLoop;
        private System.Windows.Forms.Label scorelabel;
    }
}

