
namespace bankGUI
{
    partial class ManageloanForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.clientsGV = new System.Windows.Forms.DataGridView();
            this.money_lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.accnumberTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.nameTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.approveBTN = new Guna.UI2.WinForms.Guna2Button();
            this.rejectBTN = new Guna.UI2.WinForms.Guna2Button();
            this.ApproveCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RejectCol = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.clientsGV)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(192, 20);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(274, 32);
            this.guna2HtmlLabel1.TabIndex = 12;
            this.guna2HtmlLabel1.Text = "Approve / Reject Loan Requests";
            // 
            // clientsGV
            // 
            this.clientsGV.AllowUserToAddRows = false;
            this.clientsGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientsGV.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.clientsGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApproveCol,
            this.RejectCol});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clientsGV.DefaultCellStyle = dataGridViewCellStyle1;
            this.clientsGV.GridColor = System.Drawing.Color.White;
            this.clientsGV.Location = new System.Drawing.Point(1, 177);
            this.clientsGV.Name = "clientsGV";
            this.clientsGV.RowHeadersWidth = 10;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.clientsGV.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.clientsGV.Size = new System.Drawing.Size(676, 267);
            this.clientsGV.TabIndex = 18;
            this.clientsGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsGV_CellContentClick);
            // 
            // money_lbl
            // 
            this.money_lbl.BackColor = System.Drawing.Color.Transparent;
            this.money_lbl.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money_lbl.ForeColor = System.Drawing.Color.White;
            this.money_lbl.Location = new System.Drawing.Point(41, 84);
            this.money_lbl.Name = "money_lbl";
            this.money_lbl.Size = new System.Drawing.Size(165, 27);
            this.money_lbl.TabIndex = 19;
            this.money_lbl.Text = "Account Number: ";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(373, 87);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(122, 27);
            this.guna2HtmlLabel2.TabIndex = 20;
            this.guna2HtmlLabel2.Text = "Client Name: ";
            // 
            // accnumberTB
            // 
            this.accnumberTB.BackColor = System.Drawing.Color.Transparent;
            this.accnumberTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.accnumberTB.BorderRadius = 7;
            this.accnumberTB.BorderThickness = 3;
            this.accnumberTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.accnumberTB.DefaultText = "";
            this.accnumberTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.accnumberTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.accnumberTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.accnumberTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.accnumberTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.accnumberTB.Font = new System.Drawing.Font("Zilla Slab", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accnumberTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.accnumberTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.accnumberTB.Location = new System.Drawing.Point(221, 83);
            this.accnumberTB.Margin = new System.Windows.Forms.Padding(12);
            this.accnumberTB.Name = "accnumberTB";
            this.accnumberTB.PasswordChar = '\0';
            this.accnumberTB.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.accnumberTB.PlaceholderText = "";
            this.accnumberTB.SelectedText = "";
            this.accnumberTB.Size = new System.Drawing.Size(100, 35);
            this.accnumberTB.TabIndex = 21;
            // 
            // nameTB
            // 
            this.nameTB.BackColor = System.Drawing.Color.Transparent;
            this.nameTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.nameTB.BorderRadius = 7;
            this.nameTB.BorderThickness = 3;
            this.nameTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nameTB.DefaultText = "";
            this.nameTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nameTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nameTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameTB.Font = new System.Drawing.Font("Zilla Slab", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.nameTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameTB.Location = new System.Drawing.Point(499, 83);
            this.nameTB.Margin = new System.Windows.Forms.Padding(12);
            this.nameTB.Name = "nameTB";
            this.nameTB.PasswordChar = '\0';
            this.nameTB.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.nameTB.PlaceholderText = "";
            this.nameTB.SelectedText = "";
            this.nameTB.Size = new System.Drawing.Size(139, 35);
            this.nameTB.TabIndex = 22;
            // 
            // approveBTN
            // 
            this.approveBTN.BorderColor = System.Drawing.Color.White;
            this.approveBTN.BorderRadius = 4;
            this.approveBTN.BorderThickness = 2;
            this.approveBTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.approveBTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.approveBTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.approveBTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.approveBTN.FillColor = System.Drawing.Color.DarkSlateGray;
            this.approveBTN.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveBTN.ForeColor = System.Drawing.Color.White;
            this.approveBTN.Location = new System.Drawing.Point(542, 142);
            this.approveBTN.Name = "approveBTN";
            this.approveBTN.Size = new System.Drawing.Size(107, 29);
            this.approveBTN.TabIndex = 23;
            this.approveBTN.Text = "Approve";
            this.approveBTN.Click += new System.EventHandler(this.approveBTN_Click);
            // 
            // rejectBTN
            // 
            this.rejectBTN.BorderColor = System.Drawing.Color.White;
            this.rejectBTN.BorderRadius = 4;
            this.rejectBTN.BorderThickness = 2;
            this.rejectBTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.rejectBTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.rejectBTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.rejectBTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.rejectBTN.FillColor = System.Drawing.Color.Crimson;
            this.rejectBTN.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rejectBTN.ForeColor = System.Drawing.Color.White;
            this.rejectBTN.Location = new System.Drawing.Point(416, 142);
            this.rejectBTN.Name = "rejectBTN";
            this.rejectBTN.Size = new System.Drawing.Size(107, 29);
            this.rejectBTN.TabIndex = 24;
            this.rejectBTN.Text = "Reject";
            this.rejectBTN.Click += new System.EventHandler(this.rejectBTN_Click);
            // 
            // ApproveCol
            // 
            this.ApproveCol.HeaderText = "Approve";
            this.ApproveCol.Name = "ApproveCol";
            this.ApproveCol.Text = "Approve";
            this.ApproveCol.UseColumnTextForButtonValue = true;
            // 
            // RejectCol
            // 
            this.RejectCol.HeaderText = "Reject";
            this.RejectCol.Name = "RejectCol";
            this.RejectCol.Text = "Reject";
            this.RejectCol.UseColumnTextForButtonValue = true;
            // 
            // ManageloanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.Controls.Add(this.rejectBTN);
            this.Controls.Add(this.approveBTN);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.accnumberTB);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.money_lbl);
            this.Controls.Add(this.clientsGV);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "ManageloanForm";
            this.Size = new System.Drawing.Size(676, 444);
            this.Load += new System.EventHandler(this.ManageloanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.DataGridView clientsGV;
        private Guna.UI2.WinForms.Guna2HtmlLabel money_lbl;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox accnumberTB;
        private Guna.UI2.WinForms.Guna2TextBox nameTB;
        private Guna.UI2.WinForms.Guna2Button approveBTN;
        private Guna.UI2.WinForms.Guna2Button rejectBTN;
        private System.Windows.Forms.DataGridViewButtonColumn ApproveCol;
        private System.Windows.Forms.DataGridViewButtonColumn RejectCol;
    }
}
