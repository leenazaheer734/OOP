using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyBankGUI.DL;

namespace MyBankGUI
{
    public partial class Form1 : Form
    {
        static int accountnum = 1;
        public Form1()
        {
            InitializeComponent();
            AdminDL.LoadAdminDataFromFile();
            ClientDL.LoadClientDataFromFile(ref accountnum);
            loadingBar.Value = 0;
        }

        private void form1timer_Tick(object sender, EventArgs e)
        {
            loadingBar.Value = loadingBar.Value + 3;
            if(loadingBar.Value == 100)
            {
                form1timer.Stop();
                this.Hide();

                bool isAdminPresent = AdminDL.CheckAdminPresence();    //checking if admin is intially present
                if (isAdminPresent == false)
                {
                    AdminSignUp asup = new AdminSignUp();
                    asup.Show();
                }
                else
                {
                    SignInForm sif = new SignInForm();
                    sif.Show();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
