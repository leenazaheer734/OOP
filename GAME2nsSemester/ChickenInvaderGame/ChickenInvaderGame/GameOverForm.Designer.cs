
namespace ChickenInvaderGame
{
    partial class GameOverForm
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
            this.formlabelmain = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.playAgain_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.exit_BTN = new Guna.UI2.WinForms.Guna2Button();
            this.wonlabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // formlabelmain
            // 
            this.formlabelmain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.formlabelmain.BackColor = System.Drawing.Color.Black;
            this.formlabelmain.Font = new System.Drawing.Font("Poor Richard", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlabelmain.ForeColor = System.Drawing.Color.DarkRed;
            this.formlabelmain.Location = new System.Drawing.Point(211, 109);
            this.formlabelmain.Name = "formlabelmain";
            this.formlabelmain.Size = new System.Drawing.Size(293, 75);
            this.formlabelmain.TabIndex = 0;
            this.formlabelmain.Text = "Game Over";
            // 
            // playAgain_BTN
            // 
            this.playAgain_BTN.BackColor = System.Drawing.Color.Transparent;
            this.playAgain_BTN.BorderRadius = 9;
            this.playAgain_BTN.BorderThickness = 2;
            this.playAgain_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.playAgain_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.playAgain_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.playAgain_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.playAgain_BTN.FillColor = System.Drawing.Color.SteelBlue;
            this.playAgain_BTN.Font = new System.Drawing.Font("Zilla Slab", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgain_BTN.ForeColor = System.Drawing.Color.White;
            this.playAgain_BTN.Location = new System.Drawing.Point(97, 292);
            this.playAgain_BTN.Name = "playAgain_BTN";
            this.playAgain_BTN.Size = new System.Drawing.Size(164, 47);
            this.playAgain_BTN.TabIndex = 1;
            this.playAgain_BTN.Text = "Play Again";
            this.playAgain_BTN.Click += new System.EventHandler(this.playAgain_BTN_Click);
            // 
            // exit_BTN
            // 
            this.exit_BTN.BackColor = System.Drawing.Color.Transparent;
            this.exit_BTN.BorderRadius = 9;
            this.exit_BTN.BorderThickness = 2;
            this.exit_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exit_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exit_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exit_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exit_BTN.FillColor = System.Drawing.Color.SteelBlue;
            this.exit_BTN.Font = new System.Drawing.Font("Zilla Slab", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_BTN.ForeColor = System.Drawing.Color.White;
            this.exit_BTN.Location = new System.Drawing.Point(479, 292);
            this.exit_BTN.Name = "exit_BTN";
            this.exit_BTN.Size = new System.Drawing.Size(131, 47);
            this.exit_BTN.TabIndex = 2;
            this.exit_BTN.Text = "Exit";
            this.exit_BTN.Click += new System.EventHandler(this.exit_BTN_Click);
            // 
            // wonlabel
            // 
            this.wonlabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.wonlabel.BackColor = System.Drawing.Color.Black;
            this.wonlabel.Font = new System.Drawing.Font("Poor Richard", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wonlabel.ForeColor = System.Drawing.Color.DarkRed;
            this.wonlabel.Location = new System.Drawing.Point(241, 109);
            this.wonlabel.Name = "wonlabel";
            this.wonlabel.Size = new System.Drawing.Size(241, 75);
            this.wonlabel.TabIndex = 3;
            this.wonlabel.Text = "You Won";
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChickenInvaderGame.Properties.Resources.backgroung_Space;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(723, 474);
            this.Controls.Add(this.wonlabel);
            this.Controls.Add(this.exit_BTN);
            this.Controls.Add(this.playAgain_BTN);
            this.Controls.Add(this.formlabelmain);
            this.Name = "GameOverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOverForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel formlabelmain;
        private Guna.UI2.WinForms.Guna2Button playAgain_BTN;
        private Guna.UI2.WinForms.Guna2Button exit_BTN;
        private Guna.UI2.WinForms.Guna2HtmlLabel wonlabel;
    }
}