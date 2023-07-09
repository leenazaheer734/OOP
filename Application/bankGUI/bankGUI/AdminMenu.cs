using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankGUI
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
            openAccount1.Visible = false;
            closeAcc1.Hide();
        }

        private void logoutBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            SignInForm sif = new SignInForm();
            sif.Show();
        }


        private void createBTN_Click(object sender, EventArgs e)
        {
            closeAcc1.Visible = false;
            openAccount1.Visible = true;

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            openAccount1.Hide();
            closeAcc1.Visible = true;
        }
    }
}
