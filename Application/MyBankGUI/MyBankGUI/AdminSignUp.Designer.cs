
namespace MyBankGUI
{
    partial class AdminSignUp
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
            this.topPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.headinglbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.signupBTN = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.contactTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.passwordTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.nameTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.topPanel.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(49)))), ((int)(((byte)(117)))));
            this.topPanel.Controls.Add(this.headinglbl);
            this.topPanel.Location = new System.Drawing.Point(0, 1);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(649, 64);
            this.topPanel.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headinglbl.BackColor = System.Drawing.Color.Transparent;
            this.headinglbl.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.headinglbl.Location = new System.Drawing.Point(161, 11);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(339, 39);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "Bank Management System";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2Panel1.BackgroundImage = global::MyBankGUI.Properties.Resources.adminimage;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Location = new System.Drawing.Point(-9, 65);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(227, 305);
            this.guna2Panel1.TabIndex = 1;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.Color.DimGray;
            this.guna2Panel2.Controls.Add(this.signupBTN);
            this.guna2Panel2.Controls.Add(this.guna2Panel3);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel2.Location = new System.Drawing.Point(216, 65);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(433, 305);
            this.guna2Panel2.TabIndex = 2;
            // 
            // signupBTN
            // 
            this.signupBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.signupBTN.BorderRadius = 6;
            this.signupBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signupBTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.signupBTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.signupBTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.signupBTN.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.signupBTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.signupBTN.FillColor = System.Drawing.Color.CornflowerBlue;
            this.signupBTN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.signupBTN.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupBTN.ForeColor = System.Drawing.Color.White;
            this.signupBTN.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.signupBTN.Location = new System.Drawing.Point(280, 264);
            this.signupBTN.Name = "signupBTN";
            this.signupBTN.Size = new System.Drawing.Size(122, 28);
            this.signupBTN.TabIndex = 2;
            this.signupBTN.Text = "Create Account";
            this.signupBTN.Click += new System.EventHandler(this.signupBTN_Click);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.guna2Panel3.BorderColor = System.Drawing.Color.White;
            this.guna2Panel3.BorderRadius = 2;
            this.guna2Panel3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Panel3.BorderThickness = 4;
            this.guna2Panel3.Controls.Add(this.contactTB);
            this.guna2Panel3.Controls.Add(this.passwordTB);
            this.guna2Panel3.Controls.Add(this.nameTB);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel4);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel3);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel3.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2Panel3.CustomBorderThickness = new System.Windows.Forms.Padding(1);
            this.guna2Panel3.ForeColor = System.Drawing.Color.Black;
            this.guna2Panel3.Location = new System.Drawing.Point(35, 49);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(367, 192);
            this.guna2Panel3.TabIndex = 1;
            // 
            // contactTB
            // 
            this.contactTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.contactTB.DefaultText = "";
            this.contactTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.contactTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.contactTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.contactTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.contactTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.contactTB.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactTB.ForeColor = System.Drawing.Color.Black;
            this.contactTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.contactTB.Location = new System.Drawing.Point(141, 126);
            this.contactTB.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.contactTB.Name = "contactTB";
            this.contactTB.PasswordChar = '\0';
            this.contactTB.PlaceholderText = "";
            this.contactTB.SelectedText = "";
            this.contactTB.Size = new System.Drawing.Size(200, 28);
            this.contactTB.TabIndex = 6;
            this.contactTB.TextOffset = new System.Drawing.Point(2, 2);
            // 
            // passwordTB
            // 
            this.passwordTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTB.DefaultText = "";
            this.passwordTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passwordTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passwordTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordTB.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTB.ForeColor = System.Drawing.Color.Black;
            this.passwordTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordTB.Location = new System.Drawing.Point(141, 75);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '\0';
            this.passwordTB.PlaceholderText = "";
            this.passwordTB.SelectedText = "";
            this.passwordTB.Size = new System.Drawing.Size(200, 28);
            this.passwordTB.TabIndex = 5;
            this.passwordTB.TextOffset = new System.Drawing.Point(2, 2);
            // 
            // nameTB
            // 
            this.nameTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nameTB.DefaultText = "";
            this.nameTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nameTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nameTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameTB.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTB.ForeColor = System.Drawing.Color.Black;
            this.nameTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameTB.Location = new System.Drawing.Point(141, 26);
            this.nameTB.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.nameTB.Name = "nameTB";
            this.nameTB.PasswordChar = '\0';
            this.nameTB.PlaceholderText = "";
            this.nameTB.SelectedText = "";
            this.nameTB.Size = new System.Drawing.Size(200, 28);
            this.nameTB.TabIndex = 4;
            this.nameTB.TextOffset = new System.Drawing.Point(2, 2);
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(24, 126);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(109, 28);
            this.guna2HtmlLabel4.TabIndex = 3;
            this.guna2HtmlLabel4.Text = "Contact No:";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(40, 75);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(93, 28);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Password:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(71, 26);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(62, 28);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Name:";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.DimGray;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(164, 7);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(131, 30);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Sign Up First";
            // 
            // AdminSignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 369);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.topPanel);
            this.Name = "AdminSignUp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminSignUp";
            this.Load += new System.EventHandler(this.AdminSignUp_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel topPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel headinglbl;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox contactTB;
        private Guna.UI2.WinForms.Guna2TextBox passwordTB;
        private Guna.UI2.WinForms.Guna2TextBox nameTB;
        private Guna.UI2.WinForms.Guna2GradientButton signupBTN;
    }
}