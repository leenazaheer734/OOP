using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankWithGUI.BL;
using BankWithGUI.DL;

namespace BankWithGUI
{
    public partial class BankMain : Form
    {
        static int accountnum = 1;
        public BankMain()
        {
            InitializeComponent();

            AdminDL.LoadAdminDataFromFile();
            ClientDL.LoadClientDataFromFile(ref accountnum);
        }

        private void BankMain_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isAdminPresent = AdminDL.CheckAdminPresence();    //checking if admin is intially present
            if (isAdminPresent == false)
            {
                AdminSignUp asup = new AdminSignUp();
                this.Hide();
                asup.Show();
            }
            else
            {

            }
        }
    }
}
