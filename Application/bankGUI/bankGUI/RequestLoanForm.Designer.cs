
namespace bankGUI
{
    partial class RequestLoanForm
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
            this.reqData_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.item_cb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.P_TB = new Guna.UI2.WinForms.Guna2TextBox();
            this.amountTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.money_lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.item_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.pWorth_TB = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.address_TB = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.goldpanel = new Guna.UI2.WinForms.Guna2Panel();
            this.pGold_TB = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gWeight_TB = new Guna.UI2.WinForms.Guna2TextBox();
            this.gValue_TB = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.reqData_panel.SuspendLayout();
            this.item_panel.SuspendLayout();
            this.goldpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // reqloan_lbl
            // 
            this.reqloan_lbl.BackColor = System.Drawing.Color.White;
            this.reqloan_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reqloan_lbl.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqloan_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.reqloan_lbl.Location = new System.Drawing.Point(267, 15);
            this.reqloan_lbl.Name = "reqloan_lbl";
            this.reqloan_lbl.Size = new System.Drawing.Size(174, 34);
            this.reqloan_lbl.TabIndex = 21;
            this.reqloan_lbl.Text = "Request For Loan";
            // 
            // reqData_panel
            // 
            this.reqData_panel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.reqData_panel.BorderRadius = 20;
            this.reqData_panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.reqData_panel.BorderThickness = 3;
            this.reqData_panel.Controls.Add(this.item_cb);
            this.reqData_panel.Controls.Add(this.P_TB);
            this.reqData_panel.Controls.Add(this.amountTB);
            this.reqData_panel.Controls.Add(this.guna2HtmlLabel2);
            this.reqData_panel.Controls.Add(this.guna2HtmlLabel1);
            this.reqData_panel.Controls.Add(this.money_lbl);
            this.reqData_panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.reqData_panel.Location = new System.Drawing.Point(26, 63);
            this.reqData_panel.Name = "reqData_panel";
            this.reqData_panel.Size = new System.Drawing.Size(642, 129);
            this.reqData_panel.TabIndex = 22;
            // 
            // item_cb
            // 
            this.item_cb.BackColor = System.Drawing.Color.Transparent;
            this.item_cb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.item_cb.BorderRadius = 10;
            this.item_cb.BorderThickness = 3;
            this.item_cb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.item_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item_cb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.item_cb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.item_cb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.item_cb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.item_cb.ItemHeight = 30;
            this.item_cb.Items.AddRange(new object[] {
            "Gold",
            "Property"});
            this.item_cb.Location = new System.Drawing.Point(179, 75);
            this.item_cb.Name = "item_cb";
            this.item_cb.Size = new System.Drawing.Size(137, 36);
            this.item_cb.TabIndex = 22;
            // 
            // P_TB
            // 
            this.P_TB.BackColor = System.Drawing.Color.Transparent;
            this.P_TB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.P_TB.BorderRadius = 7;
            this.P_TB.BorderThickness = 3;
            this.P_TB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.P_TB.DefaultText = "";
            this.P_TB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.P_TB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.P_TB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.P_TB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.P_TB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.P_TB.Font = new System.Drawing.Font("Zilla Slab", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.P_TB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.P_TB.Location = new System.Drawing.Point(484, 23);
            this.P_TB.Margin = new System.Windows.Forms.Padding(12);
            this.P_TB.Name = "P_TB";
            this.P_TB.PasswordChar = '\0';
            this.P_TB.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.P_TB.PlaceholderText = "";
            this.P_TB.SelectedText = "";
            this.P_TB.Size = new System.Drawing.Size(139, 35);
            this.P_TB.TabIndex = 21;
            // 
            // amountTB
            // 
            this.amountTB.BackColor = System.Drawing.Color.Transparent;
            this.amountTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.amountTB.BorderRadius = 7;
            this.amountTB.BorderThickness = 3;
            this.amountTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.amountTB.DefaultText = "";
            this.amountTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.amountTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.amountTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.amountTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.amountTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.amountTB.Font = new System.Drawing.Font("Zilla Slab", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.amountTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.amountTB.Location = new System.Drawing.Point(178, 23);
            this.amountTB.Margin = new System.Windows.Forms.Padding(12);
            this.amountTB.Name = "amountTB";
            this.amountTB.PasswordChar = '\0';
            this.amountTB.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.amountTB.PlaceholderText = "";
            this.amountTB.SelectedText = "";
            this.amountTB.Size = new System.Drawing.Size(139, 35);
            this.amountTB.TabIndex = 20;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(338, 24);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(138, 27);
            this.guna2HtmlLabel2.TabIndex = 19;
            this.guna2HtmlLabel2.Text = "Enter Purpose: ";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(46, 81);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(117, 27);
            this.guna2HtmlLabel1.TabIndex = 18;
            this.guna2HtmlLabel1.Text = "Pledge Item: ";
            // 
            // money_lbl
            // 
            this.money_lbl.BackColor = System.Drawing.Color.Transparent;
            this.money_lbl.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.money_lbl.Location = new System.Drawing.Point(25, 22);
            this.money_lbl.Name = "money_lbl";
            this.money_lbl.Size = new System.Drawing.Size(138, 27);
            this.money_lbl.TabIndex = 17;
            this.money_lbl.Text = "Enter Amount: ";
            // 
            // item_panel
            // 
            this.item_panel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.item_panel.BorderRadius = 20;
            this.item_panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.item_panel.BorderThickness = 3;
            this.item_panel.Controls.Add(this.pWorth_TB);
            this.item_panel.Controls.Add(this.guna2HtmlLabel4);
            this.item_panel.Controls.Add(this.address_TB);
            this.item_panel.Controls.Add(this.guna2HtmlLabel3);
            this.item_panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.item_panel.Location = new System.Drawing.Point(87, 240);
            this.item_panel.Name = "item_panel";
            this.item_panel.Size = new System.Drawing.Size(541, 104);
            this.item_panel.TabIndex = 23;
            // 
            // pWorth_TB
            // 
            this.pWorth_TB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.pWorth_TB.BorderRadius = 6;
            this.pWorth_TB.BorderThickness = 2;
            this.pWorth_TB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pWorth_TB.DefaultText = "";
            this.pWorth_TB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.pWorth_TB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pWorth_TB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pWorth_TB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pWorth_TB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pWorth_TB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pWorth_TB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pWorth_TB.Location = new System.Drawing.Point(228, 54);
            this.pWorth_TB.Name = "pWorth_TB";
            this.pWorth_TB.PasswordChar = '\0';
            this.pWorth_TB.PlaceholderText = "";
            this.pWorth_TB.SelectedText = "";
            this.pWorth_TB.Size = new System.Drawing.Size(141, 34);
            this.pWorth_TB.TabIndex = 21;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(36, 58);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(176, 27);
            this.guna2HtmlLabel4.TabIndex = 20;
            this.guna2HtmlLabel4.Text = "Worth of Property: ";
            // 
            // address_TB
            // 
            this.address_TB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.address_TB.BorderRadius = 6;
            this.address_TB.BorderThickness = 2;
            this.address_TB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.address_TB.DefaultText = "";
            this.address_TB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.address_TB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.address_TB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.address_TB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.address_TB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.address_TB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.address_TB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.address_TB.Location = new System.Drawing.Point(228, 14);
            this.address_TB.Name = "address_TB";
            this.address_TB.PasswordChar = '\0';
            this.address_TB.PlaceholderText = "";
            this.address_TB.SelectedText = "";
            this.address_TB.Size = new System.Drawing.Size(287, 34);
            this.address_TB.TabIndex = 19;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(21, 15);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(191, 27);
            this.guna2HtmlLabel3.TabIndex = 18;
            this.guna2HtmlLabel3.Text = "Address of Property: ";
            // 
            // goldpanel
            // 
            this.goldpanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.goldpanel.BorderRadius = 20;
            this.goldpanel.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.goldpanel.BorderThickness = 3;
            this.goldpanel.Controls.Add(this.pGold_TB);
            this.goldpanel.Controls.Add(this.gWeight_TB);
            this.goldpanel.Controls.Add(this.gValue_TB);
            this.goldpanel.Controls.Add(this.guna2HtmlLabel6);
            this.goldpanel.Controls.Add(this.guna2HtmlLabel7);
            this.goldpanel.Controls.Add(this.guna2HtmlLabel5);
            this.goldpanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.goldpanel.Location = new System.Drawing.Point(87, 246);
            this.goldpanel.Name = "goldpanel";
            this.goldpanel.Size = new System.Drawing.Size(520, 101);
            this.goldpanel.TabIndex = 23;
            // 
            // pGold_TB
            // 
            this.pGold_TB.BackColor = System.Drawing.Color.Transparent;
            this.pGold_TB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pGold_TB.BorderRadius = 10;
            this.pGold_TB.BorderThickness = 3;
            this.pGold_TB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pGold_TB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pGold_TB.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pGold_TB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pGold_TB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pGold_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.pGold_TB.ItemHeight = 30;
            this.pGold_TB.Items.AddRange(new object[] {
            "12",
            "24"});
            this.pGold_TB.Location = new System.Drawing.Point(162, 57);
            this.pGold_TB.Name = "pGold_TB";
            this.pGold_TB.Size = new System.Drawing.Size(106, 36);
            this.pGold_TB.TabIndex = 23;
            // 
            // gWeight_TB
            // 
            this.gWeight_TB.BackColor = System.Drawing.Color.Transparent;
            this.gWeight_TB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gWeight_TB.BorderRadius = 7;
            this.gWeight_TB.BorderThickness = 3;
            this.gWeight_TB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gWeight_TB.DefaultText = "";
            this.gWeight_TB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.gWeight_TB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.gWeight_TB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gWeight_TB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gWeight_TB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gWeight_TB.Font = new System.Drawing.Font("Zilla Slab", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gWeight_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.gWeight_TB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gWeight_TB.Location = new System.Drawing.Point(400, 12);
            this.gWeight_TB.Margin = new System.Windows.Forms.Padding(12);
            this.gWeight_TB.Name = "gWeight_TB";
            this.gWeight_TB.PasswordChar = '\0';
            this.gWeight_TB.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.gWeight_TB.PlaceholderText = "";
            this.gWeight_TB.SelectedText = "";
            this.gWeight_TB.Size = new System.Drawing.Size(112, 35);
            this.gWeight_TB.TabIndex = 23;
            // 
            // gValue_TB
            // 
            this.gValue_TB.BackColor = System.Drawing.Color.Transparent;
            this.gValue_TB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gValue_TB.BorderRadius = 7;
            this.gValue_TB.BorderThickness = 3;
            this.gValue_TB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gValue_TB.DefaultText = "";
            this.gValue_TB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.gValue_TB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.gValue_TB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gValue_TB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gValue_TB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gValue_TB.Font = new System.Drawing.Font("Zilla Slab", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gValue_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.gValue_TB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gValue_TB.Location = new System.Drawing.Point(162, 12);
            this.gValue_TB.Margin = new System.Windows.Forms.Padding(12);
            this.gValue_TB.Name = "gValue_TB";
            this.gValue_TB.PasswordChar = '\0';
            this.gValue_TB.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(44)))), ((int)(((byte)(141)))));
            this.gValue_TB.PlaceholderText = "";
            this.gValue_TB.SelectedText = "";
            this.gValue_TB.Size = new System.Drawing.Size(125, 35);
            this.gValue_TB.TabIndex = 23;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(316, 18);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(76, 27);
            this.guna2HtmlLabel6.TabIndex = 23;
            this.guna2HtmlLabel6.Text = "Weight: ";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(90, 56);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(66, 27);
            this.guna2HtmlLabel7.TabIndex = 24;
            this.guna2HtmlLabel7.Text = "Purity: ";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Zilla Slab SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(27, 18);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(129, 27);
            this.guna2HtmlLabel5.TabIndex = 18;
            this.guna2HtmlLabel5.Text = "Value of Gold: ";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Zilla Slab SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(282, 203);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(159, 32);
            this.guna2Button1.TabIndex = 23;
            this.guna2Button1.Text = "Proceed Next";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(49)))), ((int)(((byte)(141)))));
            this.guna2Button2.Font = new System.Drawing.Font("Zilla Slab SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(300, 374);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(111, 41);
            this.guna2Button2.TabIndex = 24;
            this.guna2Button2.Text = "Request";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // RequestLoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.Controls.Add(this.item_panel);
            this.Controls.Add(this.goldpanel);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.reqData_panel);
            this.Controls.Add(this.reqloan_lbl);
            this.Name = "RequestLoanForm";
            this.Size = new System.Drawing.Size(697, 433);
            this.Load += new System.EventHandler(this.RequestLoanForm_Load);
            this.reqData_panel.ResumeLayout(false);
            this.reqData_panel.PerformLayout();
            this.item_panel.ResumeLayout(false);
            this.item_panel.PerformLayout();
            this.goldpanel.ResumeLayout(false);
            this.goldpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel reqloan_lbl;
        private Guna.UI2.WinForms.Guna2Panel reqData_panel;
        private Guna.UI2.WinForms.Guna2Panel item_panel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel money_lbl;
        private Guna.UI2.WinForms.Guna2TextBox amountTB;
        private Guna.UI2.WinForms.Guna2TextBox P_TB;
        private Guna.UI2.WinForms.Guna2ComboBox item_cb;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Panel goldpanel;
        private Guna.UI2.WinForms.Guna2TextBox pWorth_TB;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2TextBox address_TB;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2ComboBox pGold_TB;
        private Guna.UI2.WinForms.Guna2TextBox gWeight_TB;
        private Guna.UI2.WinForms.Guna2TextBox gValue_TB;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}
